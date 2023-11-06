using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day12
    {
        class Tile
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Cost { get; set; }
            public int Distance { get; set; }
            public int CostDistance => Cost + Distance;
            public Tile Parent { get; set; }

            //The distance is essentially the estimated distance, ignoring walls to our target. 
            //So how many tiles left and right, up and down, ignoring walls, to get there. 
            public void SetDistance(int targetX, int targetY)
            {
                this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
            }
        }

        private Parser _parser;
        private Dictionary<string, int> _layout = new Dictionary<string, int>();
        private int _result = int.MaxValue;
        //private Tile _start = new Tile();
        private Tile _end = new Tile();

        public Day12()
        {
            _parser = new Parser();
        }

        public long ExecutePart1(string fileName, int executionTimes = 20, bool partTwo = false)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var width = lines.First().Length;
            var starts = new List<Tile>();
            for (var y = 0; y < lines.Count; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (lines[y][x] == 'a')
                    {
                        starts.Add(new Tile{X = x, Y = y});
                    }
                }
            }


            //_start.Y = lines.FindIndex(x => x.Contains("S"));
            //_start.X = lines[_start.Y].IndexOf("S");

            _end.Y = lines.FindIndex(x => x.Contains("E"));
            _end.X = lines[_end.Y].IndexOf("E");

            foreach (var start in starts)
            {
                start.SetDistance(_end.X, _end.Y);
                var result = FindPath(start, lines);
                if (result < _result)
                {
                    _result = result;
                }
            }


            return _result;
        }

        private int FindPath(Tile start, List<string> lines)
        {
            var activeTiles = new List<Tile>();
            activeTiles.Add(start);
            var visitedTiles = new List<Tile>();

            while (activeTiles.Any())
            {
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                if (checkTile.X == _end.X && checkTile.Y == _end.Y)
                {
                    //We found the destination and we can be sure (Because the the OrderBy above)
                    //That it's the most low cost option. 
                    var tile = checkTile;
                    Debug.WriteLine("Retracing steps backwards...");
                    var count = 0;
                    while (true)
                    {
                        Console.WriteLine($"{tile.X} : {tile.Y}");
                        if (lines[tile.Y][tile.X] != 'E')
                        {
                            //var newMapRow = lines[tile.Y].ToCharArray();
                            //newMapRow[tile.X] = '*';
                            //lines[tile.Y] = new string(newMapRow);
                            count++;
                        }

                        tile = tile.Parent;
                        if (tile == null)
                        {
                            //Debug.WriteLine("Map looks like :");
                            //lines.ForEach(x => Debug.WriteLine(x));
                            //Debug.WriteLine("Done!");
                            return count;
                        }
                    }
                }

                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                var walkableTiles = GetWalkableTiles(lines, checkTile, _end);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if (existingTile.CostDistance > checkTile.CostDistance)
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                    else
                    {
                        //We've never seen this tile before so add it to the list. 
                        activeTiles.Add(walkableTile);
                    }
                }
            }

            Debug.WriteLine("No Path Found!");

            return int.MaxValue;
        }

        private static List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var possibleTiles = new List<Tile>()
            {
                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            };

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;

            var currentValue = map[currentTile.Y][currentTile.X] == 'S' ? 'a' : map[currentTile.Y][currentTile.X];

            return possibleTiles
                .Where(tile => tile.X >= 0 && tile.X <= maxX)
                .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                .Where(tile => (map[tile.Y][tile.X] < currentValue && map[tile.Y][tile.X] != 'E') || map[tile.Y][tile.X] == currentValue || map[tile.Y][tile.X] == (char)(currentValue + 1) || (map[tile.Y][tile.X] == 'E' && (currentValue == 'y' || currentValue == 'z')))
                .ToList();
        }

        private void FindShortestPath(int x, int y, int count, string direction)
        {
            var currentHeight = _layout[$"{x}-{y}"];
            if (currentHeight == 25 || currentHeight == 26)
            {
                if (_layout[$"{x + 1}-{y}"] == 27 || _layout[$"{x}-{y + 1}"] == 27 || _layout[$"{x - 1}-{y}"] == 27 || _layout[$"{x}-{y - 1}"] == 27)
                {
                    if (count < _result)
                    {
                        _result = count;
                        return;
                    }
                }
            }

            if (direction != "left" && _layout.ContainsKey($"{x + 1}-{y}") && (_layout[$"{x + 1}-{y}"] == currentHeight || _layout[$"{x + 1}-{y}"] == currentHeight + 1))
            {
                FindShortestPath(x + 1, y, count++, "right");
            }
            if(direction != "down" && _layout.ContainsKey($"{x}-{y + 1}") && (_layout[$"{x}-{y + 1}"] == currentHeight || _layout[$"{x}-{y + 1}"] == currentHeight + 1))
            {
                FindShortestPath(x, y + 1, count++, "up");
            }
            if (direction != "right" && _layout.ContainsKey($"{x - 1}-{y}") && (_layout[$"{x - 1}-{y}"] == currentHeight || _layout[$"{x - 1}-{y}"] == currentHeight + 1))
            {
                FindShortestPath(x - 1, y, count++, "left");
            }
            if (direction != "up" && _layout.ContainsKey($"{x}-{y - 1}") && (_layout[$"{x}-{y - 1}"] == currentHeight || _layout[$"{x}-{y - 1}"] == currentHeight + 1))
            {
                FindShortestPath(x, y - 1, count++, "down");
            }
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            return 0;
        }
    }
}

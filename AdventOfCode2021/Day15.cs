using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day15
    {
        private readonly Parser _parser;
        private readonly List<Node15> _nodes = new List<Node15>();
        private int _result = 0;
        private StringBuilder _sb = new StringBuilder();

        public Day15()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var map = _parser.ParseLines(fileName).ToList();
            var start = new Tile {X = 0, Y = 0};
            var finish = new Tile {Y = map.First().Length - 1, X = map.Count - 1};
            start.SetDistance(finish.X, finish.Y);
            var activeTiles = new List<Tile> {start};
            var visitedTiles = new List<Tile>();
            while (activeTiles.Any())
            {
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();
                
                if (checkTile.X == finish.X && checkTile.Y == finish.Y)
                {
                    //We found the destination and we can be sure (Because the the OrderBy above)
                    //That it's the most low cost option. 
                    var tile = checkTile;
                    while (true)
                    {
                        _result += tile.Value;
                        //Debug.WriteLine(tile.Value);
                        tile = tile.Parent;
                        if (tile == null)
                        {
                            return _result;
                        }
                    }
                }

                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                var walkableTiles = GetWalkableTiles(map, checkTile, finish);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        
                        if (existingTile.CostDistance < checkTile.CostDistance)
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
            
            return _result;
        }

        public void ExpandHorizontally(List<string> map)
        {
            var sb = new StringBuilder();

            for (var row = 0; row < map.Count; row++)
            {
                foreach (var value in map[row].Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var secondPart = sb.ToString();
                sb.Clear();
                foreach (var value in secondPart.Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var thirdPart = sb.ToString();
                sb.Clear();

                foreach (var value in thirdPart.Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var fourthPart = sb.ToString();
                sb.Clear();

                foreach (var value in fourthPart.Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var fifthPart = sb.ToString();
                sb.Clear();
                sb.Append(map[row]).Append(secondPart).Append(thirdPart).Append(fourthPart).Append(fifthPart);
                map[row] = sb.ToString();
                sb.Clear();
            }
        }
        public void ExpandHorizontally2(List<string> map)
        {
            var sb = new StringBuilder();

            for (var row = 10; row < map.Count; row++)
            {
                foreach (var value in map[row].Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var secondPart = sb.ToString();
                sb.Clear();
                foreach (var value in secondPart.Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var thirdPart = sb.ToString();
                sb.Clear();

                foreach (var value in thirdPart.Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var fourthPart = sb.ToString();
                sb.Clear();

                foreach (var value in fourthPart.Select(c => c - '0' + 1))
                {
                    sb.Append(value > 9 ? "1" : value.ToString());
                }

                var fifthPart = sb.ToString();
                sb.Clear();
                sb.Append(map[row]).Append(secondPart).Append(thirdPart).Append(fourthPart).Append(fifthPart);
                map[row] = sb.ToString();
                sb.Clear();
            }
        }

        public void ExpandVertically(List<string> map)
        {
            var index = map.Count;
            var count = map.Count;
            for (int i = 1; i <= 4; i++)
            {
                for (var row = 0; row < index; row++)
                {
                    map.Add(map[row].Substring(index * i, count));
                }
            }
        }

        public int ExecutePart2(string fileName)
        {
            var map = _parser.ParseLines(fileName).ToList();
            ExpandHorizontally(map);
            ExpandVertically(map);
            ExpandHorizontally2(map);
            var start = new Tile { X = 0, Y = 0 };
            var finish = new Tile { Y = map.First().Length - 1, X = map.Count - 1 };
            start.SetDistance(finish.X, finish.Y);
            var activeTiles = new List<Tile> { start };
            var visitedTiles = new List<Tile>();
            while (activeTiles.Any())
            {
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                if (checkTile.X == finish.X && checkTile.Y == finish.Y)
                {
                    //We found the destination and we can be sure (Because the the OrderBy above)
                    //That it's the most low cost option. 
                    var tile = checkTile;
                    while (true)
                    {
                        _result += tile.Value;
                        tile = tile.Parent;
                        if (tile == null)
                        {
                            return _result;
                        }
                    }
                }

                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                var walkableTiles = GetWalkableTiles(map, checkTile, finish);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);

                        if (existingTile.CostDistance < checkTile.CostDistance)
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

            return _result;
        }

        private static int GetCost(List<string> map, Tile currentTile, string direction) => 
            direction switch
            {
                "TOP" => currentTile.X - 1 >= 0 ? map[currentTile.X - 1][currentTile.Y] - '0' : 10000,
                "BOTTOM" => currentTile.X + 1 < map[currentTile.X].Length ? map[currentTile.X + 1][currentTile.Y] - '0' : 10000,
                "LEFT" => currentTile.Y - 1 >= 0 ? map[currentTile.X][currentTile.Y - 1] - '0' : 10000,
                "RIGHT" => currentTile.Y + 1 < map.Count ? map[currentTile.X][currentTile.Y + 1] - '0' : 10000,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

        private static List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var leftCost = GetCost(map, currentTile, "LEFT");
            var rightCost = GetCost(map, currentTile, "RIGHT");
            var topCost = GetCost(map, currentTile, "TOP");
            var bottomCost = GetCost(map, currentTile, "BOTTOM");

            var possibleTiles = new List<Tile>()
            {
                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Value =leftCost, Cost = currentTile.Cost + leftCost },
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Value = rightCost, Cost = currentTile.Cost + rightCost },
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Value = topCost, Cost = currentTile.Cost + topCost },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Value = bottomCost, Cost = currentTile.Cost + bottomCost }
            };

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;

            return possibleTiles
                .Where(tile => tile.X >= 0 && tile.X <= maxX)
                .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                .ToList();
        }
    }

    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int Value { get; set; }
        public int CostDistance => Cost + Distance;
        public Tile Parent { get; set; }

        //The distance is essentially the estimated distance, ignoring walls to our target. 
        //So how many tiles left and right, up and down, ignoring walls, to get there. 
        public void SetDistance(int targetX, int targetY)
        {
            this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
    }

    public class Node15
    {
        private readonly IList<Node15> _associatedNodes;
        public string Name { get; set; }
        public int Value;
        public bool Visited = false;

        public Node15(string name, int value)
        {
            Name = name;
            Value = value;
            _associatedNodes = new List<Node15>();
        }

        public bool CanVisit()
        {
            return !Visited;
        }

        public void Visit()
        {
            Visited = true;
        }

        public void Reset()
        {
            Visited = false;
        }

        public void AddConnector(Node15 node)
        {
            _associatedNodes.Add(node);
        }

        public IEnumerable<Node15> NodesToVisit()
        {
            return _associatedNodes.Where(n => n.CanVisit());
        }
    }
}

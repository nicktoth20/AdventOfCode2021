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
        private int _result = 0;
        private StringBuilder _sb = new StringBuilder();
        private int _maxX = 0;
        private int _maxY = 0;
        private List<string> _map;

        public Day15()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            //var map = _parser.ParseLines(fileName).ToList();
            //var start = new Tile {X = 0, Y = 0};
            //var finish = new Tile {Y = map.First().Length - 1, X = map.Count - 1};
            //start.SetDistance(finish.X, finish.Y);
            //var activeTiles = new List<Tile> {start};
            //var visitedTiles = new List<Tile>();
            //while (activeTiles.Any())
            //{
            //    var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

            //    if (checkTile.X == finish.X && checkTile.Y == finish.Y)
            //    {
            //        //We found the destination and we can be sure (Because the the OrderBy above)
            //        //That it's the most low cost option. 
            //        var tile = checkTile;
            //        while (true)
            //        {
            //            _result += tile.Value;
            //            //Debug.WriteLine(tile.Value);
            //            tile = tile.Parent;
            //            if (tile == null)
            //            {
            //                return _result;
            //            }
            //        }
            //    }

            //    visitedTiles.Add(checkTile);
            //    activeTiles.Remove(checkTile);

            //    var walkableTiles = GetWalkableTiles(map, checkTile, finish);

            //    foreach (var walkableTile in walkableTiles)
            //    {
            //        //We have already visited this tile so we don't need to do so again!
            //        if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
            //            continue;

            //        //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
            //        if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
            //        {
            //            var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);

            //            if (existingTile.CostDistance < checkTile.CostDistance)
            //            {
            //                activeTiles.Remove(existingTile);
            //                activeTiles.Add(walkableTile);
            //            }
            //        }
            //        else
            //        {
            //            //We've never seen this tile before so add it to the list. 
            //            activeTiles.Add(walkableTile);
            //        }
            //    }
            //}

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
            var stop = new Stopwatch();
            stop.Start();
            _map = _parser.ParseLines(fileName).ToList();
            //ExpandHorizontally(map);
            //ExpandVertically(map);
            //ExpandHorizontally2(map);
            _maxX = 499;
            _maxY = 499;
            var activeTiles = new Dictionary<string, int> { { "0-0", 0 } };
            var visitedTiles = new Dictionary<string, int>();

            while (activeTiles.Any())
            {
                var checkTile = activeTiles.OrderBy(x => x.Value).First();

                //if (checkTile.Key == $"{_maxX}-{_maxY}")
                //{
                //    stop.Stop();
                //    Debug.WriteLine(stop.ElapsedMilliseconds);
                //    return checkTile.Value;
                //}

                if (!visitedTiles.ContainsKey(checkTile.Key))
                {
                    visitedTiles.Add(checkTile.Key, checkTile.Value);
                }

                activeTiles.Remove(checkTile.Key);
                var walkableTiles = GetWalkableTiles(_map, checkTile.Key);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.ContainsKey($"{walkableTile.X}-{walkableTile.Y}"))
                    {
                        var cost = visitedTiles[$"{walkableTile.X}-{walkableTile.Y}"];

                        if (cost > walkableTile.Value)
                        {
                            visitedTiles[$"{walkableTile.X}-{walkableTile.Y}"] = walkableTile.Value;
                        }
                        continue;
                    }

                    var newCost = walkableTile.Cost + checkTile.Value;

                    ////It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.ContainsKey($"{walkableTile.X}-{walkableTile.Y}"))
                    {
                        var tile = activeTiles[$"{walkableTile.X}-{walkableTile.Y}"];

                        if (tile > newCost)
                        {
                            activeTiles[$"{walkableTile.X}-{walkableTile.Y}"] = newCost;
                        }
                    }
                    else
                    {
                        activeTiles[$"{walkableTile.X}-{walkableTile.Y}"] = newCost;
                    }
                }
            }

            return visitedTiles["499-499"];
        }

        int RiskLevel(int dy, int dx)
        {
            var ydim = dy / 100;
            var xdim = dx / 100;
            var vx = _map[dy % 100][dx % 100] - '0';

            return ((vx - 1 + ydim + xdim) % 9) + 1;
        }
        private List<Tile> GetWalkableTiles(List<string> map, string key)
        {

            var possibleTiles = new List<Tile>();

            var point = key.Split('-');
            var x = int.Parse(point[0]);
            var y = int.Parse(point[1]);
            if (x + 1 <= _maxX)
            {
                var bottomCost = RiskLevel(y, x + 1);
                possibleTiles.Add(new Tile { Cost = bottomCost, X = x + 1, Y = y });
            }

            if (x - 1 >= 0)
            {
                var bottomCost = RiskLevel(y, x - 1);
                possibleTiles.Add(new Tile { Cost = bottomCost, X = x - 1, Y = y });
            }

            if (y + 1 <= _maxY)
            {
                var rightCost = RiskLevel(y + 1, x);
                possibleTiles.Add(new Tile { Cost = rightCost, X = x, Y = y + 1 });
            }

            if (y - 1 >= 0)
            {
                var rightCost = RiskLevel(y - 1, x);
                possibleTiles.Add(new Tile { Cost = rightCost, X = x, Y = y - 1 });
            }

            return possibleTiles;
        }
    }

    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
    }
}

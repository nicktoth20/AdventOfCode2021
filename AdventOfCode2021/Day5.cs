using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day5
    {
        private Parser _parser { get; set; }
        private IList<Segment> _segments { get; set; }
        private Dictionary<string, int> _markings { get; set; }

        public Day5()
        {
            _parser = new Parser();
            _markings = new Dictionary<string, int>();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            _segments = new List<Segment>(lines.Count);
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                var firstCoordinates = Array.ConvertAll(parts[0].Split(','), int.Parse);
                var secondCoordinates = Array.ConvertAll(parts[2].Split(','), int.Parse);
                _segments.Add(new Segment
                {
                    Start = new Point(firstCoordinates[0], firstCoordinates[1]), 
                    End = new Point(secondCoordinates[0], secondCoordinates[1])
                });
            }

            //_segments = _segments.Where(s => s.Start.X == s.End.X || s.Start.Y == s.End.Y).ToList();
            var index = 0;
            foreach (var segment in _segments)
            {
                if (segment.Start.Y == segment.End.Y)
                {
                    index++;
                    var start = segment.Start.X > segment.End.X ? segment.End.X : segment.Start.X;
                    var end = segment.Start.X > segment.End.X ? segment.Start.X : segment.End.X;
                    for (var x = start; x <= end; x++)
                    {
                        var k = $"{x}-{segment.Start.Y}";
                        if (_markings.ContainsKey(k))
                        {
                            _markings[k]++;
                        }
                        else
                        {
                            _markings[k] = 1;
                        }
                    }
                }
                else if (segment.Start.X == segment.End.X)
                {
                    // they could descend
                    var start = segment.Start.Y > segment.End.Y ? segment.End.Y : segment.Start.Y;
                    var end = segment.Start.Y > segment.End.Y ? segment.Start.Y : segment.End.Y;
                    for (var y = start; y <= end; y++)
                    {
                        var k = $"{segment.Start.X}-{y}";
                        if (_markings.ContainsKey(k))
                        {
                            _markings[k]++;
                        }
                        else
                        {
                            _markings[k] = 1;
                        }
                    }
                }
                else
                {
                    var flip = segment.Start.X > segment.End.X;
                    var xStart = flip ? segment.End.X : segment.Start.X;
                    var xEnd = flip ? segment.Start.X : segment.End.X;

                    var yStart = flip ? segment.End.Y : segment.Start.Y;
                    var shouldIncrease = !flip ? segment.End.Y > segment.Start.Y : segment.Start.Y > segment.End.Y;

                    for (var x = xStart; x <= xEnd; x++)
                    {
                        var k = $"{x}-{yStart}";
                        if (_markings.ContainsKey(k))
                        {
                            _markings[k]++;
                        }
                        else
                        {
                            _markings[k] = 1;
                        }

                        if (shouldIncrease)
                        {
                            yStart++;
                        }
                        else
                        {
                            yStart--;
                        }
                    }
                }
            }

            return _markings.Count(m => m.Value > 1);
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Segment
    {
        public Point Start { get; set; }
        public Point End { get; set; }
    }

    public class Markings
    {
        public string Key { get; set; }
        public int TimesCrossed { get; set; }

        public Markings(int x, int y)
        {
            Key = $"{x}{y}";
            TimesCrossed = 1;
        }
    }
}

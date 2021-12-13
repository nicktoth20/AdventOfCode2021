using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day13
    {
        private Parser _parser;
        private readonly Dictionary<string, Point> _results = new Dictionary<string, Point>();
        private readonly IList<Fold> _foldAlong = new List<Fold>();

        public Day13()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            foreach (var line in lines)
            {
                if (line.StartsWith("fold along"))
                {
                    AddFoldAlong(line);
                    continue;
                }

                var coordinates = line.Split(',');
                if (coordinates.Length != 2)
                {
                    continue;
                }
                var x = int.Parse(coordinates[0]);
                var y = int.Parse(coordinates[1]);

                _results[$"{coordinates[0]}-{coordinates[1]}"] = new Point(x, y);
            }
            FoldPaper(_foldAlong.First());

            return _results.Count;
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            foreach (var line in lines)
            {
                if (line.StartsWith("fold along"))
                {
                    AddFoldAlong(line);
                    continue;
                }

                var coordinates = line.Split(',');
                if (coordinates.Length != 2)
                {
                    continue;
                }
                var x = int.Parse(coordinates[0]);
                var y = int.Parse(coordinates[1]);

                _results[$"{coordinates[0]}-{coordinates[1]}"] = new Point(x, y);
            }

            foreach (var fold in _foldAlong)
            {
                FoldPaper(fold);
            }
            PrintMessage2();
            return _results.Count;
        }

        private void FoldPaper(Fold fold)
        {
            if (fold.IsX)
            {
                FoldHorizontally(fold.Value);
            }
            else
            {
                FoldVertically(fold.Value);
            }
        }

        private void FoldVertically(int value)
        {
            var pointsToFold = _results.Where(r => r.Value.Y > value).ToList();

            foreach (var pointToFold in pointsToFold)
            {
                _results.Remove($"{pointToFold.Value.X}-{pointToFold.Value.Y}");
                var yBecomes = (value) - (pointToFold.Value.Y - value);
                _results[$"{pointToFold.Value.X}-{yBecomes}"] = new Point(pointToFold.Value.X, yBecomes);
            }
        }

        private void FoldHorizontally(int value)
        {
            var pointsToFold = _results.Where(r => r.Value.X > value).ToList();

            foreach (var pointToFold in pointsToFold)
            {
                _results.Remove($"{pointToFold.Value.X}-{pointToFold.Value.Y}");
                var xBecomes = (value) - (pointToFold.Value.X - value);
                _results[$"{xBecomes}-{pointToFold.Value.Y}"] = new Point(xBecomes, pointToFold.Value.Y);
            }
        }

        private void AddFoldAlong(string line)
        {
            _foldAlong.Add(new Fold(line));
        }

        private void PrintMessage()
        {
            var maxX = _results.Values.Max(v => v.X);
            var maxY = _results.Values.Max(v => v.Y);

            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    if (_results.ContainsKey($"{x}-{y}"))
                    {
                        Debug.Write("X");
                    }
                    else
                    {
                        Debug.Write(" ");
                    }
                }
                Debug.WriteLine("");
            }
        }
        private void PrintMessage2()
        {
            var maxX = _results.Values.Max(v => v.X);
            var maxY = _results.Values.Max(v => v.Y);

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    if (_results.ContainsKey($"{x}-{y}"))
                    {
                        Debug.Write("X");
                    }
                    else
                    {
                        Debug.Write(" ");
                    }
                }
                Debug.WriteLine("");
            }
        }
    }

    public class Fold
    {
        public bool IsX { get; set; }
        public int Value { get; set; }

        public Fold(string line)
        {
            var parts = line.Split(' ');
            var instruction = parts[2].Split('=');
            IsX = instruction[0] == "x";
            Value = int.Parse(instruction[1]);
        }
    }
}

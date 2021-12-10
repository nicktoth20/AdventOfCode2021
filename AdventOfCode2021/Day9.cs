using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day9
    {
        private readonly Parser _parser;
        private int[,] _layout;
        private readonly IList<int> _lowPoints;
        private IList<PointWithValue> _lowPointsPart2;

        public Day9()
        {
            _parser = new Parser();
            _lowPoints = new List<int>();
            _lowPointsPart2 = new List<PointWithValue>();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var rows = lines.Count;
            var columns = lines.First().Length;
            _layout = new int[rows, columns];
            for (var row = 0; row < lines.Count; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    _layout[row, column] = lines[row][column] - '0';
                }
            }

            FindLowPoints(rows, columns);
            return _lowPoints.Sum();
        }

        private int Right(int row, int column)
        {
            return column + 1 == _layout.GetLength(1) ? 100 : _layout[row, column + 1];
        }

        private int Left(int row, int column)
        {
            return column - 1 < 0 ? 100 : _layout[row, column - 1];
        }

        private int Top(int row, int column)
        {
            return row - 1 < 0 ? 100 : _layout[row - 1, column];
        }

        private int Bottom(int row, int column)
        {
            return row + 1 == _layout.GetLength(0) ? 100 : _layout[row + 1, column];
        }

        private void FindLowPoints(int rows, int columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    var value = _layout[row, column];
                    if (value < Bottom(row, column) && 
                        value < Top(row, column) && 
                        value < Left(row, column) &&
                        value < Right(row, column))
                    {
                        _lowPoints.Add(value + 1);
                    }
                }
            }
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var rows = lines.Count;
            var columns = lines.First().Length;
            _layout = new int[rows, columns];
            for (var row = 0; row < lines.Count; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    _layout[row, column] = lines[row][column] - '0';
                }
            }

            FindLowPointsForPart2(rows, columns);
            foreach (var point in _lowPointsPart2)
            {
                FindBasin(point);
            }

            _lowPointsPart2 = _lowPointsPart2.OrderByDescending(p => p.Value.Count).ToList();
            var test = _lowPointsPart2.First();
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    if (test.Value.Contains($"{row}-{column}"))
                    {
                        Debug.Write("X");
                    }
                    else
                    {
                        Debug.Write(_layout[row, column]);
                    }
                }
                Debug.WriteLine("");
            }
            return _lowPointsPart2[0].Value.Count * _lowPointsPart2[1].Value.Count * _lowPointsPart2[2].Value.Count;
        }

        private void FindLowPointsForPart2(int rows, int columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    var value = _layout[row, column];
                    if (value < Bottom(row, column) &&
                        value < Top(row, column) &&
                        value < Left(row, column) &&
                        value < Right(row, column))
                    {
                        _lowPointsPart2.Add(new PointWithValue(row, column));
                    }
                }
            }
        }

        private void FindBasin(PointWithValue point, int xOffset = 0, int yOffset = 0)
        {
            var x = point.X + xOffset;
            var y = point.Y + yOffset;
            var value = _layout[x, y];
            if (value == 8)
            {
                return;
            }
            if (!point.Value.Contains($"{x + 1}-{y}") && Bottom(x, y) < 9)
            {
                point.Value.Add($"{x + 1}-{y}");
                FindBasin(point, xOffset + 1, yOffset);
            }
            if (!point.Value.Contains($"{x - 1}-{y}") && Top(x, y) < 9)
            {
                point.Value.Add($"{x - 1}-{y}");
                FindBasin(point, xOffset-1, yOffset);
            }
            if (!point.Value.Contains($"{x}-{y - 1}") && Left(x, y) < 9)
            {
                point.Value.Add($"{x}-{y - 1}");
                FindBasin(point, xOffset, yOffset-1);
            }
            if (!point.Value.Contains($"{x}-{y + 1}") && Right(x, y) < 9)
            {
                point.Value.Add($"{x}-{y + 1}");
                FindBasin(point, xOffset, yOffset+1);
            }
        }

        public class PointWithValue : Point
        {
            public HashSet<string> Value { get; set; }

            public PointWithValue(int x, int y) : base(x, y)
            {
                Value = new HashSet<string> {$"{x}-{y}"};
            }
        }
    }
}

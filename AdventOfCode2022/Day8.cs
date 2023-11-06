using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day8
    {
        private Parser _parser;
        private Dictionary<string, int> _coordinates = new Dictionary<string, int>();
        private int _width = 0;

        public Day8()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var result = 0;
            var lines = _parser.ParseLines(fileName).ToList();
            _width = lines.Count;
            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    var c = lines[i][j] - '0';
                    _coordinates.Add($"{i}-{j}", c - '0');
                }
            }


            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    result += CanBeSeen(i, j) ? 1 : 0;
                }
            }

            return result;
        }

        private bool CanBeSeen(int x, int y)
        {
            if (x == 0 || y == 0 || x == _width - 1 || y == _width - 1)
            {
                return true;
            }

            var height = _coordinates[$"{x}-{y}"];

            var rightVisible = true;
            for (var newX = x + 1; newX < _width && rightVisible; newX++)
            {
                if (_coordinates[$"{newX}-{y}"] >= height)
                {
                    rightVisible = false;
                }
            }

            if (rightVisible)
            {
                return true;
            }

            var leftVisible = true;
            for (var newX = x - 1; newX >= 0 && leftVisible; newX--)
            {
                if (_coordinates[$"{newX}-{y}"] >= height)
                {
                    leftVisible = false;
                }
            }

            if (leftVisible)
            {
                return true;
            }

            var upVisible = true;
            for (var newY = y - 1; newY >= 0 && upVisible; newY--)
            {
                if (_coordinates[$"{x}-{newY}"] >= height)
                {
                    upVisible = false;
                }
            }

            if (upVisible)
            {
                return true;
            }

            var downVisible = true;
            for (var newY = y + 1; newY < _width && downVisible; newY++)
            {
                if (_coordinates[$"{x}-{newY}"] >= height)
                {
                    downVisible = false;
                }
            }

            return downVisible;
        }

        public int ExecutePart2(string fileName)
        {
            var result = 0;
            var lines = _parser.ParseLines(fileName).ToList();
            _width = lines.Count;
            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    var c = lines[i][j] - '0';
                    _coordinates.Add($"{i}-{j}", c - '0');
                }
            }


            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    var trees = TreesSeen(i, j);
                    if (trees > result)
                    {
                        result = trees;
                    }

                }
            }

            return result;
        }

        private int TreesSeen(int x, int y)
        {
            var right = 0;
            var left = 0;
            var up = 0;
            var down = 0;
            var height = _coordinates[$"{x}-{y}"];

            if (x != _width - 1)
            {
                var proceed = true;
                for (var newX = x + 1; newX < _width && proceed; newX++)
                {
                    right++;
                    if (_coordinates[$"{newX}-{y}"] >= height)
                    {
                        proceed = false;
                    }
                }
            }

            if (x != 0)
            {
                var proceed = true;
                for (var newX = x - 1; newX >= 0 && proceed; newX--)
                {
                    left++;
                    if (_coordinates[$"{newX}-{y}"] >= height)
                    {
                        proceed = false;
                    }
                }
            }

            if (y != 0)
            {
                var proceed = true;
                for (var newY = y - 1; newY >= 0 && proceed; newY--)
                {
                    up++;
                    if (_coordinates[$"{x}-{newY}"] >= height)
                    {
                        proceed = false;
                    }
                }
            }

            if (y != _width - 1)
            {
                var proceed = true;
                for (var newY = y + 1; newY < _width && proceed; newY++)
                {
                    down++;
                    if (_coordinates[$"{x}-{newY}"] >= height)
                    {
                        proceed = false;
                    }
                }
            }

            return right * left * up * down;
        }
    }
}

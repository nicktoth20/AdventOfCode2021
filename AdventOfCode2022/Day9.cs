using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day9
    {
        public class Coordinate
        {
            public int Id { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        private Parser _parser;
        private List<Coordinate> _knots = new List<Coordinate>();
        private HashSet<string> _visited = new HashSet<string> { "0-0" };

        public Day9()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            for (var i = 0; i < 10; i++)
            {
                _knots.Add(new Coordinate{ Id = i, X = 0, Y = 0});
            }

            var lines = _parser.ParseLines(fileName).ToList();

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                var direction = parts[0];
                var spaces = int.Parse(parts[1]);

                switch (direction)
                {
                    case "R":

                        for (var i = 0; i < spaces; i++)
                        {
                            _knots.First(k => k.Id == 0).X++;
                            MoveKnots();
                        }
                        break;
                    case "U":

                        for (var i = 0; i < spaces; i++)
                        {
                            _knots.First(k => k.Id == 0).Y++;
                            MoveKnots();
                        }
                        break;
                    case "L":

                        for (var i = 0; i < spaces; i++)
                        {
                            _knots.First(k => k.Id == 0).X--;
                            MoveKnots();
                        }
                        break;
                    case "D":

                        for (var i = 0; i < spaces; i++)
                        {
                            _knots.First(k => k.Id == 0).Y--;
                            MoveKnots();
                        }
                        break;
                    default:
                        throw new Exception("OOPS");
                }
            }

            return _visited.Count;
        }

        private void MoveKnots()
        {
            for (var i = 1; i < 10; i++)
            {
                Move(i);
            }
        }

        private void Move(int i)
        {
            var knot = _knots.First(x => x.Id == i);
            var head = _knots.First(x => x.Id == i - 1);
            if (Math.Abs(knot.X - head.X) > 1 || Math.Abs(knot.Y - head.Y) > 1)
            {
                if (knot.X == head.X)
                {
                    if (knot.Y - head.Y > 0)
                    {
                        knot.Y--;
                    }
                    else
                    {
                        knot.Y++;
                    }
                } else if (knot.Y == head.Y)
                {
                    if (knot.X - head.X > 0)
                    {
                        knot.X--;
                    }
                    else
                    {
                        knot.X++;
                    }
                } else if (knot.X - head.X > 0)
                {
                    knot.X--;
                    if (knot.Y - head.Y > 0)
                    {
                        knot.Y--;
                    }
                    else
                    {
                        knot.Y++;
                    }
                }
                else 
                {
                    knot.X++;
                    if (knot.Y - head.Y > 0)
                    {
                        knot.Y--;
                    }
                    else
                    {
                        knot.Y++;
                    }
                }

                if (i == 9)
                {
                    _visited.Add($"{knot.X}-{knot.Y}");
                }
            }
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            return 0;
        }

    }
}

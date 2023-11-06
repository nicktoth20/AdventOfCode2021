using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day10
    {
        private Parser _parser;
        private int _x = 1;
        private int _cycle = 0;
        private Dictionary<int, int> _results = new Dictionary<int, int>();
        private List<bool> _screen = new List<bool>(240);

        public Day10()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            foreach (var line in lines)
            {
                if (line == "noop")
                {
                    _cycle++;
                    CheckCycle();
                    continue;
                }

                _cycle++;
                CheckCycle();
                var parts = line.Split(' ');
                _x += int.Parse(parts[1]);
                _cycle++;
                CheckCycle();
            }

            var problemResults = 0;

            foreach (var result in _results)
            {
                problemResults += result.Value * result.Key;
            }

            return problemResults;
        }

        private void CheckCycle()
        {
            switch (_cycle)
            {
                case 20:
                case 60:
                case 100:
                case 140:
                case 180:
                case 220:
                    _results.Add(_cycle, _x);
                    break;

            }
        }


        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            for (int i = 0; i < 240; i++)
            {
                _screen.Add(false);
            }

            foreach (var line in lines)
            {
                if (line == "noop")
                {
                    WritePixel();
                    _cycle++;
                    continue;
                }

                WritePixel();
                _cycle++;
                WritePixel();
                var parts = line.Split(' ');
                _x += int.Parse(parts[1]);
                _cycle++;
            }

            for (int i = 0; i < 240; i++)
            {
                var character = _screen[i] ? '#' : '.';
                Debug.Write(character);
                var s = i;
                if (i != 0 && s % 39 == 0)
                {
                    Debug.WriteLine("");
                }

            }

            return 0;
        }

        private void WritePixel()
        {
            var cycle = _cycle -  (_cycle / 40 * 40);
            if (Math.Abs(cycle - _x) < 2)
            {
                _screen[_cycle] = true;
            }
        }
    }
}

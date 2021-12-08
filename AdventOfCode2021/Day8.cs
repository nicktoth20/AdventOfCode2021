using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day8
    {
        private Parser _parser;

        public Day8()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            var result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(" | ");
                foreach (var display in parts[1].Split(' '))
                {
                    if (display.Length == 2 || display.Length == 3 || display.Length == 4 || display.Length == 7)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            var result = 0;

            foreach (var line in lines)
            {
                var segmentResults = FigureOutSegment(line);

                var parts = line.Split(" | ");

                var display = parts[1].Split(' ').Select(x => string.Concat(x.OrderBy(p => p))).ToArray();
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(segmentResults.First(x => x.Value == display[0]).Key);
                stringBuilder.Append(segmentResults.First(x => x.Value == display[1]).Key);
                stringBuilder.Append(segmentResults.First(x => x.Value == display[2]).Key);
                stringBuilder.Append(segmentResults.First(x => x.Value == display[3]).Key);
                result += int.Parse(stringBuilder.ToString());
            }

            return result;
        }

        private Dictionary<int, string> FigureOutSegment(string line)
        {
            var result = new Dictionary<int, string>();
            var parts = line.Split(" | ");
            var inputs = parts[0].Split(' ');

            result[1] = string.Concat(inputs.First(p => p.Length == 2).OrderBy(p => p));
            result[4] = string.Concat(inputs.First(p => p.Length == 4).OrderBy(p => p));
            result[7] = string.Concat(inputs.First(p => p.Length == 3).OrderBy(p => p));
            result[8] = string.Concat(inputs.First(p => p.Length == 7).OrderBy(p => p));


            result[6] = DetermineSix(result, inputs);
            result[3] = DetermineThree(result, inputs);
            result[5] = DetermineFive(result, inputs);
            result[2] = DetermineTwo(result, inputs);
            result[9] = DetermineNine(result, inputs);
            result[0] = DetermineZero(result, inputs);
            return result;
        }

        private string DetermineZero(Dictionary<int, string> results, string[] inputs)
        {
            var possibilities = inputs.Where(i => i.Length == 6).Select(x => string.Concat(x.OrderBy(p => p)));
            return possibilities.First(p => p != results[6] && p != results[9]);
        }

        private string DetermineTwo(Dictionary<int, string> results, string[] inputs)
        {
            var possibilities = inputs.Where(i => i.Length == 5).Select(x => string.Concat(x.OrderBy(p => p)));
            return possibilities.First(p => p != results[3] && p != results[5]);
        }

        private string DetermineThree(Dictionary<int, string> results, string[] inputs)
        {
            var possibilities = inputs.Where(i => i.Length == 5).Select(x => string.Concat(x.OrderBy(p => p)));
            return possibilities.First(p => results[7].All(p.Contains));
        }

        private string DetermineFive(Dictionary<int, string> results, string[] inputs)
        {
            var possibilities = inputs.Where(i => i.Length == 5).Select(x => string.Concat(x.OrderBy(p => p)));
            possibilities = possibilities.Where(p => p != results[3]);
            return possibilities.First(p => p.All(results[6].Contains));
        }

        private string DetermineSix(Dictionary<int, string> results, string[] inputs)
        {
            var possibilities = inputs.Where(i => i.Length == 6).Select(x => string.Concat(x.OrderBy(p => p)));
            return possibilities.First(p => !results[7].All(p.Contains));
        }

        private string DetermineNine(Dictionary<int, string> results, string[] inputs)
        {
            var possibilities = inputs.Where(i => i.Length == 6).Select(x => string.Concat(x.OrderBy(p => p)));
            possibilities = possibilities.Where(p => p != results[6]);
            return possibilities.First(p => results[4].All(p.Contains));
        }
    }
}

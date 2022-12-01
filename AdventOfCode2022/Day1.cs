using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day1
    {
        private Parser _parser;

        public Day1()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var elf = 1;
            var elves = new Dictionary<int, int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elf++;
                }
                else
                {
                    if (elves.ContainsKey(elf))
                    {
                        elves[elf] = elves[elf] + int.Parse(line);
                    }
                    else
                    {
                        elves.Add(elf, int.Parse(line));
                    }
                }
            }

            return elves.Values.Max();
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var elf = 1;
            var elves = new Dictionary<int, int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elf++;
                }
                else
                {
                    if (elves.ContainsKey(elf))
                    {
                        elves[elf] = elves[elf] + int.Parse(line);
                    }
                    else
                    {
                        elves.Add(elf, int.Parse(line));
                    }
                }
            }

            var h = elves.OrderByDescending(x => x.Value).ToList();
            return h[0].Value + h[1].Value + h[2].Value;
        }
    }
}

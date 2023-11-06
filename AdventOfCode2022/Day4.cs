using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class ElfDuty
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Day4
    {
        private Parser _parser;

        public Day4()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var elves = new List<ElfDuty>();
            var lines = _parser.ParseLines(fileName).ToList();

            var result = 0;
            foreach (var line in lines)
            {
                var sections = line.Split(',');
                var firstParts = sections[0].Split('-');
                var secondParts = sections[1].Split('-');

                var test1 = new ElfDuty { Max = int.Parse(firstParts[1]), Min = int.Parse(firstParts[0]) };
                var test2 = new ElfDuty { Max = int.Parse(secondParts[1]), Min = int.Parse(secondParts[0]) };
                if (test1.Min >= test2.Min && test1.Max <= test2.Max || test2.Min >= test1.Min && test2.Max <= test1.Max)
                {
                    result++;
                }
            }

            return result;
        }

        public int ExecutePart2(string fileName)
        {
            var elves = new List<ElfDuty>();
            var lines = _parser.ParseLines(fileName).ToList();

            var result = 0;
            foreach (var line in lines)
            {
                var sections = line.Split(',');
                var firstParts = sections[0].Split('-');
                var secondParts = sections[1].Split('-');

                var test1 = new ElfDuty { Max = int.Parse(firstParts[1]), Min = int.Parse(firstParts[0]) };
                var test2 = new ElfDuty { Max = int.Parse(secondParts[1]), Min = int.Parse(secondParts[0]) };
                if (
                    test1.Min >= test2.Min && test1.Min <= test2.Max ||
                    test1.Max >= test2.Min && test1.Max <= test2.Max ||
                    test2.Min >= test1.Min && test2.Min <= test1.Max ||
                    test2.Max >= test1.Min && test2.Max <= test1.Max)
                {
                    result++;
                }
            }

            return result;
        }
    }
}

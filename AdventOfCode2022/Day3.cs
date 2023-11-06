using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day3
    {
        private Parser _parser;

        public Day3()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var result = 0;
            foreach (var line in lines)
            {
                var first = line.Substring(0, line.Length / 2);
                var hash = new HashSet<char>();
                foreach (var character in first)
                {
                    hash.Add(character);
                }

                var last = line.Substring(line.Length / 2, line.Length / 2);
                var keepGoing = true;
                var index = 0;
                do
                {
                    var character = last[index];
                    if (hash.Contains(character))
                    {
                        result += GetValue(character);
                        keepGoing = false;
                    }

                    index++;
                } while (keepGoing);
            }

            return result;
        }

        public int GetValue(char character)
        {
            var intVal = (int)character;
            if (intVal < 91)
            {
                return intVal - 38;
            }
            return intVal - 96;
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var result = 0;
            for (var i = 0; i < lines.Count; i += 3)
            {
                var hash = new Dictionary<char, int>();
                foreach (var character in lines[i])
                {
                    if (hash.ContainsKey(character))
                    {
                        continue;
                    }
                    hash.Add(character, 1);
                }
                foreach (var character in lines[i + 1])
                {
                    if (!hash.ContainsKey(character) || hash[character] == 2)
                    {
                        continue;
                    }

                    hash[character] += 1;
                }
                foreach (var character in lines[i + 2])
                {
                    if (!hash.ContainsKey(character) || hash[character] != 2 )
                    {
                        continue;
                    }

                    hash[character] += 1;
                }
                result += GetValue(hash.First(h => h.Value == 3).Key);
            }

            return result;
        }
    }
}

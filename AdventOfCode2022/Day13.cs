using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day13
    {

        private Parser _parser;

        public Day13()
        {
            _parser = new Parser();
        }

        public long ExecutePart1(string fileName, int executionTimes = 20, bool partTwo = false)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            for (int i = 0; i < lines.Count; i += 3)
            {
                var first = lines[i];
                var second = lines[i + 1];



                var firstLists = ParseLists(first);
                var secondLists = ParseLists(second);
            }

            return 0;
        }

        private bool IsValid(string left, string right, int leftIndex, int rightIndex)
        {
            if (char.IsDigit(left[leftIndex]) && char.IsDigit(right[rightIndex]))
            {
                var leftEndDigit = left.IndexOf(',', leftIndex);
                var firstDigit= int.Parse(left.Substring(leftIndex, leftEndDigit - leftIndex));


                var rightEndDigit = right.IndexOf(',', rightIndex);
                var secondDigit = int.Parse(right.Substring(rightIndex, rightEndDigit - rightIndex));
                if (firstDigit < secondDigit)
                {
                    return true;
                }
                if (secondDigit > firstDigit)
                {
                    return false;
                }

                return IsValid(left, right, leftEndDigit, rightEndDigit);
            }

            if (!char.IsDigit(left[leftIndex]) && !char.IsDigit(right[rightIndex]))
            {
                return IsValid(left, right, leftIndex++, rightIndex++);
            }

            if (char.IsDigit(left[leftIndex]))
            {

            }

            return false;
        }

        private Queue<List<int>> ParseLists(string line)
        {
            var result = new Queue<List<int>>();
            if (line.Length <= 2)
            {
                return result;
            }

            do
            {
                var startIndex = line.LastIndexOf('[');
                var endIndex = line.IndexOf(']', startIndex);
                var listString = line.Substring(startIndex + 1, endIndex - startIndex - 1);
                var values = listString.Split(',');
                result.Enqueue(values.Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList());
                line = line.Remove(startIndex, endIndex - startIndex + 1);
            } while (line.Any(char.IsDigit));
            
            return result;
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            return 0;
        }
    }
}

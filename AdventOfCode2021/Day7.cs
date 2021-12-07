using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day7
    {
        private Parser _parser;

        public Day7()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            var numbers = lines.First().Split(',').Select(int.Parse).ToList();

            var min = numbers.Min();

            var notFound = true;
            var previous = int.MaxValue;
            do
            {
                var totalForPosition = GetResultForPosition(numbers, min);
                if (totalForPosition < previous)
                {
                    previous = totalForPosition;
                }
                else
                {
                    notFound = false;
                }
                min++;
            } while (notFound);

            return previous;
        }

        private int GetResultForPosition(IList<int> numbers, int position)
        {
            return numbers.Sum(number => Math.Abs(position - number));
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            var numbers = lines.First().Split(',').Select(int.Parse).ToList();

            var min = numbers.Min();

            var notFound = true;
            var previous = int.MaxValue;
            do
            {
                var totalForPosition = GetResultForPosition2(numbers, min);
                if (totalForPosition < previous)
                {
                    previous = totalForPosition;
                }
                else
                {
                    notFound = false;
                }
                min++;
            } while (notFound);

            return previous;
        }

        private int GetResultForPosition2(IList<int> numbers, int position)
        {
            return numbers.Sum(number => GetResultForNumberInPart2(Math.Abs(position - number)));
        }

        private int GetResultForNumberInPart2(int difference)
        {
            var count = 0;
            for (var i = difference; i > 0; i--)
            {
                count += i;
            }

            return count;
        }

        public int Testing(int number)
        {
            var count = 0;
            for (var i = number; i > 0; i--)
            {
                count += i;
            }

            return count;
        }
    }
}

using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day8_should_
    {
        [Fact]
        public void Example1()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart1("Input/day08Example.txt");
            Assert.Equal(21, result);
        }

        [Fact]
        public void Part1()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart1("Input/day08Input.txt");
            Assert.Equal(1538, result);
        }

        [Fact]
        public void Example2()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart2("Input/day08Example.txt");
            Assert.Equal(8, result);
        }

        [Fact]
        public void Part2()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart2("Input/day08Input.txt");
            Assert.Equal(496125, result);
        }
    }
}
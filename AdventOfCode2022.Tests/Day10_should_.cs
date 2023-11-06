using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day10_should_
    {
        [Fact]
        public void Example1()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart1("Input/day10Example.txt");
            Assert.Equal(13140, result);
        }

        [Fact]
        public void Part1()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart1("Input/day10Input.txt");
            Assert.Equal(15120, result);
        }

        [Fact]
        public void Example2()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart2("Input/day10Example.txt");
            Assert.Equal(36, result);
        }

        [Fact]
        public void Part2()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart2("Input/day10Input.txt");
            Assert.Equal(2478, result);
        }
    }
}
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day9_should_
    {
        [Fact]
        public void Example1()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart1("Input/day09Example.txt");
            Assert.Equal(13, result);
        }

        [Fact]
        public void Part1()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart1("Input/day09Input.txt");
            Assert.Equal(5735, result);
        }

        [Fact]
        public void Example2()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart1("Input/day09Example.txt");
            Assert.Equal(36, result);
        }

        [Fact]
        public void Part2()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart1("Input/day09Input.txt");
            Assert.Equal(2478, result);
        }
    }
}
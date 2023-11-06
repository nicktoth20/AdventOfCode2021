using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day12_should_
    {
        [Fact]
        public void Example1()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Example.txt");
            Assert.Equal(31, result);
        }

        [Fact]
        public void Part1()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Input.txt");
            Assert.Equal(99852, result);
        }

        // 99540 too low

        [Fact]
        public void Example2()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Example.txt", 10000, true);
            Assert.Equal(2713310158, result);
        }

        [Fact]
        public void Part2()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Input.txt", 10000, true);
            Assert.Equal(25935263541, result);
        }
    }
}
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day13_should_
    {
        [Fact]
        public void Example1()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart1("Input/day13Example.txt");
            Assert.Equal(31, result);
        }

        [Fact]
        public void Part1()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart1("Input/day13Input.txt");
            Assert.Equal(99852, result);
        }

        // 99540 too low

        [Fact]
        public void Example2()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart1("Input/day13Example.txt", 10000, true);
            Assert.Equal(2713310158, result);
        }

        [Fact]
        public void Part2()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart1("Input/day13Input.txt", 10000, true);
            Assert.Equal(25935263541, result);
        }
    }
}
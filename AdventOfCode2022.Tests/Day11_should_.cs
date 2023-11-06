using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day11_should_
    {
        [Fact]
        public void Example1()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart1("Input/day11Example.txt");
            //Assert.Equal(10605, result);
        }

        [Fact]
        public void Part1()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart1("Input/day11Input.txt");
            //Assert.Equal(99852, result);
        }

        // 99540 too low

        [Fact]
        public void Example2()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart1("Input/day11Example.txt", 10000, true);
            Assert.Equal(2713310158, result);
        }

        [Fact]
        public void Part2()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart1("Input/day11Input.txt", 10000, true);
            Assert.Equal(25935263541, result);
        }
    }
}
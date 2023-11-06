using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day7_should_
    {
        [Fact]
        public void Example1()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart1("Input/day07Example.txt");
            Assert.Equal(95437, result);
        }

        [Fact]
        public void Part1()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart1("Input/day07Input.txt");
            Assert.Equal(1667443, result);
        }

        [Fact]
        public void Example2()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart2("Input/day07Example.txt");
            Assert.Equal(24933642, result);
        }

        [Fact]
        public void Part2()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart2("Input/day07Input.txt");
            Assert.Equal(8998590, result);
        }
    }
}

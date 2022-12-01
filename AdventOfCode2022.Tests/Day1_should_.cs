using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day1_should_
    {
        [Fact]
        public void Example1()
        {
            var day1 = new Day1();
            var result = day1.ExecutePart1("Input/day01Example.txt");
            Assert.Equal(24000, result);
        }

        [Fact]
        public void ForReal1()
        {
            var day1 = new Day1();
            var result = day1.ExecutePart1("Input/day01Input.txt");
            Assert.Equal(72070, result);
        }

        [Fact]
        public void Example2()
        {
            var day1 = new Day1();
            var result = day1.ExecutePart2("Input/day01Example.txt");
            Assert.Equal(45000, result);
        }

        [Fact]
        public void ForReal2()
        {
            var day1 = new Day1();
            var result = day1.ExecutePart2("Input/day01Input.txt");
            Assert.Equal(211805, result);
        }
    }
}

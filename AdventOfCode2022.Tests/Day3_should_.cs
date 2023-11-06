using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day3_should_
    {
        [Fact]
        public void Example1()
        {
            var day3 = new Day3();
            var result = day3.ExecutePart1("Input/day03Example.txt");
            Assert.Equal(157, result);
        }

        [Fact]
        public void ForReal1()
        {
            var day3 = new Day3();
            var result = day3.ExecutePart1("Input/day03Input.txt");
            Assert.Equal(8053, result);
        }

        [Fact]
        public void Example2()
        {
            var day3 = new Day3();
            var result = day3.ExecutePart2("Input/day03Example.txt");
            Assert.Equal(70, result);
        }

        [Fact]
        public void ForReal2()
        {
            var day3 = new Day3();
            var result = day3.ExecutePart2("Input/day03Input.txt");
            Assert.Equal(2425, result);
        }
    }
}

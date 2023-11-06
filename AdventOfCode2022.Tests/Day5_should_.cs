using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day5_should_
    {
        [Fact]
        public void Example1()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart1("Input/day05Example.txt");
            Assert.Equal("CMZ", result);
        }

        [Fact]
        public void ForReal1()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart1("Input/day05Input.txt");
            Assert.Equal("TDCHVHJTG", result);
        }

        [Fact]
        public void Example2()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart2("Input/day05Example.txt");
            Assert.Equal("MCD", result);
        }

        [Fact]
        public void ForReal2()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart2("Input/day05Input.txt");
            Assert.Equal("NGCMPJLHV", result);
        }
    }
}

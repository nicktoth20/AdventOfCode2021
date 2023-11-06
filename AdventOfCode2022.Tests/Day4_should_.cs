using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day4_should_
    {
        [Fact]
        public void Example1()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart1("Input/day04Example.txt");
            Assert.Equal(2, result);
        }

        [Fact]
        public void ForReal1()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart1("Input/day04Input.txt");
            Assert.Equal(582, result);
        }

        [Fact]
        public void Example2()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart2("Input/day04Example.txt");
            Assert.Equal(4, result);
        }

        [Fact]
        public void ForReal2()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart2("Input/day04Input.txt");
            Assert.Equal(893, result);
        }
    }
}

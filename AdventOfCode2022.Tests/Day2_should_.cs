using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day2_should_
    {
        [Fact]
        public void Example1()
        {
            var day2 = new Day2();
            var result = day2.ExecutePart1("Input/day02Example.txt");
            Assert.Equal(15, result);
        }

        [Fact]
        public void ForReal1()
        {
            var day2 = new Day2();
            var result = day2.ExecutePart1("Input/day02Input.txt");
            Assert.Equal(13565, result);
        }

        [Fact]
        public void Example2()
        {
            var day2 = new Day2();
            var result = day2.ExecutePart2("Input/day02Example.txt");
            Assert.Equal(12, result);
        }

        [Fact]
        public void ForReal2()
        {
            var day2 = new Day2();
            var result = day2.ExecutePart2("Input/day02Input.txt");
            Assert.Equal(12424, result);
        }
    }
}

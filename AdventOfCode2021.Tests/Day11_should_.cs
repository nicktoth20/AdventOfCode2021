using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day11_should_
    {
        [Test]
        public void Test1()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart1("Input/day11Example.txt");
            Assert.AreEqual(1656, result);
        }

        [Test]
        public void Test2()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart1("Input/day11Input.txt");
            Assert.AreEqual(1656, result);
        }

        [Test]
        public void Test3()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart2("Input/day11Example.txt");
            Assert.AreEqual(195, result);
        }

        [Test]
        public void Test4()
        {
            var day11 = new Day11();
            var result = day11.ExecutePart2("Input/day11Input.txt");
            Assert.AreEqual(195, result);
        }
    }
}

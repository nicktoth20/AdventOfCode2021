using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day5_should_
    {
        [Test]
        public void Test1()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart1("Input/day05Example.txt");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Test2()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart1("Input/day05Input.txt");
            Assert.AreEqual(7318, result);
        }

        [Test]
        public void Test3()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart1("Input/day05Example.txt");
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Test4()
        {
            var day5 = new Day5();
            var result = day5.ExecutePart1("Input/day05Input.txt");
            Assert.AreEqual(7318, result);
        }
    }
}
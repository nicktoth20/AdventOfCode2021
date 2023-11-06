using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day16_should_
    {
        [Test]
        public void Test1()
        {
            var day16 = new Day16();
            var result = day16.ExecutePart1("Input/day16Example.txt");
            Assert.AreEqual(16, result);
        }

        [Test]
        public void Test2()
        {
            var day16 = new Day16();
            var result = day16.ExecutePart1("Input/day16Example2.txt");
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Test3()
        {
            var day16 = new Day16();
            var result = day16.ExecutePart1("Input/day16Example3.txt");
            Assert.AreEqual(23, result);
        }
    }
}

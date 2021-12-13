using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day13_should_
    {
        [Test]
        public void Test1()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart1("Input/day13Example.txt");
            Assert.AreEqual(17, result);
        }

        [Test]
        public void Test2()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart1("Input/day13Input.txt");
            Assert.AreEqual(17, result);
        }

        [Test]
        public void Test3()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart2("Input/day13Example.txt");
            Assert.AreEqual(17, result);
        }

        [Test]
        public void Test4()
        {
            var day13 = new Day13();
            var result = day13.ExecutePart2("Input/day13Input.txt");
            Assert.AreEqual(17, result);
        }
    }
}

using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day8_should_
    {
        [Test]
        public void Test1()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart1("Input/day08Example.txt");
            Assert.AreEqual(26, result);
        }

        [Test]
        public void Test2()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart1("Input/day08Input.txt");
            Assert.AreEqual(445, result);
        }

        [Test]
        public void Test3()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart2("Input/day08Example.txt");
            Assert.AreEqual(61229, result);
        }

        [Test]
        public void Test4()
        {
            var day8 = new Day8();
            var result = day8.ExecutePart2("Input/day08Input.txt");
            Assert.AreEqual(1043101, result);
        }
    }
}

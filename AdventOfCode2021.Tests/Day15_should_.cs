using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day15_should_
    {
        [Test]
        public void Test1()
        {
            var day15 = new Day15();
            var result = day15.ExecutePart1("Input/day15Example.txt");
            Assert.AreEqual(40, result);
        }

        [Test]
        public void Test2()
        {
            var day15 = new Day15();
            var result = day15.ExecutePart1("Input/day15Input.txt");
            Assert.AreEqual(40, result);
        }

        [Test]
        public void Test3()
        {
            var day15 = new Day15();
            var result = day15.ExecutePart2("Input/day15Example.txt");
            Assert.AreEqual(315, result);
        }

        [Test]
        public void Test4()
        {
            var day15 = new Day15();
            var result = day15.ExecutePart2("Input/day15Input.txt");
            Assert.AreEqual(40, result);
        }
    }
}

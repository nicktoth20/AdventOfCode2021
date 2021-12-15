using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day14_should_
    {
        [Test]
        public void Test1()
        {
            var day14 = new Day14();
            var result = day14.ExecutePart1("Input/day14Example.txt", 10);
            Assert.AreEqual(1588, result);
        }

        [Test]
        public void Test2()
        {
            var day14 = new Day14();
            var result = day14.ExecutePart1("Input/day14Input.txt", 10);
            Assert.AreEqual(3143, result);
        }

        [Test]
        public void Test3()
        {
            var day14 = new Day14();
            var result = day14.ExecutePart2("Input/day14Example.txt", 40);
            Assert.AreEqual(2188189693529, result);
        }

        [Test]
        public void Test4()
        {
            var day14 = new Day14();
            var result = day14.ExecutePart2("Input/day14Input.txt", 40);
            Assert.AreEqual(2188189693529, result);
        }
    }
}

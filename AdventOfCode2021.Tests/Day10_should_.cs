using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day10_should_
    {
        [Test]
        public void Test1()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart1("Input/day10Example.txt");
            Assert.AreEqual(26397, result);
        }

        [Test]
        public void Test2()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart1("Input/day10Input.txt");
            Assert.AreEqual(415953, result);
        }

        [Test]
        public void Test3()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart1("Input/day10Example.txt");
            Assert.AreEqual(288957, result);
        }

        [Test]
        public void Test4()
        {
            var day10 = new Day10();
            var result = day10.ExecutePart1("Input/day10Input.txt");
            Assert.AreEqual(2292863731, result);
        }

        // 162764112 not right
    }
}

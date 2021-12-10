using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day9_should_
    {
        [Test]
        public void Test1()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart1("Input/day09Example.txt");
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Test2()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart1("Input/day09Input.txt");
            Assert.AreEqual(530, result);
        }

        [Test]
        public void Test3()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart2("Input/day09Example.txt");
            Assert.AreEqual(1134, result);
        }

        [Test]
        public void Test4()
        {
            var day9 = new Day9();
            var result = day9.ExecutePart2("Input/day09Input.txt");
            Assert.AreEqual(530, result);
        }
    }
}

// 376272 too low
// 558009 too low
// 847210 too low

using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day12_should_
    {
        [Test]
        public void Test1()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Example.txt");
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Test2()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Example2.txt");
            Assert.AreEqual(19, result);
        }

        [Test]
        public void Test3()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Example3.txt");
            Assert.AreEqual(226, result);
        }

        [Test]
        public void Test4()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart1("Input/day12Input.txt");
            Assert.AreEqual(4378, result);
        }

        [Test]
        public void Test5()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart2("Input/day12Example.txt");
            Assert.AreEqual(36, result);
        }

        [Test]
        public void Test6()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart2("Input/day12Example2.txt");
            Assert.AreEqual(103, result);
        }

        [Test]
        public void Test7()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart2("Input/day12Example3.txt");
            Assert.AreEqual(3509, result);
        }

        [Test]
        public void Test8()
        {
            var day12 = new Day12();
            var result = day12.ExecutePart2("Input/day12Input.txt");
            Assert.AreEqual(133621, result);
        }
    }
}

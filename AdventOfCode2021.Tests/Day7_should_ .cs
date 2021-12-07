using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day7_should_
    {
        [Test]
        public void Test1()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart1("Input/day07Example.txt");
            Assert.AreEqual(37, result);
        }

        [Test]
        public void Test2()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart1("Input/day07Input.txt");
            Assert.AreEqual(37, result);
        }

        [Test]
        public void Test3()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart2("Input/day07Example.txt");
            Assert.AreEqual(168, result);
        }

        [Test]
        public void Test4()
        {
            var day7 = new Day7();
            var result = day7.ExecutePart2("Input/day07Input.txt");
            Assert.AreEqual(37, result);
        }
    }
}

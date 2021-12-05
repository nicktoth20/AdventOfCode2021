using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day4_should_
    {
        [Test]
        public void Test1()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart1("Input/day04Example.txt");
            Assert.AreEqual(4512, result);
        }

        [Test]
        public void Test2()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart1("Input/day04Input.txt");
            Assert.AreEqual(33462, result);
        }

        [Test]
        public void Test3()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart2("Input/day04Example.txt");
            Assert.AreEqual(1924, result);
        }

        [Test]
        public void Test4()
        {
            var day4 = new Day4();
            var result = day4.ExecutePart2("Input/day04Input.txt");
            Assert.AreEqual(30070, result);
        }
    }
}

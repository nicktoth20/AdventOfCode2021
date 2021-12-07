using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    class Day6_should_
    {
        [Test]
        public void Test1()
        {
            var day6 = new Day6();
            var result = day6.ExecutePart1("Input/day06Example.txt", 18);
            Assert.AreEqual(26, result);
        }

        [Test]
        public void Test2()
        {
            var day6 = new Day6();
            var result = day6.ExecutePart1("Input/day06Example.txt", 80);
            Assert.AreEqual(5934, result);
        }

        [Test]
        public void Test3()
        {
            var day6 = new Day6();
            var result = day6.ExecutePart1("Input/day06Input.txt", 80);
            Assert.AreEqual(351188, result);
        }

        [Test]
        public void Test4()
        {
            var day6 = new Day6();
            var result = day6.ExecutePart1("Input/day06Example.txt", 256);
            Assert.AreEqual(26984457539, result);
        }

        [Test]
        public void Test5()
        {
            var day6 = new Day6();
            var result = day6.ExecutePart1("Input/day06Input.txt", 256);
            Assert.AreEqual(1595779846729, result);
        }
    }
}

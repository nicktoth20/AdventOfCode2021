using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day3Tests
{
    [TestCase(">", 2)]
    [TestCase("^>v<", 4)]
    [TestCase("^v^v^v^v^v", 2)]
    public void Test1(string input, int expected)
    {
        var day3 = new Day3(new SingleLineInputParser());
        day3.ExecutePart1(input).Should().Be(expected);
    }

    [Test]
    public void Part1()
    {
        var day3 = new Day3();
        var result = day3.ExecutePart1("Input/day03Input.txt");
        result.Should().Be(2572);
    }
}
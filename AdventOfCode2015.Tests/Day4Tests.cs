using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day4Tests
{
    [TestCase("abcdef", 609043)]
    [TestCase("pqrstuv", 1048970)]
    public void Test1(string input, long expected)
    {
        var day4 = new Day4(new SingleLineInputParser());
        day4.ExecutePart1(input).Should().Be(expected);
    }

    [Test]
    public void Part1()
    {
        var day4 = new Day4(new SingleLineInputParser());
        var result = day4.ExecutePart1("bgvyzdsv");
        result.Should().Be(254575);
    }

    [Test]
    public void Part2()
    {
        var day4 = new Day4(new SingleLineInputParser());
        var result = day4.ExecutePart2("bgvyzdsv");
        result.Should().Be(1038736);
    }
}
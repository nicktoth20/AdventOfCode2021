using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day2Tests
{
    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void Test1(string input, int expected)
    {
        var day2 = new Day2(new SingleLineInputParser());
        day2.ExecutePart1(input).Should().Be(expected);
    }

    [Test]
    public void Part1()
    {
        var day2 = new Day2();
        var result = day2.ExecutePart1("Input/day02Input.txt");
        result.Should().Be(1586300);
    }
    
    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void Test2(string input, int expected)
    {
        var day2 = new Day2(new SingleLineInputParser());
        day2.ExecutePart2(input).Should().Be(expected);
    }

    [Test]
    public void Test3()
    {
        var day2 = new Day2();
        var result = day2.ExecutePart2("Input/day02Example.txt");
        result.Should().Be(48);
    }

    [Test]
    public void Part2()
    {
        var day2 = new Day2();
        var result = day2.ExecutePart2("Input/day02Input.txt");
        result.Should().Be(3737498);
    }
}
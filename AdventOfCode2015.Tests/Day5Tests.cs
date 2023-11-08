using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day5Tests
{
    [TestCase("ugknbfddgicrmopn", 1)]
    [TestCase("aaa", 1)]
    [TestCase("jchzalrnumimnmhp", 0)]
    [TestCase("haegwjzuvuyypxyu", 0)]
    [TestCase("dvszwmarrgswjxmb", 0)]
    public void Test1(string input, long expected)
    {
        var day5 = new Day5(new SingleLineInputParser());
        day5.ExecutePart1(input).Should().Be(expected);
    }

    [Test]
    public void Part1()
    {
        var day5 = new Day5();
        var result = day5.ExecutePart1("Input/day05Input.txt");
        result.Should().Be(238);
    }

    [TestCase("qjhvhtzxzqqjkmpb", 1)]
    [TestCase("xxyxx", 1)]
    [TestCase("uurcxstgmygtbstg", 0)]
    [TestCase("ieodomkazucvgmuy", 0)]
    public void Test2(string input, long expected)
    {
        var day5 = new Day5(new SingleLineInputParser());
        day5.ExecutePart2(input).Should().Be(expected);
    }

    [Test]
    public void Part2()
    {
        var day5 = new Day5();
        var result = day5.ExecutePart2("Input/day05Input.txt");
        result.Should().Be(69);
    }
}
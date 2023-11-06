using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Tests
{
    [TestCase("(())", 0)]
    [TestCase("()()", 0)]
    [TestCase("(((", 3)]
    [TestCase("(()(()(", 3)]
    [TestCase("))(((((", 3)]
    [TestCase("())", -1)]
    [TestCase("))(", -1)]
    [TestCase(")))", -3)]
    [TestCase(")())())", -3)]
    public void Test1(string input, int expected)
    {
        var day1 = new Day1(new SingleLineInputParser());
        day1.ExecutePart1(input).Should().Be(expected);
    }

    [Test]
    public void Part1()
    {
        var day1 = new Day1();
        var result = day1.ExecutePart1("Input/day01Input.txt");
        result.Should().Be(280);
    }
    
    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    public void Test2(string input, int expected)
    {
        var day1 = new Day1(new SingleLineInputParser());
        day1.ExecutePart2(input).Should().Be(expected);
    }

    [Test]
    public void Part2()
    {
        var day1 = new Day1();
        var result = day1.ExecutePart2("Input/day01Input.txt");
        result.Should().Be(1797);
    }
}
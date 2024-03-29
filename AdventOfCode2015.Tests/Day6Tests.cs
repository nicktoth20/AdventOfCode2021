using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day6Tests
{
    [TestCase("turn on 0,0 through 999,999", 1000000)]
    public void Test1(string input, long expected)
    {
        var day6 = new Day6(new SingleLineInputParser());
        day6.ExecutePart1(input).Should().Be(expected);
    }

    [Test]
    public void Test2()
    {
        var day6 = new Day6();
        var result = day6.ExecutePart1("Input/day06Example.txt");
        result.Should().Be(998996);
    }

    [Test]
    public void Part1()
    {
        var day6 = new Day6();
        var result = day6.ExecutePart1("Input/day06Input.txt");
        result.Should().Be(543903); 
    }
    
    [TestCase("turn on 0,0 through 0,0", 1)]
    [TestCase("turn off 0,0 through 0,0", 0)]
    [TestCase("toggle 0,0 through 999,999", 2000000)]
    public void Test3(string input, long expected)
    {
        var day6 = new Day6(new SingleLineInputParser());
        day6.ExecutePart2(input).Should().Be(expected);
    }

    [Test]
    public void Part2()
    {
        var day6 = new Day6();
        var result = day6.ExecutePart2("Input/day06Input.txt");
        result.Should().Be(14687245); 
    }
}
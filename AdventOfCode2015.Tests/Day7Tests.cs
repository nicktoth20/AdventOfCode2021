using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day7Tests
{
    [Test]
    public void Test1()
    {
        var day7 = new Day7();
        var result = day7.ExecutePart1("Input/day07Example.txt","x");
        result.Should().Be(123);
    }

    [Test]
    public void Part1()
    {
        var day7 = new Day7();
        var result = day7.ExecutePart1("Input/day07Input.txt","a");
        result.Should().Be(1); 
    }
    
    [TestCase("turn on 0,0 through 0,0", 1)]
    [TestCase("turn off 0,0 through 0,0", 0)]
    [TestCase("toggle 0,0 through 999,999", 2000000)]
    public void Test3(string input, long expected)
    {
        var day7 = new Day7(new SingleLineInputParser());
        day7.ExecutePart2(input).Should().Be(expected);
    }

    [Test]
    public void Part2()
    {
        var day7 = new Day7();
        var result = day7.ExecutePart2("Input/day06Input.txt");
        result.Should().Be(14687245); 
    }
}
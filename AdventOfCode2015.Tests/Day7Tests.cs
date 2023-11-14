using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day7Tests
{
    [Test]
    public void Test1()
    {
        var day7 = new Day7();
        var result = day7.ExecutePart2("Input/day07Example.txt","x");
        result.Should().Be(123);
    }

    [Test]
    public void Part1()
    {
        var day7 = new Day7();
        var result = day7.ExecutePart2("Input/day07Input.txt","a");
        result.Should().Be(1); 
    }
}
using System.Text.RegularExpressions;
using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day8Tests
{
    [Test]
    public void Test1()
    {
        var day8 = new Day8();
        var result = day8.ExecutePart1("Input/day08Example.txt");
        result.Should().Be(12);
    }

    [Test]
    public void Part1()
    {
        var day8 = new Day8();
        var result = day8.ExecutePart1("Input/day08Input.txt");
        result.Should().Be(1371); 
    }
    
    [Test]
    public void Test2()
    {
        var day8 = new Day8();
        var result = day8.ExecutePart2("Input/day08Example.txt");
        result.Should().Be(19);
    }

    [Test]
    public void Part2()
    {
        var day8 = new Day8();
        var result = day8.ExecutePart2("Input/day08Input.txt");
        result.Should().Be(2117); 
    }
}
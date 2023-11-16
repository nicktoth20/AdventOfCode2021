using System.Text.RegularExpressions;
using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day9Tests
{
    [Test]
    public void Test1()
    {
        var day9 = new Day9();
        var result = day9.ExecutePart1("Input/day09Example.txt");
        result.Should().Be(605);
    }

    [Test]
    public void Part1()
    {
        var day9 = new Day9();
        var result = day9.ExecutePart1("Input/day09Input.txt");
        result.Should().Be(207); 
    }
    
    [Test]
    public void Test2()
    {
        var day9 = new Day9();
        var result = day9.ExecutePart2("Input/day09Example.txt");
        result.Should().Be(982);
    }

    [Test]
    public void Part2()
    {
        var day9 = new Day9();
        var result = day9.ExecutePart2("Input/day09Input.txt");
        result.Should().Be(804); 
    }
}
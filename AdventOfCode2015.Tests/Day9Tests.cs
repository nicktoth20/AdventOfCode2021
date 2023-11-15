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
        result.Should().Be(12);
    }

    [Test]
    public void Part1()
    {
        var day9 = new Day9();
        var result = day9.ExecutePart1("Input/day09Input.txt");
        result.Should().Be(1371); 
    }
}
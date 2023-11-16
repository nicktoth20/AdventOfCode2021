using System.Text.RegularExpressions;
using FluentAssertions;

namespace AdventOfCode2015.Tests;

public class Day10Tests
{
    [Test]
    public void Test1()
    {
        var day10 = new Day10();
        var result = day10.ExecutePart1(4);
        result.Should().Be("312211");
    }

    [Test]
    public void Part1()
    {
        var day10 = new Day10();
        var result = day10.ExecutePart1(40);
        result.Should().Be("207"); 
    }
    
    [Test]
    public void Test2()
    {
        var day10 = new Day10();
        var result = day10.ExecutePart2("Input/day09Example.txt");
        result.Should().Be(982);
    }

    [Test]
    public void Part2()
    {
        var day10 = new Day10();
        var result = day10.ExecutePart2("Input/day09Input.txt");
        result.Should().Be(804); 
    }
}
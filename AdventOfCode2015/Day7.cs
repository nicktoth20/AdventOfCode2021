﻿using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015;

public class Day7
{
    private readonly IParser _parser;

    public Day7() : this(new Parser())
    {
    }

    public Day7(IParser parser)
    {
        _parser = parser;
    }
    
    public ushort ExecutePart1(string filePath, string wire)
    {
        var lines = _parser.ParseLines(filePath);
        var wires = new Dictionary<string, ushort>();
        foreach (var line in lines) {
            if (line.Contains("AND"))
            {
                var parsedValues = line.Split(' ');
                wires[parsedValues[4]] = (ushort)(wires[parsedValues[0]] & wires[parsedValues[2]]);
            }
            else if (line.Contains("OR")) {
                var parsedValues = line.Split(' ');
                wires[parsedValues[4]] = (ushort)(wires[parsedValues[0]] | wires[parsedValues[2]]);
            }
            else if (line.Contains("LSHIFT")) {
                var parsedValues = line.Split(' ');
                wires[parsedValues[4]] = (ushort)(wires[parsedValues[0]] << int.Parse(parsedValues[2]));
            }
            else if (line.Contains("RSHIFT")) {
                var parsedValues = line.Split(' ');
                wires[parsedValues[4]] = (ushort)(wires[parsedValues[0]] >> int.Parse(parsedValues[2]));
            }
            else if (line.Contains("NOT")) {
                var parsedValues = line.Split(' ');
                wires[parsedValues[3]] = (ushort)(~wires[parsedValues[1]]);
            }
            else
            {
                var parsedValues = line.Split(' ');
                wires.Add(parsedValues[2], ushort.Parse(parsedValues[0]));
            }
        }
        return wires[wire];
    }

    public long ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var lights = new int[1000,1000];
        foreach (var line in lines) {
            if (line.StartsWith("turn on")) {
                TurnOn(line, lights);
            }
            if (line.StartsWith("toggle")) {
                Toggle(line, lights);
            }
            if (line.StartsWith("turn off")) {
                TurnOff(line, lights);
            }
        }
        return CountBrightness(lights);
    }

    private static void TurnOn(string input, int[,] lights) {
        var parts = input.Split(' ');
        var first = parts[2].Split(',').Select(x => int.Parse(x)).ToList();
        var second = parts[4].Split(',').Select(x => int.Parse(x)).ToList();
        for(var i = first[0]; i <= second[0]; i++) {
            for(var x = first[1]; x <= second[1]; x++) {
                lights[i, x]++;
            }
        }
    }

    private static void TurnOff(string input, int[,] lights) {
        var parts = input.Split(' ');
        var first = parts[2].Split(',').Select(x => int.Parse(x)).ToList();
        var second = parts[4].Split(',').Select(x => int.Parse(x)).ToList();
        for(var i = first[0]; i <= second[0]; i++) {
            for(var x = first[1]; x <= second[1]; x++) {
                if (lights[i, x] > 0) lights[i, x]--;
            }
        }
    }

    private static void Toggle(string input, int[,] lights) {
        var parts = input.Split(' ');
        var first = parts[1].Split(',').Select(int.Parse).ToList();
        var second = parts[3].Split(',').Select(int.Parse).ToList();
        for(var i = first[0]; i <= second[0]; i++) {
            for(var x = first[1]; x <= second[1]; x++) {
                lights[i, x] += 2;
            }
        }
    }
    
    private static long CountBrightness(int[,] lights) {
        var count = 0;
        for(var i = 0; i < 1000; i++) {
            for(var x = 0; x < 1000; x++) {
                count += lights[i, x];
            }
        }
        return count;
    }
}
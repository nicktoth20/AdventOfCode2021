using System.Security.Cryptography;
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

    public ushort ExecutePart2(string filePath, string wire)
    {
        var lines = _parser.ParseLines(filePath);
        var instructions = new Dictionary<string, string>();
        foreach (var line in lines) {
            if (line.Contains("AND"))
            {
                var parsedValues = line.Split(' ');
                instructions[parsedValues[4]] = line.Split("->")[0];
            }
            else if (line.Contains("OR")) {
                var parsedValues = line.Split(' ');
                instructions[parsedValues[4]] = line.Split("->")[0];
            }
            else if (line.Contains("LSHIFT")) {
                var parsedValues = line.Split(' ');
                instructions[parsedValues[4]]  = line.Split("->")[0];
            }
            else if (line.Contains("RSHIFT")) {
                var parsedValues = line.Split(' ');
                instructions[parsedValues[4]]  = line.Split("->")[0];
            }
            else if (line.Contains("NOT")) {
                var parsedValues = line.Split(' ');
                instructions[parsedValues[3]]  = line.Split("->")[0];
            }
            else
            {
                var parsedValues = line.Split(' ');
                instructions.Add(parsedValues[2], parsedValues[0]);
            }
        }
        return FindValue(wire, instructions);
    }

    public ushort FindValue(string  wire, Dictionary<string, string> dict) {
        if (ushort.TryParse(wire, out var ushortValue)) {
            return ushortValue;
        }

        var instruction = dict[wire];
        if (instruction.Contains("AND"))
        {
            var parsedValues = instruction.Split(' ');
            return (ushort)(FindValue(parsedValues[0], dict) & FindValue(parsedValues[2], dict));
        }
        else if (instruction.Contains("OR")) {
            var parsedValues = instruction.Split(' ');
            return (ushort)(FindValue(parsedValues[0], dict) | FindValue(parsedValues[2], dict));
        }
        else if (instruction.Contains("LSHIFT")) {
            var parsedValues = instruction.Split(' ');
            return (ushort)(FindValue(parsedValues[0], dict) << int.Parse(parsedValues[2]));
        }
        else if (instruction.Contains("RSHIFT")) {
            var parsedValues = instruction.Split(' ');
            return (ushort)(FindValue(parsedValues[0], dict) >> int.Parse(parsedValues[2]));
        }
        else if (instruction.Contains("NOT")) {
            var parsedValues = instruction.Split(' ');
            return (ushort)(~FindValue(parsedValues[1], dict));
        }
        else
        {
            var parsedValues = instruction.Split(' ');
            var result =  ushort.TryParse(parsedValues[0], out var parsedValue);
            if (result) return parsedValue;
            return FindValue(parsedValues[0], dict);
        }
    }
}
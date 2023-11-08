using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015;

public class Day6
{
    private readonly IParser _parser;

    public Day6() : this(new Parser())
    {
    }

    public Day6(IParser parser)
    {
        _parser = parser;
    }
    
    public long ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var lights = new bool[1000,1000];
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
        return CountLightsOn(lights);
    }
    
    private static int CountLightsOn(bool[,] lights) {
        var count = 0;
        for(var i = 0; i < 1000; i++) {
            for(var x = 0; x < 1000; x++) {
                if (lights[i, x]) count++;
            }
        }
        return count;
    }

    private static void TurnOn(string input, bool[,] lights) {
        var parts = input.Split(' ');
        var first = parts[2].Split(',').Select(x => int.Parse(x)).ToList();
        var second = parts[4].Split(',').Select(x => int.Parse(x)).ToList();
        for(var i = first[0]; i <= second[0]; i++) {
            for(var x = first[1]; x <= second[1]; x++) {
                lights[i, x] = true;
            }
        }
    }

    private static void TurnOff(string input, bool[,] lights) {
        var parts = input.Split(' ');
        var first = parts[2].Split(',').Select(x => int.Parse(x)).ToList();
        var second = parts[4].Split(',').Select(x => int.Parse(x)).ToList();
        for(var i = first[0]; i <= second[0]; i++) {
            for(var x = first[1]; x <= second[1]; x++) {
                lights[i, x] = false;
            }
        }
    }

    private static void Toggle(string input, bool[,] lights) {
        var parts = input.Split(' ');
        var first = parts[1].Split(',').Select(x => int.Parse(x)).ToList();
        var second = parts[3].Split(',').Select(x => int.Parse(x)).ToList();
        for(var i = first[0]; i <= second[0]; i++) {
            for(var x = first[1]; x <= second[1]; x++) {
                lights[i, x] = !lights[i,x];
            }
        }
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
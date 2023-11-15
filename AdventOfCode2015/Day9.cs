using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015;

public class Day9
{
    private readonly IParser _parser;

    public Day9() : this(new Parser())
    {
    }

    public Day9(IParser parser)
    {
        _parser = parser;
    }

    public class Node
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Distance { get; set; }
    }

    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var totalCities = new HashSet<string>();
        var nodes = new List<Node>();
        var shortestDistance = int.MaxValue;
        foreach (var line in lines)
        {
            var parsed = line.Split(" ");
            totalCities.Add(parsed[0]);
            totalCities.Add(parsed[2]);
            
            nodes.Add(new Node { From = parsed[0], To = parsed[2], Distance = int.Parse(parsed[4]) });
        }

        var startingCities = nodes.Select(z => z.From).Distinct();
        
        foreach (var startingCity in startingCities)
        {
            
        }
        
        return 1;
    }

    private void Travel()
    {
        
    }

    public int ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var charactersOfString = 0;
        var decodeCount = 0;
        foreach (var line in lines) {
            charactersOfString += line.Length;
            var decode = Regex.Escape(line).Replace("\"", @"\""");
            decodeCount += decode.Length;
        }

        decodeCount += lines.Count() * 2;
        return decodeCount - charactersOfString;
    }
}
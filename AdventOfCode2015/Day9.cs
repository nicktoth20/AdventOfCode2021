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


    private HashSet<string> _totalCities = new HashSet<string>();

    private int _shortestDistance = int.MaxValue;
    
    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var nodes = new List<Node>();
        foreach (var line in lines)
        {
            var parsed = line.Split(" ");
            _totalCities.Add(parsed[0]);
            _totalCities.Add(parsed[2]);
            
            nodes.Add(new Node { From = parsed[0], To = parsed[2], Distance = int.Parse(parsed[4]) });
            nodes.Add(new Node { From = parsed[2], To = parsed[0], Distance = int.Parse(parsed[4]) });
        }

        var startingCities = nodes.Select(z => z.From).Distinct();
        
        foreach (var startingCity in startingCities)
        {
            var visitedCities = new HashSet<string>
            {
                startingCity
            };
            Travel(nodes.Where(z => z.From == startingCity).ToList(), visitedCities, 0);
        }
        
        return _shortestDistance;
    }

    private void Travel(List<Node> nodes, HashSet<string> visitedCities, int distance)
    {
        if (visitedCities.Count == _totalCities.Count) {
            if (distance < _shortestDistance) {
                _shortestDistance = distance;
            }
            return;
        }
        foreach (var node in nodes)
        {
            var nextNodes = nodes.Where(z => z.From == node.To && !visitedCities.Contains(node.To)).ToList();
            visitedCities.Add(node.To);
            Travel(nextNodes, visitedCities, distance + node.Distance);
            visitedCities.Remove(node.To);
        }
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
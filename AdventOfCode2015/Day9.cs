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
    private int _longestDistance = 0;
    private List<Node> _nodes = new();
    
    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        foreach (var line in lines)
        {
            var parsed = line.Split(" ");
            _totalCities.Add(parsed[0]);
            _totalCities.Add(parsed[2]);
            
            _nodes.Add(new Node { From = parsed[0], To = parsed[2], Distance = int.Parse(parsed[4]) });
            _nodes.Add(new Node { From = parsed[2], To = parsed[0], Distance = int.Parse(parsed[4]) });
        }

        var startingCities = _nodes.Select(z => z.From).Distinct();
        
        foreach (var startingCity in startingCities)
        {
            var visitedCities = new HashSet<string>
            {
                startingCity
            };
            Travel(_nodes.Where(z => z.From == startingCity).ToList(), visitedCities, 0);
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
            var nextNodes = _nodes.Where(z => z.From == node.To && !visitedCities.Contains(z.To)).ToList();
            visitedCities.Add(node.To);
            Travel(nextNodes, visitedCities, distance + node.Distance);
            visitedCities.Remove(node.To);
        }
    }

    public int ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        foreach (var line in lines)
        {
            var parsed = line.Split(" ");
            _totalCities.Add(parsed[0]);
            _totalCities.Add(parsed[2]);
            
            _nodes.Add(new Node { From = parsed[0], To = parsed[2], Distance = int.Parse(parsed[4]) });
            _nodes.Add(new Node { From = parsed[2], To = parsed[0], Distance = int.Parse(parsed[4]) });
        }

        var startingCities = _nodes.Select(z => z.From).Distinct();
        
        foreach (var startingCity in startingCities)
        {
            var visitedCities = new HashSet<string>
            {
                startingCity
            };
            TravelLongest(_nodes.Where(z => z.From == startingCity).ToList(), visitedCities, 0);
        }
        
        return _longestDistance;
    }

    private void TravelLongest(List<Node> nodes, HashSet<string> visitedCities, int distance)
    {
        if (visitedCities.Count == _totalCities.Count) {
            if (distance > _longestDistance) {
                _longestDistance = distance;
            }
            return;
        }
        foreach (var node in nodes)
        {
            var nextNodes = _nodes.Where(z => z.From == node.To && !visitedCities.Contains(z.To)).ToList();
            visitedCities.Add(node.To);
            TravelLongest(nextNodes, visitedCities, distance + node.Distance);
            visitedCities.Remove(node.To);
        }
    }
}
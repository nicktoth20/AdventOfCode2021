using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day12
    {
        private Parser _parser;
        private IList<Node> _nodes;
        private int _result = 0;
        private StringBuilder _sb = new StringBuilder();

        public Day12()
        {
            _parser = new Parser();
            _nodes = new List<Node>();
        }

        public int ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            foreach (var line in lines)
            {
                var nodes = line.Split('-');

                if (_nodes.All(n => n.Name != nodes[0]))
                {
                    _nodes.Add(new Node(nodes[0]));
                }
                if (_nodes.All(n => n.Name != nodes[1]))
                {
                    _nodes.Add(new Node(nodes[1]));
                }

                _nodes.First(n => n.Name == nodes[0]).AddConnector(_nodes.First(n => n.Name == nodes[1]));
                _nodes.First(n => n.Name == nodes[1]).AddConnector(_nodes.First(n => n.Name == nodes[0]));
            }

            var startingNode = _nodes.First(n => n.Name == "start");
            startingNode.Visit();
            FindEnd(startingNode);
            return _result;
        }

        private void FindEnd(Node node)
        {
            _sb.Append($"{node.Name}-");
            var nodesToVisit = node.NodesToVisit().ToList();
            foreach (var nodeToVisit in nodesToVisit)
            {
                nodeToVisit.Visit();

                if (nodeToVisit.Name == "end")
                {
                    _result++;
                    _sb.Append("end");
                    Debug.WriteLine(_sb.ToString());
                    _sb.Remove(_sb.Length - 3, 3);
                    continue;
                }
                
                FindEnd(nodeToVisit);
                _sb.Remove(_sb.Length - 2, 2);

                foreach (var node1 in nodesToVisit)
                {
                    node1.Reset();
                    _sb.Clear();
                    _sb.Append($"{node.Name},");
                }
            }
        }

        private void FindEnd2(Node node)
        {
            _sb.Append($"{node.Name},");
            List<Node> nodesToVisit;
            if (_nodes.Any(n => n.TimesVisited >= 2))
            {
                nodesToVisit = node.NodesToVisit().Where(n => n.TimesVisited <= 0).ToList();
            }
            else
            {
                nodesToVisit = node.NodesToVisit().Where(n => n.TimesVisited < 2).ToList();
            }
            foreach (var nodeToVisit in nodesToVisit)
            {

                if (_nodes.Any(n => n.TimesVisited == 2))
                {
                    if (nodeToVisit.TimesVisited >= 2)
                    {
                        continue;
                    }
                }
                nodeToVisit.Visit();

                if (nodeToVisit.Name == "end")
                {
                    _result++;
                    _sb.Append("end");
                    //Debug.WriteLine(_sb.ToString());
                    _sb.Remove(_sb.Length - 3, 3);
                    continue;
                }

                FindEnd2(nodeToVisit);
                nodeToVisit.TimesVisited--;
                _sb.Remove(_sb.Length - 2, 2);

                if (node.Name == "start")
                {
                    foreach (var node1 in nodesToVisit)
                    {
                        node1.Reset();
                        _sb.Clear();
                        _sb.Append($"{node.Name},");
                    }
                }
            }
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            foreach (var line in lines)
            {
                var nodes = line.Split('-');

                if (_nodes.All(n => n.Name != nodes[0]))
                {
                    _nodes.Add(new Node(nodes[0]));
                }
                if (_nodes.All(n => n.Name != nodes[1]))
                {
                    _nodes.Add(new Node(nodes[1]));
                }

                _nodes.First(n => n.Name == nodes[0]).AddConnector(_nodes.First(n => n.Name == nodes[1]));
                _nodes.First(n => n.Name == nodes[1]).AddConnector(_nodes.First(n => n.Name == nodes[0]));
            }

            var startingNode = _nodes.First(n => n.Name == "start");
            startingNode.Visit();
            FindEnd2(startingNode);
            return _result;
        }
    }

    public class Node
    {
        private IList<Node> _associatedNodes;
        public string Name { get; set; }
        public bool Visited { get; set; }
        // part 2
        public int TimesVisited = 0;

        public Node(string name)
        {
            Name = name;
            _associatedNodes = new List<Node>();
        }

        public bool CanVisit()
        {
            //return Name.All(char.IsUpper) || !Visited;
            return Name != "start" && (Name.All(char.IsUpper) || TimesVisited < 2);
        }

        public void Visit()
        {
            if (Name == "end" || Name.All(char.IsUpper))
            {
                return;
            }
            TimesVisited++;
            Visited = true;
        }

        public void Reset()
        {
            if (Name == "start")
            {
                return;
            }
            TimesVisited = 0;
            Visited = false;
        }

        public void AddConnector(Node node)
        {
            _associatedNodes.Add(node);
        }

        public IEnumerable<Node> NodesToVisit()
        {
            return _associatedNodes.Where(n => n.CanVisit());
        }
    }
}

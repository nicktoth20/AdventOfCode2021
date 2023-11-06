using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day7
    {
        private Parser _parser;
        private Node _currentNode;
        private Node _root;

        public Day7()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var result = 0;
            var folders = new HashSet<Guid>();
            var sizes = new List<int>();
            var index = 0;

            var lines = _parser.ParseLines(fileName);

            foreach (var line in lines)
            {
                index++;
                if (line == "$ ls")
                {
                    continue;
                }


                if (line == "$ cd /")
                {
                    var node = new Node
                    {
                        Data = new Folder("/")
                    };
                    folders.Add(node.Data.Id);
                    _currentNode = node;
                    _root = node;
                    continue;
                }


                if (line == "$ cd ..")
                {
                    if (_currentNode.Data.Name == "/")
                    {
                        var s = 'a';
                    }
                    var cn = LevelOrderTraversal(_root, _currentNode.Data.Id, true);
                    _currentNode = cn ?? _root;
                    continue;
                }

                if (line.StartsWith("$ cd"))
                {
                    var parts = line.Split(' ');
                    _currentNode = _currentNode.Children.First(c => c.Data.Name == parts[2]);
                }
                else if (line.StartsWith("dir"))
                {
                    var parts = line.Split(' ');
                    var nodeToAdd = new Node { Data = new Folder(parts[1]) };
                    folders.Add(nodeToAdd.Data.Id);
                    _currentNode.AddChild(nodeToAdd);
                }
                else
                {
                    var parts = line.Split(' ');
                    var nodeToAdd = new Node {Data = new File(int.Parse(parts[0]), parts[1])};
                    _currentNode.AddChild(nodeToAdd);
                }
            }

            sizes.Add(_root.GetSize());
            foreach (var folder in folders)
            {
                var node = LevelOrderTraversal(_root, folder);
                var nodeResult = node?.GetSize() ?? 0;
                sizes.Add(nodeResult);
                if (nodeResult <= 100000)
                {
                    result += nodeResult;
                }
            }

            return sizes.Where(s => s <= 100000).Sum();
        }

        public Node? LevelOrderTraversal(Node root, Guid id, bool returnParent = false)
        {
            // Standard level order traversal code using queue
            var queue = new Queue<Node>(); // Create a queue
            queue.Enqueue(root); // Enqueue root
            while (queue.Count != 0)
            {
                var n = queue.Count;

                // If this node has children
                while (n > 0)
                {
                    // Dequeue an item from queue
                    var p = queue.Peek();
                    queue.Dequeue();

                    // Enqueue all children of the dequeued item
                    foreach (var t in p.Children)
                    {
                        queue.Enqueue(t);
                        if (t.Data.Id == id)
                        {
                            return returnParent ? p :  t;
                        }
                    }
                    n--;
                }
            }
            return null;
        }

        public int ExecutePart2(string fileName)
        {
            var result = 0;
            var folders = new HashSet<Guid>();
            var sizes = new List<int>();
            var index = 0;

            var lines = _parser.ParseLines(fileName);

            foreach (var line in lines)
            {
                index++;
                if (line == "$ ls")
                {
                    continue;
                }


                if (line == "$ cd /")
                {
                    var node = new Node
                    {
                        Data = new Folder("/")
                    };
                    folders.Add(node.Data.Id);
                    _currentNode = node;
                    _root = node;
                    continue;
                }


                if (line == "$ cd ..")
                {
                    if (_currentNode.Data.Name == "/")
                    {
                        var s = 'a';
                    }
                    var cn = LevelOrderTraversal(_root, _currentNode.Data.Id, true);
                    _currentNode = cn ?? _root;
                    continue;
                }

                if (line.StartsWith("$ cd"))
                {
                    var parts = line.Split(' ');
                    _currentNode = _currentNode.Children.First(c => c.Data.Name == parts[2]);
                }
                else if (line.StartsWith("dir"))
                {
                    var parts = line.Split(' ');
                    var nodeToAdd = new Node { Data = new Folder(parts[1]) };
                    folders.Add(nodeToAdd.Data.Id);
                    _currentNode.AddChild(nodeToAdd);
                }
                else
                {
                    var parts = line.Split(' ');
                    var nodeToAdd = new Node { Data = new File(int.Parse(parts[0]), parts[1]) };
                    _currentNode.AddChild(nodeToAdd);
                }
            }

            sizes.Add(_root.GetSize());
            foreach (var folder in folders)
            {
                var node = LevelOrderTraversal(_root, folder);
                var nodeResult = node?.GetSize() ?? 0;
                sizes.Add(nodeResult);
                if (nodeResult <= 100000)
                {
                    result += nodeResult;
                }
            }

            var sizeNeeded = sizes[0] - 40000000;
            var possibilities = sizes.Where(s => s >= sizeNeeded);
            return possibilities.Min();
        }

        public abstract class Asset
        {
            public Guid Id { get; set; }
            public AssetType Type { get; set; }
            public int Size { get; set; }
            public string Name { get; set; }
        }

        public class Folder : Asset
        {
            public Folder(string name)
            {
                Id = Guid.NewGuid();
                Type = AssetType.Folder;
                Size = 0;
                Name = name;
            }
        }

        public class File : Asset
        {
            public File(int size, string name)
            {
                Id = Guid.NewGuid();
                Type = AssetType.File;
                Size = size;
                Name = name;
            }
        }

        public enum AssetType
        {
            File,
            Folder
        }

        public class Node
        {
            public List<Node> Children = new List<Node>();

            public Asset Data { get; set; }

            public void AddChild(Node child)
            {
                Children.Add(child);
            }

            public int GetSize()
            {
                return GetSize(this);
            }

            private int GetSize(Node node)
            {
                var result = 0;
                foreach (var child in node.Children)
                {
                    if (child.Data.Type == AssetType.File)
                    {
                        result += child.Data.Size;
                    }

                    result += GetSize(child);
                }

                return result;
            }
        }
    }
}

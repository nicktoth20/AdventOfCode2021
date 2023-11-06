using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day5
    {
        public class Instruction
        {
            public int NumberOfContainersToMove { get; set; }
            public int From { get; set; }
            public int To { get; set; }
        }

        private Parser _parser;

        public Day5()
        {
            _parser = new Parser();
        }

        public string ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var instructions = new List<Instruction>();
            var queues = new List<Stack>()
            {
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack()
            };
            var stacks = new List<Stack>()
            {
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack()
            };
            var mode = 1;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    mode = 2;
                    continue;
                }

                if (mode == 1)
                {
                    for (var i = 0; i < line.Length; i += 4)
                    {
                        if (line[i] != '[')
                        {
                            continue;
                        }

                        var sta = i == 0 ? 0 : i / 4;
                        queues[sta].Push(line[i + 1]);
                    }
                }
                else
                {
                    instructions.Add(CreateInstruction(line));
                }
            }

            for (int i = 0; i < queues.Count; i++)
            {
                while (queues[i].Count > 0)
                {
                    stacks[i].Push(queues[i].Pop());
                }
            }

            foreach (var instruction in instructions)
            {
                for (var i = 0; i < instruction.NumberOfContainersToMove; i++)
                {
                    var popped = stacks[instruction.From - 1].Pop();
                    stacks[instruction.To - 1].Push(popped);
                }
            }


            var sb = new StringBuilder();
            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }
            }


            return sb.ToString();
        }

        private Instruction CreateInstruction(string line)
        {
            var partsOfString = line.Split(' ');
            return new Instruction
            {
                NumberOfContainersToMove = int.Parse(partsOfString[1]),
                From = int.Parse(partsOfString[3]),
                To = int.Parse(partsOfString[5])
            };
        }

        public string ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var instructions = new List<Instruction>();
            var queues = new List<Stack>()
            {
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack()
            };
            var stacks = new List<Stack>()
            {
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack(),
                new Stack()
            };
            var mode = 1;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    mode = 2;
                    continue;
                }

                if (mode == 1)
                {
                    for (var i = 0; i < line.Length; i += 4)
                    {
                        if (line[i] != '[')
                        {
                            continue;
                        }

                        var sta = i == 0 ? 0 : i / 4;
                        queues[sta].Push(line[i + 1]);
                    }
                }
                else
                {
                    instructions.Add(CreateInstruction(line));
                }
            }

            for (int i = 0; i < queues.Count; i++)
            {
                while (queues[i].Count > 0)
                {
                    stacks[i].Push(queues[i].Pop());
                }
            }

            foreach (var instruction in instructions)
            {
                if (instruction.NumberOfContainersToMove <= 1)
                {
                    for (var i = 0; i < instruction.NumberOfContainersToMove; i++)
                    {
                        var popped = stacks[instruction.From - 1].Pop();
                        stacks[instruction.To - 1].Push(popped);
                    }
                }
                else
                {
                    var temp = new Stack();

                    for (var i = 0; i < instruction.NumberOfContainersToMove; i++)
                    {
                        temp.Push(stacks[instruction.From - 1].Pop());
                    }

                    while (temp.Count > 0)
                    {
                        stacks[instruction.To - 1].Push(temp.Pop());
                    }
                }
            }


            var sb = new StringBuilder();
            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }
            }


            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day11
    {
        public class Monkey
        {
            public string Operation { get; set; }
            public string OperationValue { get; set; }
            public int TestValue { get; set; }
            public int IfTrueMonkeyId { get; set; }
            public int IfFalseMonkeyId { get; set; }
            public int Inspections { get; set; }
        }

        private Parser _parser;

        public Day11()
        {
            _parser = new Parser();
        }

        public long ExecutePart1(string fileName, int executionTimes = 20, bool partTwo = false)
        {
            //var t= true;
            //var p = 19;

            //while (t)
            //{
            //    if (p % 3 == 0 && p % 17 == 0 && p % 7 == 0 && p % 2 == 0 && p % 5 == 0 && p % 11 == 0 && p % 13 == 0)
            //    {
            //        t = false;
            //    }
            //    else
            //    {
            //        p += 19;
            //    }
            //}


            var lines = _parser.ParseLines(fileName).ToList();
            var items = new Dictionary<Guid, long>();
            var monkeyItems = new Dictionary<int, Queue<Guid>>();
            var monkeys = new Dictionary<int, Monkey>();

            for (var i = 0; i < lines.Count; i+=7)
            {
                var firstLine = lines[i];
                var firstLineParts = firstLine.Split(' ');
                var monkeyNumber = int.Parse(firstLineParts[1].Remove(firstLineParts[1].Length - 1, 1));

                var secondLine = lines[i + 1];
                secondLine = secondLine.Remove(0, secondLine.IndexOf(':') + 2);
                var secondLineParts = secondLine.Split(", ");

                foreach (var secondLinePart in secondLineParts)
                {
                    var itemId = Guid.NewGuid();
                    var itemValue = int.Parse(secondLinePart);
                    items.Add(itemId, itemValue);
                    if (monkeyItems.ContainsKey(monkeyNumber))
                    {
                        monkeyItems[monkeyNumber].Enqueue(itemId);
                    }
                    else
                    {
                        monkeyItems.Add(monkeyNumber, new Queue<Guid>());
                        monkeyItems[monkeyNumber].Enqueue(itemId);
                    }
                }

                var thirdLine = lines[i + 2];
                var thirdLineParts = thirdLine.Split(' ');
                var operation = thirdLineParts[6];
                var operationValue = thirdLineParts[7];

                var fourthLine = lines[i + 3];
                var fourthLineParts = fourthLine.Split(' ');
                var divisibleBy = int.Parse(fourthLineParts[5]);

                var fifthLine = lines[i + 4];
                var fifthLineParts = fifthLine.Split(' ');
                var ifTrue = int.Parse(fifthLineParts[9]);

                var sixthLine = lines[i + 5];
                var sixthLineParts = sixthLine.Split(' ');
                var ifFalse = int.Parse(sixthLineParts[9]);

                monkeys.Add(monkeyNumber, new Monkey
                {
                    Operation = operation, 
                    OperationValue = operationValue, 
                    TestValue = divisibleBy,
                    IfTrueMonkeyId = ifTrue,
                    IfFalseMonkeyId = ifFalse
                });
            }

            var first = items.First().Key;
            for (var i = 0; i < executionTimes; i++)
            {
                foreach (var monkey in monkeys)
                {
                    var queuedItems = monkeyItems[monkey.Key];
                    while (queuedItems.TryDequeue(out var itemInspecting))
                    {
                        var opValue = monkey.Value.OperationValue == "old"
                            ? items[itemInspecting]
                            : int.Parse(monkey.Value.OperationValue);
                        if (itemInspecting == first)
                        {
                            Debug.WriteLine($"PRE - {items[itemInspecting]}");
                        }
                        switch (monkey.Value.Operation)
                        {
                            case "*":
                                items[itemInspecting] *= opValue;
                                break;
                            case "+":
                                items[itemInspecting] += opValue;
                                break;
                        }

                        if (!partTwo)
                        {
                            items[itemInspecting] = items[itemInspecting] / 3;
                        }

                        if (items[itemInspecting] % monkey.Value.TestValue == 0)
                        {
                            monkeyItems[monkey.Value.IfTrueMonkeyId].Enqueue(itemInspecting);
                        }
                        else
                        {
                            monkeyItems[monkey.Value.IfFalseMonkeyId].Enqueue(itemInspecting);
                        }

                        // 96577 - Example
                        // 9699690
                        items[itemInspecting] -= (9699690 * (items[itemInspecting] / 9699690));

                        monkey.Value.Inspections++;
                    }
                }
            }

            var inspections = new List<long>();
            foreach (var monkey in monkeys)
            {
                inspections.Add(monkey.Value.Inspections);
            }
            inspections = inspections.OrderByDescending(x => x).ToList();
            return inspections[0] * inspections[1];
        }

        public int ExecutePart2(string fileName)
        {
            var lines = _parser.ParseLines(fileName).ToList();

            return 0;
        }
    }
}

using System;

namespace AdventOfCode2021
{
    public class Day2
    {
        public int ExecutePart1(string input)
        {
            var lines = input.Split(",");

            var x = 0;
            var y = 0;
            var aim = 0;
            foreach (var line in lines)
            {
                if (line.StartsWith("forward"))
                {
                    var parts = line.Split(" ");
                    x += int.Parse(parts[1]);
                    y += aim * int.Parse(parts[1]);
                }
                else if (line.StartsWith("down"))
                {
                    var parts = line.Split(" ");
                    //y += int.Parse(parts[1]);
                    aim += int.Parse(parts[1]);
                }
                else
                {
                    var parts = line.Split(" ");
                    //y -= int.Parse(parts[1]);
                    aim -= int.Parse(parts[1]);
                }
            }

            return x * y;
        }
    }
}

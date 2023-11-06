using System.Transactions;

namespace AdventOfCode2015;

public class Day2
{
    private readonly IParser _parser;

    public Day2() : this(new Parser())
    {
    }

    public Day2(IParser parser)
    {
        _parser = parser;
    }
    
    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var totalWrappingPaper = 0;
        foreach (var line in lines)
        {
            var parts = line.Split('x');
            var length = parts[0];
            var width = parts[1];
            var height = parts[2];
            
            var side1 = int.Parse(length) * int.Parse(width);
            var side2 = int.Parse(width) * int.Parse(height);
            var side3 = int.Parse(height) * int.Parse(length);
            
            totalWrappingPaper += Math.Min(Math.Min(side1, side2), side3);
            totalWrappingPaper += 2 * side1 + 2 * side2 + 2 * side3;
        }

        return totalWrappingPaper;
    }
    
    public int ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var totalWrappingPaper = 0;
        foreach (var line in lines)
        {
            var parts = line.Split('x');
            var length = int.Parse(parts[0]);
            var width = int.Parse(parts[1]);
            var height = int.Parse(parts[2]);
            
            var maxSide = Math.Max(Math.Max(length, width), height);
            totalWrappingPaper += length * width * height;
            if (maxSide == length)
            {
                totalWrappingPaper += width * 2 + height * 2;
            } 
            else if (maxSide == width)
            {
                totalWrappingPaper += length * 2 + height * 2;
            }
            else
            {
                totalWrappingPaper += width * 2 + length * 2;
            }
        }

        return totalWrappingPaper;
    }
}
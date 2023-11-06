using System.Transactions;

namespace AdventOfCode2015;

public class Day1
{
    private readonly IParser _parser;

    public Day1() : this(new Parser())
    {
    }

    public Day1(IParser parser)
    {
        _parser = parser;
    }
    
    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        return lines.First().Sum(c => c switch
        {
            '(' => 1,
            ')' => -1,
            _ => 0
        });
    }
    
    public int ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var input = lines.First();
        var floor = 0;
        var index = 0;
        while (floor != -1)
        {
            if (input[index] == '(')
            {
                floor++;
            }
            else
            {
                floor--;
            }

            index++;
        }

        return index;
    }
}
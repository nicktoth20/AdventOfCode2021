namespace AdventOfCode2015;

public class Day3
{
    private readonly IParser _parser;

    public Day3() : this(new Parser())
    {
    }

    public Day3(IParser parser)
    {
        _parser = parser;
    }
    
    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var houses = new HashSet<string>();
        houses.Add("0.0");
        var x = 0;
        var y = 0;
        foreach (var operation in lines.First())
        {
            switch (operation)
            {
                case '>':
                    x++;
                    break;
                case '<':
                    x--;
                    break;
                case '^':
                    y++;
                    break;
                default:
                    y--;
                    break;
            }

            houses.Add($"{x}.{y}");
        }

        return houses.Count;
    }
    
    public int ExecutePart2(string filePath)
    {
        
        var lines = _parser.ParseLines(filePath);
        var santa = new HashSet<string>
        {
            "0.0"
        };
        var x = 0;
        var y = 0;
        var operations = lines.First();
        for(var i = 0; i < operations.Length; i += 2)
        {
            switch (operations[i])
            {
                case '>':
                    x++;
                    break;
                case '<':
                    x--;
                    break;
                case '^':
                    y++;
                    break;
                default:
                    y--;
                    break;
            }

            santa.Add($"{x}.{y}");
        }
        x = 0;
        y = 0;
        for(var i = 1; i < operations.Length; i += 2)
        {
            switch (operations[i])
            {
                case '>':
                    x++;
                    break;
                case '<':
                    x--;
                    break;
                case '^':
                    y++;
                    break;
                default:
                    y--;
                    break;
            }

            santa.Add($"{x}.{y}");
        }

        return santa.Count;
    }
}
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
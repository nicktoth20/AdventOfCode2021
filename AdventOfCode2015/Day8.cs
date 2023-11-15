using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015;

public class Day8
{
    private readonly IParser _parser;

    public Day8() : this(new Parser())
    {
    }

    public Day8(IParser parser)
    {
        _parser = parser;
    }

    public int ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var charactersOfString = 0;
        var decodeCount = 0;
        foreach (var line in lines) {
            charactersOfString += line.Length;
            var decode = Regex.Unescape(line);
            decodeCount += decode.Length;
        }

        decodeCount -= lines.Count() * 2;
        return charactersOfString - decodeCount;
    }

    public int ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var charactersOfString = 0;
        var decodeCount = 0;
        foreach (var line in lines) {
            charactersOfString += line.Length;
            var decode = Regex.Escape(line).Replace("\"", @"\""");
            decodeCount += decode.Length;
        }

        decodeCount += lines.Count() * 2;
        return decodeCount - charactersOfString;
    }
}
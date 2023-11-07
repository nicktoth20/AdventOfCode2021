using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015;

public class Day4
{
    private readonly IParser _parser;

    public Day4() : this(new Parser())
    {
    }

    public Day4(IParser parser)
    {
        _parser = parser;
    }
    
    public long ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);

        var prefix = lines.First();

        var hash = string.Empty;
        long index = 0; 
        do
        {
            var input = $"{prefix}{index}";
            hash = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input)));
            index++;
        } while (!hash.StartsWith("00000"));
        
        return --index;
    }
    
    public long ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);

        var prefix = lines.First();

        var hash = string.Empty;
        long index = 0; 
        do
        {
            var input = $"{prefix}{index}";
            hash = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input)));
            index++;
        } while (!hash.StartsWith("000000"));
        
        return --index;
    }
}
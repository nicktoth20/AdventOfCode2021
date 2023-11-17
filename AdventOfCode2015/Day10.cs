using System.Text;

namespace AdventOfCode2015;

public class Day10
{
    public Day10()
    {
    }
    
    public int ExecutePart1(int iterations)
    {
        var number = "1113222113";
        
        for (var i = 0; i < iterations; i++)
        {
            var sb = new StringBuilder();
            
            var count = 1;
            var previous = number.First();
            foreach (var c in number[1..])
            {
                if (c == previous)
                {
                    count++;
                }
                else
                {
                    sb.Append(count);
                    sb.Append(previous);

                    previous = c;
                    count = 1;
                }
            }

            sb.Append(count);
            sb.Append(number.Last());

            number = sb.ToString();
        }
        
        return number.Length;
    }

    public int ExecutePart2(string filePath)
    {
        return 0;
    }
}
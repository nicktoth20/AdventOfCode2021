namespace AdventOfCode2015
{
    public interface IParser
    {
        IEnumerable<string> ParseLines(string input);
    }
    public class Parser : IParser
    {
        public IEnumerable<string> ParseLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }

    public class SingleLineInputParser : IParser
    {
        public IEnumerable<string> ParseLines(string input)
        {
            yield return input;
        }
    }
}

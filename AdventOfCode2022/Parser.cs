using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022
{
    public class Parser
    {
        public IEnumerable<string> ParseLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}

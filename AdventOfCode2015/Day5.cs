using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015;

public class Day5
{
    private readonly IParser _parser;

    public Day5() : this(new Parser())
    {
    }

    public Day5(IParser parser)
    {
        _parser = parser;
    }
    
    public long ExecutePart1(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var niceStrings = 0;
        foreach (var line in lines) {
            if (HasEnoughVowels(line) && HasDuplicates(line) && DoesNotCountSpecialPairs(line)) {
                niceStrings++;
            }
        }
        return niceStrings;
    }

    private static bool HasEnoughVowels(string input) {
        var vowels = new [] {'a','e','i','o','u'};
        return input.Count(c => vowels.Contains(c)) > 2;
    }

    private static bool HasDuplicates(string input) {
        char previousCharacter = ' ';
        foreach (var character in input)
        {
            if (character == previousCharacter) {
                return true;
            }
            previousCharacter = character;
        }
        return false;
    }

    private static bool DoesNotCountSpecialPairs(string input) {
        var specialPairs = new [] { "ab", "cd", "pq", "xy" };
        foreach (var pair in specialPairs) {
            if (input.Contains(pair)) {
                return false;
            }
        }
        return true;
    }
    
    public long ExecutePart2(string filePath)
    {
        var lines = _parser.ParseLines(filePath);
        var niceStrings = 0;
        foreach (var line in lines) {
            if (HasPair(line) && HasPalidrone(line)) {
                niceStrings++;
            }
        }
        return niceStrings;
    }

    private bool HasPair(string input) {
        for(var i = 0; i < input.Length - 1; i++) {
            var pair = $"{input[i]}{input[i+1]}";
            var index = input.LastIndexOf(pair);
            if (index > i + 1) {
                return true;
            }
        }
        return false;
    }

    private static bool HasPalidrone(string input) {
        for(var i = 0; i < input.Length - 2; i++) {
            if (input[i] == input[i + 2]) {
                return true;
            }
        }
        return false;
    }
}
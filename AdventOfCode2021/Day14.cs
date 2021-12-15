using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day14
    {
        private Parser _parser;
        private Dictionary<string, char> _lookup = new Dictionary<string, char>();
        private Dictionary<string, long> _pairs = new Dictionary<string, long>();
        private Dictionary<char, long> _results = new Dictionary<char, long>();

        public Day14()
        {
            _parser = new Parser();
        }

        public long ExecutePart1(string fileName, int loop)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var lines = _parser.ParseLines(fileName).ToList();
            var sentence = lines[0];

            for (var i = 2; i < lines.Count; i++)
            {
                var parts = lines[i].Split(" -> ");
                _lookup[parts[0]] = Convert.ToChar(parts[1]);
            }

            for (var i = 0; i < loop; i++)
            {
                sentence = InsertCharacters(sentence);
            }

            foreach (var character in sentence)
            {
                if (_results.ContainsKey(character))
                {
                    _results[character]++;
                }
                else
                {
                    _results[character] = 1;
                }
            }

            var max = _results.Values.Max(v => v);
            var min = _results.Values.Min(v => v);
            watch.Stop();
            Debug.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return max - min;
        }


        public long ExecutePart2(string fileName, int loop)
        {
            var lines = _parser.ParseLines(fileName).ToList();
            var sentence = lines[0];

            for (var i = 2; i < lines.Count; i++)
            {
                var parts = lines[i].Split(" -> ");
                _lookup[parts[0]] = Convert.ToChar(parts[1]);
            }

            for (var x = 0; x < sentence.Length; x++)
            {
                _results[sentence[x]] = _results.ContainsKey(sentence[x]) ? _results[sentence[x]] + 1 : 1;
            }

            for (var x = 0; x < sentence.Length - 1; x++)
            {
                var test = sentence.Substring(x, 2);
                if (_pairs.ContainsKey(test))
                {
                    _pairs[test]++;
                }
                else
                {
                    _pairs[test] = 1;
                } 
            }

            for (var i = 0; i < loop; i++)
            {
               _pairs = InsertCharacters3(_pairs);
               Debug.WriteLine(_results.Sum(r => r.Value));
               Debug.WriteLine(_pairs.Sum(r => r.Value));
            }

            var max = _results.Values.Max(v => v);
            var min = _results.Values.Min(v => v);
            return max - min;
        }

        private string InsertCharacters(string sentence)
        {
            var sb = new StringBuilder();
            var firstTime = true;
            char previousCharacter = ' ';
            foreach (var character in sentence)
            {
                if (firstTime)
                {
                    sb.Append(character);
                }
                else
                {
                    sb.Append(_lookup[$"{previousCharacter}{character}"]);
                    sb.Append(character);
                }

                previousCharacter = character;
                firstTime = false;
            }


            return sb.ToString();
        }

        private Dictionary<string, long> InsertCharacters3(Dictionary<string, long> pairs)
        {
            var result = new Dictionary<string, long>();
            foreach (var pair in pairs)
            {
                var ruleResult = _lookup[pair.Key];
                var firstPair = $"{pair.Key[0]}{ruleResult}";
                var secondPair = $"{ruleResult}{pair.Key[1]}";

                _results[ruleResult] = _results.ContainsKey(ruleResult) ? _results[ruleResult] + pair.Value : 1;

                if (result.ContainsKey(firstPair))
                {
                    result[firstPair] = result[firstPair] + pair.Value;
                }
                else
                {
                    result[firstPair] = pair.Value;
                }

                if (result.ContainsKey(secondPair))
                {
                    result[secondPair] = result[secondPair] + pair.Value;
                }
                else
                {
                    result[secondPair] = pair.Value;
                }
            }

            return result;
        }
    }
}

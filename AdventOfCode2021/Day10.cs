using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day10
    {
        private Parser _parser;

        public Day10()
        {
            _parser = new Parser();
        }

        public long ExecutePart1(string fileName)
        {
            var lines = _parser.ParseLines(fileName);
            var score = new List<long>();

            foreach (var line in lines)
            {
                long s = 0;
                var stack = new Stack<char>();
                var exit = false;
                foreach (var character in line)
                {
                    if (exit)
                    {
                        continue;
                    }
                    switch (character)
                    {
                        case '(':
                        case '[':
                        case '{':
                        case '<':
                            stack.Push(character);
                            break;
                        case ')':
                        case ']':
                        case '}':
                        case '>':
                            var popped = stack.Pop();
                            if (!Matches(popped, character))
                            {
                                //score += GetScore(character);
                                exit = true;
                            }
                            break;
                    }
                }

                if (!exit)
                {
                    while (stack.Count > 0)
                    {
                        s *= 5;
                        s += GetMatchedScore(stack.Pop());
                    }
                    score.Add(s);
                }
            }

            score.Sort();
            
            return score[score.Count / 2];
        }

        private bool Matches(char popped, char closingCharacter)
        {
            switch (closingCharacter)
            {
                case ')':
                    return popped == '(';
                case ']':
                    return popped == '[';
                case '}':
                    return popped == '{';
                default:
                    return popped == '<';
            }
        }

        private int GetScore(char closingCharacter)
        {
            switch (closingCharacter)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                default:
                    return 25137;
            }
        }

        private int GetMatchedScore(char closingCharacter)
        {
            switch (closingCharacter)
            {
                case '(':
                    return 1;
                case '[':
                    return 2;
                case '{':
                    return 3;
                default:
                    return 4;
            }
        }
    }
}

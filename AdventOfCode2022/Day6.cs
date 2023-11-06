using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day6
    {
        //private Parser _parser;

        public Day6()
        {
            //_parser = new Parser();
        }

        public int ExecutePart1(string theLine)
        {
            var answerKey = new Dictionary<char, int>();
            //var lines = _parser.ParseLines(fileName).ToList();

            //var theLine = lines[0];
            var index = 0;
            var rolloffCharacter = '-';

            while (KeepGoing(answerKey))
            {
                if (index >= 4)
                {
                    rolloffCharacter = theLine[index - 4];
                    if (answerKey[rolloffCharacter] == 1)
                    {
                        answerKey.Remove(rolloffCharacter);
                    }
                    else
                    {
                        answerKey[rolloffCharacter]--;
                    }
                }

                var character = theLine[index];
                if (answerKey.ContainsKey(character))
                {
                    answerKey[character]++;
                }
                else
                {
                    answerKey.Add(character, 1);
                }

                index++;
            }

            return index;
        }

        public bool KeepGoing(Dictionary<char, int> answerKey)
        {
            return answerKey.Count != 4;
        }
        
        public int ExecutePart2(string theLine)
        {
            var answerKey = new Dictionary<char, int>();
            var index = 0;

            while (answerKey.Count != 14)
            {
                if (index >= 14)
                {
                    var rolloffCharacter = theLine[index - 14];
                    if (answerKey[rolloffCharacter] == 1)
                    {
                        answerKey.Remove(rolloffCharacter);
                    }
                    else
                    {
                        answerKey[rolloffCharacter]--;
                    }
                }

                var character = theLine[index];
                if (answerKey.ContainsKey(character))
                {
                    answerKey[character]++;
                }
                else
                {
                    answerKey.Add(character, 1);
                }

                index++;
            }

            return index;
        }
    }
}

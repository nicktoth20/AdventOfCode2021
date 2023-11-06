using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day2
    {
        private enum Results
        {
            Win,
            Loss,
            Draw
        }

        private Parser _parser;

        public Day2()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var result = 0;
            var lines = _parser.ParseLines(fileName).ToList();

            foreach (var line in lines)
            {
                var hands = line.Split(' ');
                var results = GetHandResult(hands[0], hands[1]);
                result += GetResultValue(results);
                result += GetHandValue(hands[1]);
            }

            return result;
        }

        public int ExecutePart2(string fileName)
        {
            var result = 0;
            var lines = _parser.ParseLines(fileName).ToList();

            foreach (var line in lines)
            {
                var hands = line.Split(' ');
                var secondHand = GetSecondHand(hands[0], hands[1]);
                var results = GetHandResult(hands[0], secondHand);
                result += GetResultValue(results);
                result += GetHandValue(secondHand);
            }

            return result;
        }

        private string GetSecondHand(string firstHand, string result)
        {
            switch (firstHand)
            {
                case "A": // Rock
                    return result switch
                    {
                        "X" => "Z",
                        "Y" => "X", 
                        "Z" => "Y", 
                        _ => throw new Exception()
                    };
                case "B": // Paper
                    return result switch
                    {
                        "X" => "X",
                        "Y" => "Y",
                        "Z" => "Z",
                        _ => throw new Exception()
                    };
                case "C": // Scissors
                    return result switch
                    {
                        "X" => "Y",
                        "Y" => "Z",
                        "Z" => "X",
                        _ => throw new Exception()
                    };
                default:
                    return "";
            }
        }

        private static Results GetHandResult(string firstHand, string secondHand)
        {
            switch (firstHand)
            {
                case "A": // Rock
                    return secondHand switch
                    {
                        "X" => Results.Draw, // Rock
                        "Y" => Results.Win, // Paper
                        "Z" => Results.Loss, // Scissors
                        _ => throw new Exception()
                    };
                case "B": // Paper
                    return secondHand switch
                    {
                        "X" => Results.Loss,
                        "Y" => Results.Draw,
                        "Z" => Results.Win,
                        _ => throw new Exception()
                    };
                case "C": // Scissors
                    return secondHand switch
                    {
                        "X" => Results.Win,
                        "Y" => Results.Loss,
                        "Z" => Results.Draw,
                        _ => throw new Exception()
                    };
                default:
                    return Results.Loss;
            }
        }

        private static int GetHandValue(string hand)
        {
            return hand switch
            {
                "X" => 1,
                "Y" => 2,
                "Z" => 3,
                _ => 0
            };
        }

        private static int GetResultValue(Results result)
        {
            return result switch
            {
                Results.Loss => 0,
                Results.Draw => 3,
                Results.Win => 6,
                _ => 0
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Bits
    {
        public int Ones { get; set; }
        public int Zeros { get; set; }
        public int MostCommon() => Ones > Zeros || Ones == Zeros ? 1 : 0;

        public Bits()
        {
            Ones = 0;
            Zeros = 0;
        }
    }

    public class Day3
    {
        public int ExecutePart1(string input)
        {
            var lines = input.Split(",");
            var numberOfBits = lines[0].Length;
            var bitsList = new Bits[numberOfBits];

            for (var x = 0; x < numberOfBits; x++)
            {
                var bits = new Bits();
                foreach (var line in lines)
                {
                    if (line[x] == '1')
                    {
                        bits.Ones++;
                    }
                    else
                    {
                        bits.Zeros++;
                    }
                }

                bitsList[x] = bits;
            }

            var gammaResult = GetGammaResult(bitsList);
            var epsilonRate = GetEpsilonRate(bitsList);
            return gammaResult * epsilonRate;
        }

        public int GetGammaResult(Bits[] bits)
        {
            var stringBuilder = new StringBuilder();
            foreach (var bit in bits)
            {
                var c = bit.MostCommon() == 1 ? '1' : '0';
                stringBuilder.Append(c);
            }
            return Convert.ToInt32(stringBuilder.ToString(), 2);
        }

        public int GetEpsilonRate(Bits[] bits)
        {
            var stringBuilder = new StringBuilder();
            foreach (var bit in bits)
            {
                var c = bit.MostCommon() == 1 ? '0' : '1';
                stringBuilder.Append(c);
            }
            return Convert.ToInt32(stringBuilder.ToString(), 2);
        }

        public int ExecutePart2(string input)
        {
            var lines = input.Split(",");
            var numberOfBits = lines[0].Length;

            var oxygen = GetOxygen(lines, numberOfBits);
            var CO2 = GetCO2(lines, numberOfBits);

            return oxygen * CO2;
        }

        public int GetMostCommonBit(int x, string[] lines)
        {
            var bits = new Bits();
            foreach (var line in lines)
            {
                if (line[x] == '1')
                {
                    bits.Ones++;
                }
                else
                {
                    bits.Zeros++;
                }
            }

            return bits.MostCommon();
        }

        public int GetOxygen(string[] lines, int numberOfBits)
        {
            var sb = new StringBuilder();

            for (var x = 0; x < numberOfBits && lines.Length > 1; x++)
            {
                var result = GetMostCommonBit(x, lines);
                sb.Append(result.ToString());
                lines = lines.Where(l => l.StartsWith(sb.ToString())).ToArray();
            }

            return Convert.ToInt32(lines.First(), 2);
        }

        public int GetCO2(string[] lines, int numberOfBits)
        {
            var sb = new StringBuilder();

            for (var x = 0; x < numberOfBits && lines.Length > 1; x++)
            {
                var result = GetMostCommonBit(x, lines) == 1 ? '0' : '1';
                sb.Append(result.ToString());
                lines = lines.Where(l => l.StartsWith(sb.ToString())).ToArray();
            }

            return Convert.ToInt32(lines.First(), 2);
        }
    }
}

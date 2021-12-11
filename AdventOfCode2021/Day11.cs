using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day11
    {
        private Parser _parser;
        private Dictionary<string, Octopus> _octopi;
        private int _flashed = 0;

        public Day11()
        {
            _parser = new Parser();
            _octopi = new Dictionary<string, Octopus>();
        }

        public int ExecutePart1(string fileName)
        {

            var lines = _parser.ParseLines(fileName).ToList();

            for (var i = 0; i < lines.Count(); i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    _octopi[$"{i}-{j}"] = new Octopus(lines[i][j] - '0');
                }
            }

            for (var i = 0; i < 100; i++)
            {
                IncrementOctopi();
                while (_octopi.Values.Any(v => v.ShouldFlash()))
                {
                    FlashOctopi();
                }
            }

            return _flashed;
        }

        public int ExecutePart2(string fileName)
        {

            var lines = _parser.ParseLines(fileName).ToList();

            for (var i = 0; i < lines.Count(); i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    _octopi[$"{i}-{j}"] = new Octopus(lines[i][j] - '0');
                }
            }

            var step = 1;
            do
            {
                IncrementOctopi();
                while (_octopi.Values.Any(v => v.ShouldFlash()))
                {
                    FlashOctopi();
                }

                if (_octopi.Values.All(o => o.Value == 0))
                {
                    return step;
                }

                step++;
            } while (true);
        }

        public void IncrementOctopi()
        {
            foreach (var octopus in _octopi)
            {
                octopus.Value.Increment();
            }
        }

        public void FlashOctopi()
        {
            var flashes = _octopi.Where(o => o.Value.ShouldFlash());
            foreach (var octopus in flashes)
            {
                octopus.Value.Flash();
                _flashed++;

                var x = ParseX(octopus.Key);
                var y = ParseY(octopus.Key);

                // Top left
                if (_octopi.ContainsKey($"{x - 1}-{y - 1}")) _octopi[$"{x - 1}-{y - 1}"].FlashIncrement();

                // Top
                if (_octopi.ContainsKey($"{x - 1}-{y}")) _octopi[$"{x - 1}-{y}"].FlashIncrement();

                // Top right
                if (_octopi.ContainsKey($"{x - 1}-{y + 1}")) _octopi[$"{x - 1}-{y + 1}"].FlashIncrement();

                // left
                if (_octopi.ContainsKey($"{x}-{y - 1}")) _octopi[$"{x}-{y - 1}"].FlashIncrement();

                // right
                if (_octopi.ContainsKey($"{x}-{y + 1}")) _octopi[$"{x}-{y + 1}"].FlashIncrement();

                // bottom left
                if (_octopi.ContainsKey($"{x + 1}-{y - 1}")) _octopi[$"{x + 1}-{y - 1}"].FlashIncrement();

                // bottom
                if (_octopi.ContainsKey($"{x + 1}-{y}")) _octopi[$"{x + 1}-{y}"].FlashIncrement();

                // bottom right
                if (_octopi.ContainsKey($"{x + 1}-{y + 1}")) _octopi[$"{x + 1}-{y + 1}"].FlashIncrement();

            }
        }

        public int ParseX(string location)
        {
            return int.Parse(location.Split('-')[0]);
        }

        public int ParseY(string location)
        {
            return int.Parse(location.Split('-')[1]);
        }
    }

    public class Octopus
    {
        public int Value { get; set; }

        public Octopus(int value)
        {
            Value = value;
        }

        public void Increment()
        {
            Value++;
        }

        public bool ShouldFlash()
        {
            return Value > 9;
        }

        public void Flash()
        {
            Value = 0;
        }

        public void FlashIncrement()
        {
            if (Value > 0)
            {
                Increment();
            }
        }
    }
}

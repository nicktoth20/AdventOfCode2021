using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day6
    {
        private Parser _parser { get; set; }
        private Dictionary<int, long> _resultSet { get; set; }
        private Dictionary<string, long> _kidSet { get; set; }

        public Day6()
        {
            _parser = new Parser();
            _resultSet = new Dictionary<int, long>();
            _kidSet = new Dictionary<string, long>();
        }

        public long ExecutePart1(string fileName, int days)
        {
            var lines = _parser.ParseLines(fileName);
            var initialFishes = Array.ConvertAll(lines.First().Split(','), int.Parse);
            
            var uniqueFish = initialFishes.Distinct();
            var listOfFish = uniqueFish.Select(fish => new LanternFish(0, fish)).ToList();

            //var listOfFish = initialFishes.Select(fish => new LanternFish(0, fish)).ToList();
            foreach (var fish in listOfFish)
            {
                _resultSet[fish.Index] = GetKids(fish, days) + 1;
            }

            long totalFish = 0;

            foreach (var fish in initialFishes)
            {

                totalFish += _resultSet[fish];
            }

            return totalFish;
        }

        private long GetKids(LanternFish fish, int days)
        {
            long total = 0;

            var kids = fish.CreateKids(days);
            total += kids.Count;
            foreach (var kid in kids)
            {
                if (_kidSet.ContainsKey($"{kid.Index}-{kid.BirthDate}"))
                {
                    total += _kidSet[$"{kid.Index}-{kid.BirthDate}"];
                }
                else
                {
                    var k = GetKids(kid, days);
                    _kidSet[$"{kid.Index}-{kid.BirthDate}"] = k;
                    total += k;
                }
            }

            return total;
        }
    }

    public class LanternFish
    {
        public int BirthDate { get; set; }
        public int Index { get; set; }

        public LanternFish(int birthDate, int index)
        {
            BirthDate = birthDate;
            Index = index;
        }

        public List<LanternFish> CreateKids(int days)
        {
            var fish = new List<LanternFish>();
            var totalKids = TotalKids(days);

            for (var i = 0; i < totalKids; i++)
            {
                var birthDate = (Index + 1) + (i * 7) + BirthDate;
                if (birthDate <= days)
                {
                    fish.Add(new LanternFish(birthDate, 8));
                }
            }

            return fish;
        }

        public int TotalKids(int days)
        {
            if (Index != 8)
            {
                return GetKidsForInitialFish(days);
            }

            return GetKidsForNewFish(days);
        }

        private int GetKidsForInitialFish(int days)
        {
            var start = days - Index;
            return start / 7 + 1;
        }

        private int GetKidsForNewFish(int days)
        {
            var newDays = days - (BirthDate + Index);
            return GetKidsForInitialFish(newDays) + 1;
        }
    }
}

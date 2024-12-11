using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Advent2024;

internal class Day11 : DayBase
{
    protected override string _sample1 => "125 17";

    protected override string _part1 => "3279 998884 1832781 517 8 18864 28 0";

    protected override string Part1Internal(string input)
    {
        var longs = input.Split(' ').Select(long.Parse);
        var stones = new List<(long Stone, int Blinks)>(longs.Select(x => (x, 25)));

        var lowestIndex = 0;

        while (stones.Any(x => x.Blinks > 0))
        {
            for (var i = lowestIndex; i < stones.Count; i++)
            {
                var item = stones[i];
                if (item.Blinks == 0)
                {
                    lowestIndex = i;
                    continue;
                }

                if (item.Stone == 0)
                {
                    stones[i] = (1, item.Blinks-1);
                    break;
                }

                if (item.Stone.ToString().Length % 2 == 0)
                {
                    stones[i] = (long.Parse(item.Stone.ToString().Substring(0, item.Stone.ToString().Length / 2)), item.Blinks - 1);
                    stones.Insert(i + 1, (long.Parse(item.Stone.ToString().Substring(item.Stone.ToString().Length / 2)), item.Blinks - 1));
                    break;
                }

                stones[i] = (item.Stone * 2024, item.Blinks - 1);
            }
        }

        return stones.Count.ToString();
    }
}

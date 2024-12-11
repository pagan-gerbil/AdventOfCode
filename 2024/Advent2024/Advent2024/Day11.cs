using AdventUtils;

namespace Advent2024;

internal class Day11 : DayBase
{
    protected override string _sample1 => "125 17";

    protected override string _part1 => "3279 998884 1832781 517 8 18864 28 0";

    protected override string Part1Internal(string input)
    {
        return CountStones(input, 25).ToString();
    }

    protected override string Part2Internal(string input)
    {
        return CountStones(input, 75).ToString();
    }

    private long CountStones(string input, int numberOfBlinks)
    {
        var lookup = new Dictionary<long, IEnumerable<long>>();

        var resultsLookup = new Dictionary<long, Dictionary<int, long>>();

        long[] stones = input.Split(' ').Select(long.Parse).ToArray();
        var counter = 0L;

        var items = new Stack<(long Value, int Steps)>(stones.Select(x => (Value: x, Steps: numberOfBlinks)));

        while (items.Any())
        {
            var i = items.Pop();
            var offset = 1;
            if (i.Steps == 0)
            {
                counter++;
                continue;
            }

            counter += CountChildren(i, lookup, resultsLookup);
        }

        return counter;
    }

    private long CountChildren((long Value, int Steps) i, Dictionary<long, IEnumerable<long>> lookup, Dictionary<long, Dictionary<int, long>> resultsLookup)
    {
        if (resultsLookup.TryGetValue(i.Value, out var stepsLookup))
        {
            if (stepsLookup.TryGetValue(i.Steps, out var result))
            {
                return result;
            }
        }

        if (i.Steps == 0)
        {
            return 1;
        }

        if (!lookup.ContainsKey(i.Value))
        {
            var v = i.Value;
            if (v == 0)
            {
                lookup.Add(0, [1]);
            }
            else
            {
                var vs = v.ToString();
                if (vs.Length % 2 == 0)
                {
                    var chunkLength = vs.Length / 2;
                    lookup.Add(v, Enumerable.Range(0, vs.Length / chunkLength).Select(d => long.Parse(vs.Substring(d * chunkLength, chunkLength))).ToArray());

                }
                else
                {
                    lookup.Add(v, [v * 2024]);
                }
            }
        }

        var count = 0L;
        foreach (var l in lookup[i.Value])
        {
            count += CountChildren((Value: l, Steps: i.Steps - 1), lookup, resultsLookup);
        }
        resultsLookup.TryAdd(i.Value, new Dictionary<int, long>());
        resultsLookup[i.Value].TryAdd(i.Steps, count);
        return count;
    }
}

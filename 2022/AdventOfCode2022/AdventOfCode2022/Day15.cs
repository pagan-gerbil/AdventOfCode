using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day15
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle1(2000000);
            if (puzzlePart == 2) Puzzle2();
        }

        private static Regex _inputRegex = new Regex("Sensor at x=(?<sensorX>[-0-9]+), y=(?<sensorY>[-0-9]+): closest beacon is at x=(?<beaconX>[-0-9]+), y=(?<beaconY>[-0-9]+)");

        private static void Puzzle1(int y = 10)
        {
            var allSensors = new List<((long, long), long)>();
            var allBeacons = new List<(long, long)>();
            foreach (var line in _input.Split(Environment.NewLine))
            {
                var match = _inputRegex.Match(line);
                var sensorX = long.Parse(match.Groups["sensorX"].Value);
                var sensorY = long.Parse(match.Groups["sensorY"].Value);
                var beaconX = long.Parse(match.Groups["beaconX"].Value);
                var beaconY = long.Parse(match.Groups["beaconY"].Value);

                var diff = Math.Abs(sensorX - beaconX) + Math.Abs(sensorY - beaconY);
                allSensors.Add(((sensorX, sensorY), diff));
                allBeacons.Add((beaconX, beaconY));
            }


            var maxColumns = allSensors.Max(x => x.Item1.Item1 + x.Item2);
            var minColumns = allSensors.Min(x => x.Item1.Item1 - x.Item2);
            var maxRows = allSensors.Max(x => x.Item1.Item2 + x.Item2);
            var minRows = allSensors.Min(x => x.Item1.Item2 - x.Item2);

            var beaconCounter = 0;
            for (var i = minColumns; i<= maxColumns; i++)
            {
                if (allBeacons.Contains((i, y)))
                {
                    continue;
                }

                foreach (var s in allSensors)
                {
                    if (Math.Abs(s.Item1.Item1 - i) + Math.Abs(s.Item1.Item2 - y) <= s.Item2)
                    {
                        beaconCounter++;
                        break;
                    }
                }
            }

            Console.WriteLine($"There are {beaconCounter} possible positions");
        }

        private static void AddToDictionary(Dictionary<long, List<(long x1, long x2)>> dictionary, long row, long x1, long x2)
        {
            if (!dictionary.ContainsKey(row))
            {
                dictionary.Add(row, new List<(long, long)>());
            }

            if (!dictionary[row].Any(existing => existing.x1 <= x1 && existing.x2 >= x2))
            {
                dictionary[row].Add((x1, x2));
            }
        }

        private static void Puzzle2()
        {
            const int limit = 4000000;
            var allSensors = new List<((long, long), long)>();
            var allBeacons = new List<(long, long)>();

            var allExclusions = new Dictionary<long, List<(long x1, long x2)>>();

            foreach (var line in _input.Split(Environment.NewLine))
            {
                var match = _inputRegex.Match(line);
                var sensorX = long.Parse(match.Groups["sensorX"].Value);
                var sensorY = long.Parse(match.Groups["sensorY"].Value);
                var beaconX = long.Parse(match.Groups["beaconX"].Value);
                var beaconY = long.Parse(match.Groups["beaconY"].Value);

                var diff = Math.Abs(sensorX - beaconX) + Math.Abs(sensorY - beaconY);
                allSensors.Add(((sensorX, sensorY), diff));
                allBeacons.Add((beaconX, beaconY));

                AddToDictionary(allExclusions, sensorY, sensorX - diff, sensorX + diff);
                for (var y = sensorY - diff; y <= sensorY + diff; y++)
                {
                    var remainingDiff = Math.Abs(Math.Abs(sensorY - y) - diff);
                    AddToDictionary(allExclusions, y, sensorX - remainingDiff, sensorX + remainingDiff);
                }
            }

            var maxColumns = allSensors.Max(x => x.Item1.Item1 + x.Item2);
            var minColumns = allSensors.Min(x => x.Item1.Item1 - x.Item2);
            var maxRows = allSensors.Max(x => x.Item1.Item2 + x.Item2);
            var minRows = allSensors.Min(x => x.Item1.Item2 - x.Item2);

            minRows = minRows > 0 ? minRows : 0;
            maxRows = maxRows < limit ? maxRows : limit;
            minColumns = minColumns > 0 ? minColumns : 0;
            maxColumns = maxColumns < limit ? maxColumns : limit;

            var beaconFrequency = 0l;

            for (var y = minRows; y <= maxRows; y++)
            {
                var exclusions = allExclusions[y];

                for (var x = 0l; x <= limit; x++)
                {
                    var exclusion = exclusions.FirstOrDefault(e => e.x1 <= x && e.x2 >= x);
                    if (exclusion == default)
                    {
                        Console.WriteLine($"Apparently {x},{y}");
                        beaconFrequency = (x * limit) + y;
                        break;
                    }
                    x = exclusion.x2;
                }

                if (beaconFrequency > 0) break;
            }

            Console.WriteLine($"The beacon frequency is {beaconFrequency}");
        }

        private static string _testInput = @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";

        private static string _input = @"Sensor at x=3088287, y=2966967: closest beacon is at x=3340990, y=2451747
Sensor at x=289570, y=339999: closest beacon is at x=20077, y=1235084
Sensor at x=1940197, y=3386754: closest beacon is at x=2010485, y=3291030
Sensor at x=1979355, y=2150711: closest beacon is at x=1690952, y=2000000
Sensor at x=2859415, y=1555438: closest beacon is at x=3340990, y=2451747
Sensor at x=1015582, y=2054755: closest beacon is at x=1690952, y=2000000
Sensor at x=1794782, y=3963737: closest beacon is at x=2183727, y=4148084
Sensor at x=2357608, y=2559811: closest beacon is at x=2010485, y=3291030
Sensor at x=2936, y=1218210: closest beacon is at x=20077, y=1235084
Sensor at x=2404143, y=3161036: closest beacon is at x=2010485, y=3291030
Sensor at x=12522, y=1706324: closest beacon is at x=20077, y=1235084
Sensor at x=1989162, y=3317864: closest beacon is at x=2010485, y=3291030
Sensor at x=167388, y=3570975: closest beacon is at x=-1018858, y=4296788
Sensor at x=1586527, y=2233885: closest beacon is at x=1690952, y=2000000
Sensor at x=746571, y=1442967: closest beacon is at x=20077, y=1235084
Sensor at x=3969726, y=3857699: closest beacon is at x=3207147, y=4217920
Sensor at x=1403393, y=2413121: closest beacon is at x=1690952, y=2000000
Sensor at x=2343717, y=3649198: closest beacon is at x=2183727, y=4148084
Sensor at x=1473424, y=688269: closest beacon is at x=2053598, y=-169389
Sensor at x=2669347, y=190833: closest beacon is at x=2053598, y=-169389
Sensor at x=2973167, y=3783783: closest beacon is at x=3207147, y=4217920
Sensor at x=2011835, y=3314181: closest beacon is at x=2010485, y=3291030
Sensor at x=1602224, y=2989728: closest beacon is at x=2010485, y=3291030
Sensor at x=3928889, y=1064434: closest beacon is at x=3340990, y=2451747
Sensor at x=2018358, y=3301778: closest beacon is at x=2010485, y=3291030
Sensor at x=1811905, y=2084187: closest beacon is at x=1690952, y=2000000
Sensor at x=1767697, y=1873118: closest beacon is at x=1690952, y=2000000
Sensor at x=260786, y=1154525: closest beacon is at x=20077, y=1235084";
    }
}

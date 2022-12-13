using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day10
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle1();
            if (puzzlePart == 2) Puzzle2();
        }

        private static void Puzzle1()
        {
            List<(int, int)> scores = GetScores();

            var interestingCycles = new[] { 20, 60, 100, 140, 180, 220 };

            var samples = scores.Where(x => interestingCycles.Contains(x.Item1));
            Console.WriteLine($"The final sum is {samples.Sum(x => x.Item1 * x.Item2)}");

        }

        private static List<(int, int)> GetScores()
        {
            var scores = new List<(int, int)>();

            var cycleNumber = 1;
            var signal = 1;

            foreach (var line in _input.Split(Environment.NewLine))
            {
                scores.Add((cycleNumber, signal));

                if (line.StartsWith("a"))
                {
                    cycleNumber++;
                    scores.Add((cycleNumber, signal));
                }

                cycleNumber++;
                if (line.StartsWith("a"))
                {
                    signal += int.Parse(line.Substring(5));
                }
            }

            return scores;
        }

        private static void Puzzle2()
        {
            var scores = GetScores();

            var output = new StringBuilder();
            var currentlyDrawing = 0;

            foreach (var cycle in scores)
            {
                var sprites = new[] { cycle.Item2-1, cycle.Item2, cycle.Item2 + 1 };

                if (sprites.Contains(currentlyDrawing))
                {
                    output.Append("#");
                }
                else
                {
                    output.Append(".");
                }

                currentlyDrawing++;
                if (currentlyDrawing >= 40) currentlyDrawing = 0;
            }

            var total = output.ToString();
            var split = Enumerable.Range(0, total.Length / 40).Select(i => total.Substring(i * 40, 40));
            foreach(var s in split)
            {
                Console.WriteLine(s);
            }
        }

        private static string _testInput = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";

        private static string _input = @"noop
addx 5
noop
addx 3
addx -2
addx 4
noop
noop
noop
noop
noop
addx 7
addx 3
noop
noop
noop
noop
addx 5
noop
noop
addx 5
addx -10
addx 2
addx 14
noop
addx -38
noop
noop
addx 5
addx 2
addx 2
addx 3
noop
addx 20
addx -19
addx 28
addx -21
addx 2
addx 3
noop
addx 2
addx -4
addx 5
addx 2
addx -4
addx 11
addx -27
addx 28
addx -38
addx 5
addx 2
addx -1
noop
addx 6
addx 3
addx -2
noop
noop
addx 7
addx 2
noop
noop
noop
addx 5
addx 3
noop
addx 2
addx -11
addx 6
addx 8
noop
addx 3
addx -37
addx 1
addx 5
addx 2
addx 3
noop
noop
noop
noop
noop
addx -5
addx 13
addx 2
addx -8
addx 9
addx 4
noop
addx 5
addx -2
addx -14
addx 21
addx 1
noop
noop
addx -38
addx 2
addx 5
addx 2
addx 3
addx -2
noop
addx 11
addx -6
addx 5
addx 2
addx 3
noop
addx 2
addx -10
addx 15
noop
addx -24
addx 17
addx 10
noop
addx 3
addx -38
addx 5
addx 2
addx 3
addx -2
addx 2
addx 7
addx 1
addx -1
noop
addx 5
noop
noop
noop
noop
addx 3
noop
addx -21
addx 28
addx 1
noop
addx 2
noop
addx 3
noop
noop";
    }
}

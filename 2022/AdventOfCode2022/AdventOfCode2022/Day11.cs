using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace AdventOfCode2022
{
    internal class Day11
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle(3, 20);
            if (puzzlePart == 2) Puzzle(1, 10000);
        }

        private static void Puzzle(int worryReducer, int numberOfRounds)
        {
            var monkeyItems = new[]
            {
                new Queue<long>(new long[] {83, 97, 95, 67}),
                new Queue<long>(new long[] {71, 70, 79, 88, 56, 70}),
                new Queue<long>(new long[] {98, 51, 51, 63, 80, 85, 84, 95}),
                new Queue<long>(new long[] {77, 90, 82, 80, 79}),
                new Queue<long>(new long[] {68}),
                new Queue<long>(new long[] {60, 94}),
                new Queue<long>(new long[] {81, 51, 85}),
                new Queue<long>(new long[] {98, 81, 63, 65, 84, 71, 84}),
            };

            var monkeyOps = new[]
            {
                new Func<long,long>((long old) => old*19),
                new Func<long,long>((long old) => old+2),
                new Func<long,long>((long old) => old+7),
                new Func<long,long>((long old) => old+1),
                new Func<long,long>((long old) => old*5),
                new Func<long,long>((long old) => old+5),
                new Func<long,long>((long old) => old*old),
                new Func<long,long>((long old) => old+3),
            };

            var monkeyTests = new[]
            {
                new Func<int, int>((int input) => input % 17 == 0 ? 2 : 7),
                new Func<int, int>((int input) => input % 19 == 0 ? 7 : 0),
                new Func<int, int>((int input) => input % 7 == 0 ? 4 : 3),
                new Func<int, int>((int input) => input % 11 == 0 ? 6 : 4),
                new Func<int, int>((int input) => input % 13 == 0 ? 6 : 5),
                new Func<int, int>((int input) => input % 3 == 0 ? 1 : 0),
                new Func<int, int>((int input) => input % 5 == 0 ? 5 : 1),
                new Func<int, int>((int input) => input % 2 == 0 ? 2 : 3),
            };


            var monkeyScores = monkeyItems.Select(x => 0l).ToArray();

            for (var roundNumber = 1; roundNumber <= numberOfRounds; roundNumber++)
            {
                for (var monkeyNumber = 0; monkeyNumber < monkeyItems.Length; monkeyNumber++)
                {
                    while (monkeyItems[monkeyNumber].Count > 0)
                    {
                        var currentItem = monkeyItems[monkeyNumber].Dequeue();
                        currentItem = monkeyOps[monkeyNumber](currentItem);
                        monkeyScores[monkeyNumber]++;
                        currentItem /= worryReducer;
                        var newMonkey = monkeyTests[monkeyNumber](currentItem);
                        monkeyItems[newMonkey].Enqueue(currentItem);
                    }
                }
            }

            var top2 = monkeyScores.OrderByDescending(x=>x).Take(2);
            var totalScore = top2.First() * top2.Last();

            Console.WriteLine($"After {numberOfRounds} rounds, the two most annoying monkeys score: {totalScore}");
        }

        private static void Puzzle2()
        {
        }

        private static string _testInput = @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1";

        private static string _input = @"Monkey 0:
  Starting items: 83, 97, 95, 67
  Operation: new = old * 19
  Test: divisible by 17
    If true: throw to monkey 2
    If false: throw to monkey 7

Monkey 1:
  Starting items: 71, 70, 79, 88, 56, 70
  Operation: new = old + 2
  Test: divisible by 19
    If true: throw to monkey 7
    If false: throw to monkey 0

Monkey 2:
  Starting items: 98, 51, 51, 63, 80, 85, 84, 95
  Operation: new = old + 7
  Test: divisible by 7
    If true: throw to monkey 4
    If false: throw to monkey 3

Monkey 3:
  Starting items: 77, 90, 82, 80, 79
  Operation: new = old + 1
  Test: divisible by 11
    If true: throw to monkey 6
    If false: throw to monkey 4

Monkey 4:
  Starting items: 68
  Operation: new = old * 5
  Test: divisible by 13
    If true: throw to monkey 6
    If false: throw to monkey 5

Monkey 5:
  Starting items: 60, 94
  Operation: new = old + 5
  Test: divisible by 3
    If true: throw to monkey 1
    If false: throw to monkey 0

Monkey 6:
  Starting items: 81, 51, 85
  Operation: new = old * old
  Test: divisible by 5
    If true: throw to monkey 5
    If false: throw to monkey 1

Monkey 7:
  Starting items: 98, 81, 63, 65, 84, 71, 84
  Operation: new = old + 3
  Test: divisible by 2
    If true: throw to monkey 2
    If false: throw to monkey 3";
    }
}

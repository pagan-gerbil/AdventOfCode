using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = _input.Split(Environment.NewLine);
            var earliest = int.Parse(lines[0]);
            var numbers = lines[1]
                .Split(',')
                .Where(x => x.All(y => char.IsDigit(y)))
                .Select(x => int.Parse(x));

            var results = new List<Tuple<int, int>>();

            foreach (var bus in numbers)
            {
                var remainder = earliest % bus;
                var counter = 0;
                while (remainder > 0)
                {
                    counter++;
                    remainder = (earliest + counter) % bus;
                }

                results.Add(new Tuple<int, int>(bus, earliest + counter));
            }

            var nextBus = results.OrderBy(x => x.Item2).First();

            Console.WriteLine($"Earliest bus is: {nextBus.Item1} leaving at {nextBus.Item2}: {nextBus.Item1 * (nextBus.Item2 - earliest)}");

            var offsets = lines[1].Split(',')
                .Select((x, i) =>
                {
                    if (x.All(y => char.IsDigit(y)))
                        return new Tuple<int, int>(int.Parse(x), i);
                    return null;
                })
                .Where(x => x != null)
                .ToArray();

            var magicNumber = 100000000000000; // (long)offsets.Min(x=>x.Item1);
            magicNumber += (magicNumber % offsets.First().Item1) + 2;
            var correct = 0;
            while (correct < offsets.Count())
            {
                correct = 0;
                foreach (var o in offsets)
                {
                    if ((o.Item2 + magicNumber) % o.Item1 > 0)
                        break;
                    correct++;
                }

                magicNumber+=offsets.First().Item1;
            }

            Console.WriteLine($"The magic number is {magicNumber - 1}");
        }

        private static string _example = @"939
7,13,x,x,59,x,31,19";

        private static string _input = @"1002460
29,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,601,x,x,x,x,x,x,x,23,x,x,x,x,13,x,x,x,17,x,19,x,x,x,x,x,x,x,x,x,x,x,463,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,37";
    }
}

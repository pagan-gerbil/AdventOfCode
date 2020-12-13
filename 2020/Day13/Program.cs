using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = _example.Split(Environment.NewLine);
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
        }

        private static string _example = @"939
7,13,x,x,59,x,31,19";
    }
}

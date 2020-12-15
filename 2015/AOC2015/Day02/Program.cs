using System;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var total = 0l;

            foreach (var line in _example.Split(Environment.NewLine))
            {
                var numbers = line.Split('x').Select(long.Parse).ToArray();

                var sides = new[]
                {
                    numbers[0] * numbers[1],
                    numbers[2] * numbers[1],
                    numbers[0] * numbers[2]
                };

                total += sides.Min() + (2 * sides.Sum());
                
            }

            Console.WriteLine($"Total amount of paper is: {total}");
        }

        private static string _example = @"2x3x4
1x1x10";
    }
}

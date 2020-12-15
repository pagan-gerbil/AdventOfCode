using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = _example.Split(Environment.NewLine);

            var mask = lines[0].Substring(7);
            var instructions = lines.Skip(1)
                .Select(x =>
                {
                    var firstIndex = x.IndexOf('[');
                    var lastIndex = x.LastIndexOf(']');

                    return new Tuple<int, int>(int.Parse(x.Substring(firstIndex, lastIndex - firstIndex)), int.Parse(x.Substring(x.LastIndexOf(' '))));
                }).Reverse();

            var results = new Dictionary<int, int>();
            
            foreach (var instruction in instructions)
            {
                if (results.ContainsKey(instruction.Item1))
                    continue;

                int value = instruction.Item2;
                // apply mask here....
                results.Add(instruction.Item1, value);
            }

            Console.WriteLine($"The sum of masked values is {results.Values.Sum()}");
        }

        private static string _example = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";
    }
}

using System;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapters = _example
                .Split(Environment.NewLine)
                .Select(x => int.Parse(x));
            var device = adapters.Max() + 3;
            
            adapters = adapters
                .Concat(new[] { device })
                .OrderBy(x => x);

            var diff1 = 0;
            var diff2 = 0;
            var diff3 = 0;

            var lastAdapter = 0;

            foreach (var adapter in adapters)
            {
                if (adapter - lastAdapter == 1)
                    diff1++;
                if (adapter - lastAdapter == 2)
                    diff2++;
                if (adapter - lastAdapter == 3)
                    diff3++;
                if (adapter - lastAdapter > 3)
                    Console.WriteLine("Something odd?");
                lastAdapter = adapter;
            }

            Console.WriteLine($"{diff1} differences of 1 jolt; {diff3} differences of 3 jolt");
            Console.WriteLine($"Answer is {diff1 * diff3}");

        }

        private static string _example = @"16
10
15
5
1
11
7
19
6
12
4";
    }
}

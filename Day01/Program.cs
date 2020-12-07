using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = File.ReadAllLines("input.txt").Select(int.Parse);

            var target = 2020;

            FindTwoNumbers(numbers, target);
        }

        private static void FindTwoNumbers(IEnumerable<int> numbers, int target)
        {
            foreach (var n in numbers)
            {
                var remainder = target - n;
                if (numbers.Contains(remainder))
                {
                    Console.WriteLine($"Found numbers {n} + {remainder} = 2020");
                    Console.WriteLine($"The answer is {n} * {remainder} = {n * remainder}");
                    break;
                }
            }
        }
    }
}

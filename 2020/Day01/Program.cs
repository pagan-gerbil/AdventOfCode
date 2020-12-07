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

            FindThreeNumbers(numbers, target);
        }

        private static int FindTwoNumbers(IEnumerable<int> numbers, int target)
        {
            foreach (var n in numbers)
            {
                var remainder = target - n;
                if (numbers.Contains(remainder))
                {
                    Console.WriteLine($"Found numbers {n} + {remainder} = {target}");
                    Console.WriteLine($"The answer is {n} * {remainder} = {n * remainder}");
                    return n;
                }
            }

            return -1;
        }

        private static void FindThreeNumbers(IEnumerable<int> numbers, int target)
        {
            foreach (var n in numbers)
            {
                var remainder = target - n;

                var n2 = FindTwoNumbers(numbers, remainder);
                if (n2 < 0) continue;

                var n3 = target - n - n2;
                Console.WriteLine($"Found three numbers {n} + {n2} + {n3} = {target}");
                Console.WriteLine($"The answer is {n} * {n2} * {n3} = {n * n2 * n3}");
                break;
            }
        }
    }
}

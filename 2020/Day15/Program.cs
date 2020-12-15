using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = _input.Split(',').Select(x => int.Parse(x)).ToList();
            var lastUsed = new Dictionary<int, int>();
            var counter = 1;
            foreach (var number in numbers.Take(6))
            {
                lastUsed.Add(number, counter);
                counter++;
            }
            
            while (counter < 30000000)
            {
                var lastNumber = numbers.Last();
                if (lastUsed.ContainsKey(lastNumber))
                {
                    numbers.Add(counter - lastUsed[lastNumber]);
                    lastUsed[lastNumber] = counter;
                }
                else
                {
                    numbers.Add(0);
                    lastUsed.Add(lastNumber, counter);
                }
                
                counter++;
            }

            Console.WriteLine($"The 2020th number is {numbers.Last()}");

        }

        private static string _example = @"0,3,6";
        private static string _input = @"11,18,0,20,1,7,16";
    }
}

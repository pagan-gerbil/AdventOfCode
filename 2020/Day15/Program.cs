using System;
using System.Linq;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = _input.Split(',').Select(x => int.Parse(x)).ToList();

            var counter = numbers.Count();
            while (counter < 2020)
            {
                var lastNumber = numbers.Last();
                if (numbers.Count(x => x == lastNumber) > 1)
                {
                    numbers.Add( numbers.LastIndexOf(lastNumber) - numbers.Take(numbers.LastIndexOf(lastNumber)).ToList().LastIndexOf(lastNumber));
                }
                else if (numbers.Count(x => x == lastNumber) == 1)
                {
                    numbers.Add(0);
                }
                
                counter++;
            }

            Console.WriteLine($"The 2020th number is {numbers.Last()}");

        }

        private static string _example = @"0,3,6";
        private static string _input = @"11,18,0,20,1,7,16";
    }
}

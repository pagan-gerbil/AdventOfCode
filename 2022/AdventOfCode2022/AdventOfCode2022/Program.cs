﻿namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Advent!");
            Console.WriteLine("Which day are we running?");
            var dayString = Console.ReadLine();
            if (!int.TryParse(dayString, out var day))
            {
                Console.WriteLine("Not a valid day.");
                return;
            }

            Console.WriteLine("Which puzzle part?");
            var puzzlePartString = Console.ReadLine();
            if (!int.TryParse(dayString, out var puzzlePart))
            {
                Console.WriteLine("Not a valid puzzle part.");
                return;
            }

            if (puzzlePart != 1 && puzzlePart != 2)
            {
                Console.WriteLine("Not a valid puzzle part.");
            }

            switch(day)
            {
                case 1: Day1.Run(puzzlePart); return;
                default: throw new NotImplementedException();
            }
        }
    }
}
namespace AdventOfCode2022
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
            if (!int.TryParse(puzzlePartString, out var puzzlePart))
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
                case 2: Day2.Run(puzzlePart); return;
                case 3: Day3.Run(puzzlePart); return;
                case 4: Day4.Run(puzzlePart); return;
                case 5: Day5.Run(puzzlePart); return;
                case 6: Day6.Run(puzzlePart); return;
                case 7: Day7.Run(puzzlePart); return;
                case 8: Day8.Run(puzzlePart); return;
                case 9: Day9.Run(puzzlePart); return;
                case 10: Day10.Run(puzzlePart); return;
                case 11: Day11.Run(puzzlePart); return;
                case 12: Day12.Run(puzzlePart); return;
                case 13: Day13.Run(puzzlePart); return;
                default: throw new NotImplementedException();
            }
        }
    }
}
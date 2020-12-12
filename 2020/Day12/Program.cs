using System;
using System.Text.RegularExpressions;

namespace Day12
{
    class Program
    {
        private static Regex _parser = new Regex(@"^(?<operation>[NSEWFLR])(?<amount>[0-9]+)$");

        static void Main(string[] args)
        {
            var instructions = _example.Split(Environment.NewLine);

            var xPos = 0;
            var yPos = 0;
            var direction = "E";

            foreach (var instruction in instructions)
            {
                var match = _parser.Match(instruction);
                var operation = match.Groups["operation"].Value;
                var amount = int.Parse(match.Groups["amount"].Value);

                Move(operation, amount, ref direction, ref xPos, ref yPos);
            }

            Console.WriteLine($"The Manhattan distance is {Math.Abs(xPos)} + {Math.Abs(yPos)} = {Math.Abs(xPos) + Math.Abs(yPos)}");
        }

        private static void Move(string operation, int amount, ref string direction, ref int xPos, ref int yPos)
        {
            switch (operation)
            {
                case "N":
                    yPos += amount;
                    break;
                case "S":
                    yPos -= amount;
                    break;
                case "E":
                    xPos += amount;
                    break;
                case "W":
                    xPos -= amount;
                    break;
                case "L":
                    direction = GetNewDirection(direction, amount *-1);
                    break;
                case "R":
                    direction = GetNewDirection(direction, amount);
                    break;
                case "F":
                    Move(direction, amount, ref direction, ref xPos, ref yPos);
                    break;
            }
        }

        private static string GetNewDirection(string direction, int amount)
        {
            var startingDirection = 0;
            switch (direction)
            {
                case "S":
                    startingDirection = 180;
                    break;
                case "E":
                    startingDirection = 90;
                    break;
                case "W":
                    startingDirection = 270;
                    break;
            }

            var newDirection = startingDirection + amount;
            while (newDirection < 0 || startingDirection > 360)
            {
                if (newDirection >= 360) newDirection -= 360;
                if (newDirection < 0) newDirection += 360;
            }

            switch (newDirection)
            {
                case 0: return "N";
                case 90: return "E";
                case 180: return "S";
                case 270: return "W";
            }

            return null;
        }

        private static string _example = @"F10
N3
F7
R90
F11";
    }
}

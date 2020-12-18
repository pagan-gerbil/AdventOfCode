using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day18
{
    class Program
    {
        private static Regex _parantheses = new Regex(@"\((?<inner>.+)\)");
        private static Regex _firstChunk = new Regex(@"^\(?(?<first>\d+) (?<op>[+\-*/]) (?<second>\d+)\)?");

        static void Main(string[] args)
        {
            var lines = _example.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];
                var matches = _parantheses.Matches(line);
                foreach (Match match in matches)
                {
                    //if (match.Value.Contains('(') || match.Value.Contains(')'))
                    //    continue;
                    var result = Parse(match.Groups["inner"].Value);
                    line = line.Replace($"{match.Value}", result.ToString());
                }

                while (line.Any(x=>!char.IsDigit(x)))
                {
                    var match = _firstChunk.Match(line);
                    var result = Parse(match);
                    line = line.Replace(match.Value, result.ToString());
                }

                lines[i] = line.Trim();
            }

            Console.WriteLine($"The sum of all lines is {lines.Sum(x => int.Parse(x))}");
        }

        private static int Parse(string input)
        {
            return Parse(_firstChunk.Match(input));
        }

        private static int Parse(Match match)
        {
            var n1 = int.Parse(match.Groups["first"].Value);
            var op = match.Groups["op"].Value;
            var n2 = int.Parse(match.Groups["second"].Value);

            switch(op)
            {
                case "+": return n1 + n2;
                case "/": return n1 / n2;
                case "-": return n1 - n2;
                case "*": return n1 * n2;
            }

            return 0;
        }

        private static string _example = @"2 * 3 + (4 * 5)";
    }
}

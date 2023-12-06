namespace Day06
{
    internal class Program
    {
        private static StringSplitOptions sso = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;

        static void Main(string[] args)
        {
            var input = _input1;

            Puzzle1(input);
            Puzzle2(input);
        }

        private static void Puzzle1(string input)
        {
            string[] lines = input.Split(Environment.NewLine);
            var times = lines[0].Substring(lines[0].IndexOf(':') + 1).Split(' ', sso).Select(long.Parse).ToArray();
            var distances = lines[1].Substring(lines[1].IndexOf(':') + 1).Split(' ', sso).Select(long.Parse).ToArray();

            Calculate(times, distances);
        }

        private static void Puzzle2(string input)
        {
            string[] lines = input.Split(Environment.NewLine);
            var times = new[] { long.Parse(lines[0].Substring(lines[0].IndexOf(':') + 1).Replace(" ", "")) };
            var distances = new[] { long.Parse(lines[1].Substring(lines[1].IndexOf(':') + 1).Replace(" ", "")) };

            Calculate(times, distances);
        }

        private static void Calculate(long[] times, long[] distances)
        {
            var result = 1;

            for (var i = 0; i < times.Count(); i++)
            {
                var time = times[i];
                var distance = distances[i];
                var hold = 1;
                var counter = 0;

                while (hold < time)
                {
                    var score = (time - hold) * hold;

                    if (score > distance)
                    {
                        counter++;
                    }

                    hold++;
                }

                result *= counter;
                Console.WriteLine($"Game {i} has {counter} solutions");
            }

            Console.WriteLine($"The magic number is {result}");
        }

        private static string _test1 = "Time:      7  15   30\r\nDistance:  9  40  200";
        private static string _input1 = "Time:        49     78     79     80\r\nDistance:   298   1185   1066   1181";
    }
}

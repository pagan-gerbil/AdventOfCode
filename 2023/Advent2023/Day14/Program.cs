using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var input = _input;

            var grid = input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

            var rows = grid.Length;
            var cols = grid[0].Length;

            var score = 0;
            char[][] newGrid = grid;

            var duplicates = 0;

            var repetitions = 1000000000;

            var scores = new List<int>();

            Console.WriteLine($"Beginning at {stopwatch.ElapsedMilliseconds}ms");

            for (var i = 0; i < repetitions; i++)
            {
                score = 0;
                newGrid = North(newGrid, rows, cols, ref score);
                newGrid = West(newGrid, rows, cols, ref score);
                newGrid = South(newGrid, rows, cols, ref score);
                newGrid = East(newGrid, rows, cols, ref score);
                score = CalculateScore(newGrid);

                if (scores.Contains(score))
                {
                    var index = scores.LastIndexOf(score);

                    if (scores[index] == scores[index - (i - index)])
                    {
                        Console.WriteLine($"possible loop: {i}, score: {score}");

                        int cycleLength = i - index;
                        var anticipatedCycles = (repetitions - i) / cycleLength;
                        var projectedIndex = i + (cycleLength * anticipatedCycles) + 1; // 0-based indexes....

                        if (projectedIndex == repetitions)
                        {
                            Console.WriteLine($"cycle length = {cycleLength}");
                            Console.WriteLine($"{repetitions - i} remaining");
                            Console.WriteLine($"{anticipatedCycles} anticipated cycles");
                            Console.WriteLine($"Score at position {i}: {score} (score at position {index}: {scores[index]}");
                            Console.WriteLine($"Score at position {i}: {score} (score at position {i - cycleLength}: {scores[i - cycleLength]}");
                            Console.WriteLine($"Score at position {projectedIndex}: {score}");
                            Console.WriteLine("WINNER WINNER VEGAN DINNER!\r\n\r\n");
                        }
                    }
                }

                scores.Add(score);

            }

            Console.WriteLine($"{duplicates} duplicates");
            Console.WriteLine(score);
            //Draw(newGrid, rows, cols);
        }

        private static int CalculateScore(char[][] newGrid)
        {
            var rows = newGrid.Length;
            return newGrid.SelectMany((x, i) => x.Select((y, j) => y == 'O' ? rows - i : 0)).Sum();
        }

        private static char[][] North(char[][] grid, int rows, int cols, ref int score)
        {
            var newGrid = GetNewGrid(rows, cols);

            for (var c = 0; c < cols; c++)
            {
                var allItems = grid.Select((x, i) => (x[c], i));
                var rocks = allItems.Where(x => x.Item1 == 'O').Select(x => x.i);
                var stops = new[] { -1 }.Union(allItems.Where(x => x.Item1 == '#').Select(x => x.i));

                foreach (var s in stops)
                {
                    if (s >= 0) newGrid[s][c] = '#';
                    int nextStop = stops.Any(x => x > s) ? stops.Where(x => x > s).Min() : rows;
                    var gaps = nextStop - s;
                    var items = rocks.Where(x => x > s && x < nextStop);
                    score += Enumerable.Range(s + 1, items.Count()).Sum(x => rows - x);
                    var newRocks = Enumerable.Range(s + 1, items.Count());
                    foreach (var nr in newRocks) newGrid[nr][c] = 'O';
                }
            }

            return newGrid;
        }

        private static char[][] West(char[][] grid, int rows, int cols, ref int score)
        {
            var newGrid = GetNewGrid(rows, cols);

            for (var r = 0; r < rows; r++)
            {
                var allItems = grid[r].Select((x, i) => (x, i));
                var rocks = allItems.Where(x => x.Item1 == 'O').Select(x => x.i);
                var stops = new[] { -1 }.Union(allItems.Where(x => x.Item1 == '#').Select(x => x.i));

                foreach (var s in stops)
                {
                    if (s >= 0) newGrid[r][s] = '#';
                    int nextStop = stops.Any(x => x > s) ? stops.Where(x => x > s).Min() : rows;
                    var gaps = nextStop - s;
                    var items = rocks.Where(x => x > s && x < nextStop);
                    var newRocks = Enumerable.Range(s + 1, items.Count());
                    foreach (var nr in newRocks) newGrid[r][nr] = 'O';
                }
            }

            return newGrid;
        }

        private static char[][] South(char[][] grid, int rows, int cols, ref int score)
        {
            var newGrid = GetNewGrid(rows, cols);

            for (var c = 0; c < cols; c++)
            {
                var allItems = grid.Select((x, i) => (x[c], i));
                var rocks = allItems.Where(x => x.Item1 == 'O').Select(x => x.i);
                var stops = new[] { rows }.Union(allItems.Where(x => x.Item1 == '#').Select(x => x.i).OrderDescending());

                foreach (var s in stops)
                {
                    if (s < rows) newGrid[s][c] = '#';
                    int nextStop = stops.Any(x => x < s) ? stops.Where(x => x < s).Max() : -1;
                    var gaps = Math.Abs(nextStop - s);
                    var items = rocks.Where(x => x > nextStop && x < s);
                    var newRocks = Enumerable.Range(s - items.Count(), items.Count());
                    foreach (var nr in newRocks) newGrid[nr][c] = 'O';
                }
            }

            return newGrid;
        }

        private static char[][] East(char[][] grid, int rows, int cols, ref int score)
        {
            var newGrid = GetNewGrid(rows, cols);

            for (var r = 0; r < rows; r++)
            {
                var allItems = grid[r].Select((x, i) => (x, i));
                var rocks = allItems.Where(x => x.Item1 == 'O').Select(x => x.i);
                var stops = new[] { cols }.Union(allItems.Where(x => x.Item1 == '#').Select(x => x.i).OrderDescending());

                foreach (var s in stops)
                {
                    if (s < cols) newGrid[r][s] = '#';
                    int nextStop = stops.Any(x => x < s) ? stops.Where(x => x < s).Max() : -1;
                    var gaps = Math.Abs(nextStop - s);
                    var items = rocks.Where(x => x > nextStop && x < s);
                    var newRocks = Enumerable.Range(s - items.Count(), items.Count());
                    foreach (var nr in newRocks) newGrid[r][nr] = 'O';
                }
            }

            return newGrid;
        }

        private static char[][] GetNewGrid(int rows, int cols)
        {
            var g = new char[rows][];
            for(var i = 0; i<cols;i++)
            {
                g[i] = new char[cols];
            }
            return g;
        }

        private static void Draw(char[][] newGrid, int rows, int cols)
        {
            for(var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    Console.Write(newGrid[r][c] == '\0' ? '.' : newGrid[r][c]);
                }
                Console.Write(Environment.NewLine);
            }
        }

        private static string _test = "O....#....\r\nO.OO#....#\r\n.....##...\r\nOO.#O....O\r\n.O.....O#.\r\nO.#..O.#.#\r\n..O..#O..O\r\n.......O..\r\n#....###..\r\n#OO..#....";
        private static string _input = "O#...OO.#.#..##.#..#O.OO...O##OO.......#......O.O...O..........O..#O..O.#.#.O.....##O.#O.##.........\r\n.OOO..OOO.O.#.....#.....#.#.....O..#..OO..#.....O#O##..##O#.OO....O##.OOO..O...#....O....#O..#...O..\r\nOOO#...O#...##.OOOO##.O..#.....O...#.O..#...#.O..OO..##.#....O#O..#O#..##...O.OO..#.#........#O....O\r\nO..#..#...#.O##.......OO#.#....O.##.O..O.O#.O..O#.....#...O..OO.O.#......O.###.........#.......##...\r\n..O.O.O..#O..OOOO..#..#..O..O#O...O....#.O#........OOO#.O...O..O#.#.O........#......#O.O...OO.#.O..O\r\n#..O.#..##....#...O..........#..O.#..##.O.....O.O.O..O..O.O.#.OO#.#..##.........#OO.O....##...#..##.\r\nOO.O#.#.O...O..#..#OO..O.............O.........O.#.......#OO#.O.#OOO.##OOO..OO#.....O#.O.#O.O##OO...\r\n.##...##O.....O..OO..O#.O.O.#....OOO.O.O#..#O#..#.O.OO...####O#......#.#O..O.O....#..O....#.#.#.O#.#\r\n.....#O..O.O.#......#..........#.OO...O.#O.O.....O.#OO.#.#.O#......OO..O.O.....#...O.O..OO...#O.O#..\r\n.O..#....#....OOO.O.#....O#O###....O.O#OO.............#...OOO.....#....O..O.......###............O..\r\n..#O.#....###..O...#.....OO#O.....#....###..O#.......#OO....O.O...#....#.O.O.#..O.##O...O..O#...##..\r\nO...O.#O.#O#....O.O#.......#............OO.....O.#O..O#O....O##O.OO..#..O..#O..O#O...##O.O.O.O#..O.#\r\nO#.O......#.......O....#...O.....#O#.#..O...O.###O.OO#.........O.....O..O...#.#O.....OO#..O.#...#...\r\n.#...O.......O.#.....O.......O.O..#....#..O#O.#..O.#..##.......##....O.#.....O........OO.O...O.....O\r\n..O..#.#O.O#...#.......#O#OO.#O....O...#O..O.O.#O.OO#......OO#....#...O.#...#O.#...O.#.OO#..O.#OO.O#\r\n.O.......O...#.......#....O..O......O.O.O#O.#O...O.#.....O..O...#OOO#..O...O##..OOO#....#..........O\r\nOO#..##O.O.O.O.#....O#.O#O.##..O......#.#.O.O..O.O...OO#.......#..O.#O.O#.OO....#O#O.O.O.#.O#O#.....\r\n#O#.O.......##OOO..OO...O#..#..O.O.##.O#....#OO....#...OO.#..#..O.......O#O.......#.O.O............O\r\n..O.OO.O#..OOO....OO.O...#.#.......#.O.......O..OOO.##.##.#...#.O.....O..O.......O.O.#..............\r\nOO#.....O.O.#.#...#.#.....O....#.#O..O......#..#..O...#.#....O#..OO....O.#.....O...O.#.O..#.........\r\n....O.#.O...O#....#.O.#.......O#.#.O##......#...O.#..O#..#.#O.O...#.....O......#O#.#.#O....O..O.O#.#\r\n.....###.O.O.O#.O.......O..OO#...#.#...#..O......#O....O...OOOO..O...#.#.#.#.O#..O.......OO.....#.#.\r\n...O.O...#O..O..#..O#.O....#O..#..O...#.O.O.OO....#O#O#.OOO##..#O..OOO#.O.O..O....#...O#..O...#O....\r\n.##.O...O..O.#.#OOO..O..O...O........#O.OO#..#OO......O....O.##...#..O#..O#...#..O.....O...##...O...\r\n.O.#.O#OO.#...O....#.O.O..OO.O#O...O#..##...O.O...#...O#OOO.....O.........O......#.O.#...........OO.\r\nO....O#O...#.OO#...#.........####..........O.#...#...O.O.O#.O..............##....O..O..O..#.#...##.#\r\n..O.OO.#.OO#..O.#O....O......O.............#...##...#.O..#..O###.#......O..##.O.........O.#........O\r\nO...#....#.......OO...O#O.......#.....#....OOO.#...OO.#O..O.#......#.##O....OO....O#.#.O..O...O..O..\r\n...#...#....O.#..OOOO#..O#..#.##O.#.#.O..#.O....OOO....#..#..#....OOO...#.O.O...#.#.#O.O..O.#..O....\r\n...O#.#...O.#.##O..O#..O.....OO#O...#.OO#..OO#O..OOO.O...#...O.#.O....O#...OOO..O...O....O....#.#..O\r\n#........#..O.###.#...O#.O#O.........##..O.O.#O.O.###O....##.#.#.#..O.#O....#OO#O.....O.........O.##\r\nO.O....#O.....O#...O#.....O##.OOO.#O.O..O....O..O...O....#...O.........O.#.O..#.#.O.O#O...#.#...O..O\r\n.O..O##.O........O.OOO#O...#....O.OOOO#O..O..............O..O.O.O...#..........#......O..O.O.#......\r\n.O....#OO#OO...#...O.##O.....#O.#.O.O...O.....OO#.O.......O#...#O..O#OOO.........##.....##...#...##O\r\n.O#..OO....OOO..#.......OOO...##....OO..O.O..........##...#.#...#....O..#....O..........#.#.#O#.#.O.\r\n##.......#O...O#.OO.#..O.O.O....#........#.O..........O.O.O..O.....#.OO#...#O#.O.OO..OO.O#..##....O.\r\n....#..#..#O.##O.#....#.#.OO.......##..O#.#.##......O.O.OO..##...O.#....#..O.#....#.O....#...#O..O..\r\n..O....#...OOO.#O..#..#...O..OOO..O#..#O......#..O...#.O..O.....#O...O#......#.......#O.O.........O#\r\n#.OO....O....###....#OOO..O.#..#........#OO.....#O..........#O...#..O.OO..#......##O..O##.........#.\r\n....#..O..........O.#.#..O.O.#....O..O....O..OO#....O.......OOO.....O.O.O..#....#.....O.O#.O#.##..O.\r\n#.O...OO..#....O.O..O...#O..O#.#O.#...O.....##..O...O##...O........#O..#O..O#.O.#.......O#.#...#.OO#\r\n.#.OOO#....#..O........OO....O#..###.O....O...O...O#.#O..#.OO........##..#..#...O..#.......OO...O#..\r\n.....OOO.#.O....O....#....O..O.O.O.O....O...#OO....#.OO#OO...O.OOOO.O...O.O....#OO...#O.#O..O....#..\r\n.#.#..........#O..OOO...#..O...#.............OO....#O...O#..O...#........O..#O#....OO.....OO##.O...#\r\n..OOO.OOO##.##O#...O.O..O......O#O..O##...##....O.#........O....##...O#O..O#.O...O.O...O....O.......\r\n..###.OO#..#.O.#....#..O..OO..O.###....O....#..O.O#.#......OO.....O#....O.OO....OO.O.O.O#........O..\r\n#O###.#......O......O......#...O#.O.O...O#OO.O#....O..#..O#.OO...O..O..#..#.#...#..##OO...OO....O..O\r\n..O...#..#O##O...#..#.#OO........O.#....O....................#...........#.....O..#...O#.#.O.O..#.#.\r\nO...#.O...#O..#..O.O.#.....O.#....O.O...##......#..#..OO...#..O..OOOOO..O..O...#..O.OO...O.O#O.#....\r\n........#...O.#.....O.O..O....#....#O......#..#........#O#.....#O##..OO.O...#......#OO.O#.O........O\r\n.O..##..O#....#....OO.#O.#O#OO#O.#..OOO#.......OO....O.#.....O....#..#..##...#O.....#....O..O....O..\r\n...##O..O.#.O..#.O.....#..O#.##OO#O#...O.##..#..#......O.##O.OO...O.#..#.O....#..O....O.O.........#.\r\n...O..O.#..O.#O#......O.#OO.O.##.##..O###.#.O........O..O..O#...#.O...O.....##....O.OO..#..O..#..O#.\r\nO....O......#..#O#.O....O...O.....#.O##O.O...#O.#O...O...#O...O.O#O...#O.#.#....#.#.#O....O.....OO..\r\n.O.##..###....OO................OOO.....#.#.OO.O...O#.OO.#..O........#...O.O#.O..O.O..O.O...O....O..\r\n...OOOO..O.#..O.#...O.##.O.O##.#..O.##..#.....##....O.O....O.O.##O.OO.#O.........#.##.O#...O.O..O...\r\n...O.O..#O.#..OO.#.#O#OO..#OO.O......O.O.OO....#..OO.......#O..O.##....O.O..##O#.#....OO.....#.O...#\r\nOO.....O....#O...O#.#..O...O#.#.O..#OO....O..#..OOO...O.........O....#.###O.OO....O....O............\r\n..O..O.....#O.#O#OO..##.O.........#..##.##.O..O#O#..O.O..O..O...###.....OO.......#.##..#O##..O#O..O.\r\n#O.#O...OOOO.O.###....#O..#O#O#.OO.....#O..#..#...O.#O.....#O....###.O....#..O...O..O....#......#...\r\nO##...#.....#..O.#.O.#.......#..O#.....#.O.O.#...O..O....OO.....#.O###.#.....OO....#OO..OOO..#......\r\n..O......#...#O..OO#O#OO....O.O.OOO.#O.OO.O......#....O##..O#.OO.##.#...O.##.....#...####.......##..\r\n.......OO#.O.O.#.O.......#O#........#O..##OO#.#O..##..OO.##OO....#..O......#..#.O..#...#.O.....OO...\r\n###.OO.O.O#..O.......#OO#.....#..O.O..O.O.......#..#O.##..#O..#..#...#O#......OO##O#OOO#...O#....O.#\r\n#O#.O.........#..O.#..#..#..............O..O..#..O##....O.##..O..O#..O.....#OO..O.#.......O....OO...\r\n#O#O....O#.#.O..O..#...#..#.#...#O.....O..##..#....O#.#.O.O.O...O.#...#.O....O#....#.....#.#..#...#O\r\nO...O........O.#..OOOO..#...O#O....##.O..#.......#..O..#..#O.#...OO..#.O..##..#...O#O.##.....#..#.O.\r\nO..#.##.......O..O......#..#.#.O...O#.O.......O#.O.O#O..#.O#.OOOOO.#OO.#.OO#....O....#...O####OO...#\r\n#O..O....O..#O..O.OO.#.O.##...#O#.....O...#.....#......##......O#O#.........#..#.O...O.O..........#.\r\nOOO.#.O.....O..OO.O#.#..#.#..#.............O#.......OOO#OO.O.#.#O...O.#..#...#..O...#.O#....O..O..##\r\nOO#........#.O.O....O#O...#O.#..#.#...#......##.......#..#..#.#.#.......O...##...O#...O..O.......O..\r\nO..#O......O....#O.O#..O........#......##..#...#O...OO....#.#...O........O.#O.......O.....O...#..O..\r\n..#O#.......O..O..O..........#...OO.#..OOO....O....#OOO#..O.....#.O#....O...#O.......#..#.O...#..##.\r\n...#O...O.OOO...O#.....#..#....##..#....#OO..O.OO#O.O#..#.O#O#O.....#OO#O...#.#O......O.....OO.....O\r\n..#...O.O.....O...O##O..O.....O..O..#O.O..O....O.#O....#O....O..O.O......O.....#..#....O......#.....\r\nO.#...O..#O.#...O.O.O..#..##...O.O..O#..O...O#....O........O#O.#O.#.O.......#.O.O..O.......OO.#.....\r\nO#...O.O#..#O#...............OO##.#..#...#O....O....#O.OO.O..O#.O.....#O.....O..O...#..#..#...#..O.O\r\n....OO.O#.#.......O..O.O.#..#.O#.O.....#............#....O..O..O..O.O..#..#..O.....#O.#O.#.O...O..#O\r\n.....#...OOO...#.O....O#...#.....O..OO....##O.OOO..#.O...#...O.##.O#O...O.....#.#...O...O.##.#.....O\r\n....##...O#O..O...##O.OOOO...#.#.....OOO..........O.O....O.#O.#..O#..O###...O....#.O#O......OOO..O.O\r\n#..#...OO##OOO.O#....#O#.O.....O#.#...##.#O..OO.#.#.O.O..OO.O#.........##.....O..O#..O......O.....##\r\n..O..OO.##O.##OO...O#.....#O.O..........#.#.......#..#..O....O...#......#..O.#.#...#.....#OO........\r\nO.......#O.....O....OO#.#..O.....OO..#..OOO.O....O##O#O.O....OO#......#.#.O......#.OO.O.#OO....#....\r\n....O...#.O....##.OO.....#O#.O...O....O#.O##.....O.#.O#........OO##...O..#.....O...O.....O...#..O#O.\r\n#.OO.#.O##....#..O....O..#...OO...#....#.##...OO....#O.........O..#......O.OO..#..#..##......#O...#.\r\nO...#.O.##..#.#OO#.O#.O###.O.#...O#..O###.......#....O.#.........O..O..#O#..O.O.O..OO..#.#...O#..O..\r\n......#..##..#..##...O#......#..#.#O#.....#.#.O...#.#O..#O..O.O.#..O.O.O....O....#....OO.#O......#.O\r\n..OO.##.#....O.O...O.#.....##O..#....#..OO#.#...##......#...OO...#.....#...#O..#O...#O......O#...O#.\r\nOOO.O##O...O..O.O#.##O#..OO.#.O..O...O.#O..O..#.#...O.O.......#O##.#..#.#.O.......O..OOO#.O....O#..O\r\n...O...OO.O...OO...O.....O#.#.#O.O.O.O..O..O...OO....O..###...##....#O....O...#.#.##....O....#O.O..#\r\n......#OO.........##.O...#..#.O.#..OO....O..O..O.#OO......OO.O#.......O...#..O.O#..OO.##.##.OOOOO...\r\n........O.....##..O.OO..O#.....O................O........OO#...##.....O#....#...#O.O..O...#.##..#O.O\r\n#OO.O.O.O.O#.OOO....#O#.#....#...#O#O.#.....OOO.....#.O..##.O##..O...........#......#...O.#.#.O.....\r\n.#O.........#.O.##O..#..O.O...OO..#..O.O#OO#..#O.O.O....#......O.....OO#..OO#.O.O..#.#.#OO.#..O.....\r\n...OO.O#O.O#.O.......O#..#OO.O.OO..O#.O.OO.O........O.OO..#..O...#.#.#....#.#.....OO.#.O..OO.....#..\r\n###.....O..#...OO.#OO........O....#O#OO...#.O...#.....#O...#.##..O..#O#..O##.O#.O.....#.O....#O...#.\r\n#O#.##......O....#.O##..#.......#.#..O......O.OOO.#....O##.#.O..OO...O..#...#.###......OO....O#.#.O#\r\n#OOOO#.#...OO..O..O..#..O..O...#OO.O.O.O#.#.##..#....####..O#....#O.OOO..O#O.#...O....#.O......O....\r\n.##OO....#......O..OOO......#..O.....#..O...O..#.#.........OO.O..##.......#.#O#.OO......O#O..O......\r\n........OOO.....OO........O.O.O.#O...#...O...O...O..O..#.....#O..#.#..OO....O...#..##..#O......O.#O#";
    }
}

﻿namespace Day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = _input;

            var grid = input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

            var rows = grid.Length;
            var cols = grid[0].Length;

            var score = 0;

            for (var c = 0; c < cols; c++)
            {
                var allItems = grid.Select((x, i) => (x[c], i));
                var rocks = allItems.Where(x => x.Item1 == 'O').Select(x => x.i);
                var stops = new[] { -1 }.Union(allItems.Where(x => x.Item1 == '#').Select(x => x.i));
                

                foreach (var s in stops)
                {
                    int nextStop = stops.Where(x => x > s).Any() ? stops.Where(x => x > s).Min() : rows;
                    var gaps = nextStop - s;
                    var items = rocks.Where(x => x > s && x < nextStop);
                    score += Enumerable.Range(s + 1, items.Count()).Sum(x => rows - x);
                }
            }

            Console.WriteLine(score);
        }

        private static string _test = "O....#....\r\nO.OO#....#\r\n.....##...\r\nOO.#O....O\r\n.O.....O#.\r\nO.#..O.#.#\r\n..O..#O..O\r\n.......O..\r\n#....###..\r\n#OO..#....";
        private static string _input = "O#...OO.#.#..##.#..#O.OO...O##OO.......#......O.O...O..........O..#O..O.#.#.O.....##O.#O.##.........\r\n.OOO..OOO.O.#.....#.....#.#.....O..#..OO..#.....O#O##..##O#.OO....O##.OOO..O...#....O....#O..#...O..\r\nOOO#...O#...##.OOOO##.O..#.....O...#.O..#...#.O..OO..##.#....O#O..#O#..##...O.OO..#.#........#O....O\r\nO..#..#...#.O##.......OO#.#....O.##.O..O.O#.O..O#.....#...O..OO.O.#......O.###.........#.......##...\r\n..O.O.O..#O..OOOO..#..#..O..O#O...O....#.O#........OOO#.O...O..O#.#.O........#......#O.O...OO.#.O..O\r\n#..O.#..##....#...O..........#..O.#..##.O.....O.O.O..O..O.O.#.OO#.#..##.........#OO.O....##...#..##.\r\nOO.O#.#.O...O..#..#OO..O.............O.........O.#.......#OO#.O.#OOO.##OOO..OO#.....O#.O.#O.O##OO...\r\n.##...##O.....O..OO..O#.O.O.#....OOO.O.O#..#O#..#.O.OO...####O#......#.#O..O.O....#..O....#.#.#.O#.#\r\n.....#O..O.O.#......#..........#.OO...O.#O.O.....O.#OO.#.#.O#......OO..O.O.....#...O.O..OO...#O.O#..\r\n.O..#....#....OOO.O.#....O#O###....O.O#OO.............#...OOO.....#....O..O.......###............O..\r\n..#O.#....###..O...#.....OO#O.....#....###..O#.......#OO....O.O...#....#.O.O.#..O.##O...O..O#...##..\r\nO...O.#O.#O#....O.O#.......#............OO.....O.#O..O#O....O##O.OO..#..O..#O..O#O...##O.O.O.O#..O.#\r\nO#.O......#.......O....#...O.....#O#.#..O...O.###O.OO#.........O.....O..O...#.#O.....OO#..O.#...#...\r\n.#...O.......O.#.....O.......O.O..#....#..O#O.#..O.#..##.......##....O.#.....O........OO.O...O.....O\r\n..O..#.#O.O#...#.......#O#OO.#O....O...#O..O.O.#O.OO#......OO#....#...O.#...#O.#...O.#.OO#..O.#OO.O#\r\n.O.......O...#.......#....O..O......O.O.O#O.#O...O.#.....O..O...#OOO#..O...O##..OOO#....#..........O\r\nOO#..##O.O.O.O.#....O#.O#O.##..O......#.#.O.O..O.O...OO#.......#..O.#O.O#.OO....#O#O.O.O.#.O#O#.....\r\n#O#.O.......##OOO..OO...O#..#..O.O.##.O#....#OO....#...OO.#..#..O.......O#O.......#.O.O............O\r\n..O.OO.O#..OOO....OO.O...#.#.......#.O.......O..OOO.##.##.#...#.O.....O..O.......O.O.#..............\r\nOO#.....O.O.#.#...#.#.....O....#.#O..O......#..#..O...#.#....O#..OO....O.#.....O...O.#.O..#.........\r\n....O.#.O...O#....#.O.#.......O#.#.O##......#...O.#..O#..#.#O.O...#.....O......#O#.#.#O....O..O.O#.#\r\n.....###.O.O.O#.O.......O..OO#...#.#...#..O......#O....O...OOOO..O...#.#.#.#.O#..O.......OO.....#.#.\r\n...O.O...#O..O..#..O#.O....#O..#..O...#.O.O.OO....#O#O#.OOO##..#O..OOO#.O.O..O....#...O#..O...#O....\r\n.##.O...O..O.#.#OOO..O..O...O........#O.OO#..#OO......O....O.##...#..O#..O#...#..O.....O...##...O...\r\n.O.#.O#OO.#...O....#.O.O..OO.O#O...O#..##...O.O...#...O#OOO.....O.........O......#.O.#...........OO.\r\nO....O#O...#.OO#...#.........####..........O.#...#...O.O.O#.O..............##....O..O..O..#.#...##.#\r\n..O.OO.#.OO#..O.#O....O......O.............#...##...#.O..#..O###.#......O..##.O.........O.#........O\r\nO...#....#.......OO...O#O.......#.....#....OOO.#...OO.#O..O.#......#.##O....OO....O#.#.O..O...O..O..\r\n...#...#....O.#..OOOO#..O#..#.##O.#.#.O..#.O....OOO....#..#..#....OOO...#.O.O...#.#.#O.O..O.#..O....\r\n...O#.#...O.#.##O..O#..O.....OO#O...#.OO#..OO#O..OOO.O...#...O.#.O....O#...OOO..O...O....O....#.#..O\r\n#........#..O.###.#...O#.O#O.........##..O.O.#O.O.###O....##.#.#.#..O.#O....#OO#O.....O.........O.##\r\nO.O....#O.....O#...O#.....O##.OOO.#O.O..O....O..O...O....#...O.........O.#.O..#.#.O.O#O...#.#...O..O\r\n.O..O##.O........O.OOO#O...#....O.OOOO#O..O..............O..O.O.O...#..........#......O..O.O.#......\r\n.O....#OO#OO...#...O.##O.....#O.#.O.O...O.....OO#.O.......O#...#O..O#OOO.........##.....##...#...##O\r\n.O#..OO....OOO..#.......OOO...##....OO..O.O..........##...#.#...#....O..#....O..........#.#.#O#.#.O.\r\n##.......#O...O#.OO.#..O.O.O....#........#.O..........O.O.O..O.....#.OO#...#O#.O.OO..OO.O#..##....O.\r\n....#..#..#O.##O.#....#.#.OO.......##..O#.#.##......O.O.OO..##...O.#....#..O.#....#.O....#...#O..O..\r\n..O....#...OOO.#O..#..#...O..OOO..O#..#O......#..O...#.O..O.....#O...O#......#.......#O.O.........O#\r\n#.OO....O....###....#OOO..O.#..#........#OO.....#O..........#O...#..O.OO..#......##O..O##.........#.\r\n....#..O..........O.#.#..O.O.#....O..O....O..OO#....O.......OOO.....O.O.O..#....#.....O.O#.O#.##..O.\r\n#.O...OO..#....O.O..O...#O..O#.#O.#...O.....##..O...O##...O........#O..#O..O#.O.#.......O#.#...#.OO#\r\n.#.OOO#....#..O........OO....O#..###.O....O...O...O#.#O..#.OO........##..#..#...O..#.......OO...O#..\r\n.....OOO.#.O....O....#....O..O.O.O.O....O...#OO....#.OO#OO...O.OOOO.O...O.O....#OO...#O.#O..O....#..\r\n.#.#..........#O..OOO...#..O...#.............OO....#O...O#..O...#........O..#O#....OO.....OO##.O...#\r\n..OOO.OOO##.##O#...O.O..O......O#O..O##...##....O.#........O....##...O#O..O#.O...O.O...O....O.......\r\n..###.OO#..#.O.#....#..O..OO..O.###....O....#..O.O#.#......OO.....O#....O.OO....OO.O.O.O#........O..\r\n#O###.#......O......O......#...O#.O.O...O#OO.O#....O..#..O#.OO...O..O..#..#.#...#..##OO...OO....O..O\r\n..O...#..#O##O...#..#.#OO........O.#....O....................#...........#.....O..#...O#.#.O.O..#.#.\r\nO...#.O...#O..#..O.O.#.....O.#....O.O...##......#..#..OO...#..O..OOOOO..O..O...#..O.OO...O.O#O.#....\r\n........#...O.#.....O.O..O....#....#O......#..#........#O#.....#O##..OO.O...#......#OO.O#.O........O\r\n.O..##..O#....#....OO.#O.#O#OO#O.#..OOO#.......OO....O.#.....O....#..#..##...#O.....#....O..O....O..\r\n...##O..O.#.O..#.O.....#..O#.##OO#O#...O.##..#..#......O.##O.OO...O.#..#.O....#..O....O.O.........#.\r\n...O..O.#..O.#O#......O.#OO.O.##.##..O###.#.O........O..O..O#...#.O...O.....##....O.OO..#..O..#..O#.\r\nO....O......#..#O#.O....O...O.....#.O##O.O...#O.#O...O...#O...O.O#O...#O.#.#....#.#.#O....O.....OO..\r\n.O.##..###....OO................OOO.....#.#.OO.O...O#.OO.#..O........#...O.O#.O..O.O..O.O...O....O..\r\n...OOOO..O.#..O.#...O.##.O.O##.#..O.##..#.....##....O.O....O.O.##O.OO.#O.........#.##.O#...O.O..O...\r\n...O.O..#O.#..OO.#.#O#OO..#OO.O......O.O.OO....#..OO.......#O..O.##....O.O..##O#.#....OO.....#.O...#\r\nOO.....O....#O...O#.#..O...O#.#.O..#OO....O..#..OOO...O.........O....#.###O.OO....O....O............\r\n..O..O.....#O.#O#OO..##.O.........#..##.##.O..O#O#..O.O..O..O...###.....OO.......#.##..#O##..O#O..O.\r\n#O.#O...OOOO.O.###....#O..#O#O#.OO.....#O..#..#...O.#O.....#O....###.O....#..O...O..O....#......#...\r\nO##...#.....#..O.#.O.#.......#..O#.....#.O.O.#...O..O....OO.....#.O###.#.....OO....#OO..OOO..#......\r\n..O......#...#O..OO#O#OO....O.O.OOO.#O.OO.O......#....O##..O#.OO.##.#...O.##.....#...####.......##..\r\n.......OO#.O.O.#.O.......#O#........#O..##OO#.#O..##..OO.##OO....#..O......#..#.O..#...#.O.....OO...\r\n###.OO.O.O#..O.......#OO#.....#..O.O..O.O.......#..#O.##..#O..#..#...#O#......OO##O#OOO#...O#....O.#\r\n#O#.O.........#..O.#..#..#..............O..O..#..O##....O.##..O..O#..O.....#OO..O.#.......O....OO...\r\n#O#O....O#.#.O..O..#...#..#.#...#O.....O..##..#....O#.#.O.O.O...O.#...#.O....O#....#.....#.#..#...#O\r\nO...O........O.#..OOOO..#...O#O....##.O..#.......#..O..#..#O.#...OO..#.O..##..#...O#O.##.....#..#.O.\r\nO..#.##.......O..O......#..#.#.O...O#.O.......O#.O.O#O..#.O#.OOOOO.#OO.#.OO#....O....#...O####OO...#\r\n#O..O....O..#O..O.OO.#.O.##...#O#.....O...#.....#......##......O#O#.........#..#.O...O.O..........#.\r\nOOO.#.O.....O..OO.O#.#..#.#..#.............O#.......OOO#OO.O.#.#O...O.#..#...#..O...#.O#....O..O..##\r\nOO#........#.O.O....O#O...#O.#..#.#...#......##.......#..#..#.#.#.......O...##...O#...O..O.......O..\r\nO..#O......O....#O.O#..O........#......##..#...#O...OO....#.#...O........O.#O.......O.....O...#..O..\r\n..#O#.......O..O..O..........#...OO.#..OOO....O....#OOO#..O.....#.O#....O...#O.......#..#.O...#..##.\r\n...#O...O.OOO...O#.....#..#....##..#....#OO..O.OO#O.O#..#.O#O#O.....#OO#O...#.#O......O.....OO.....O\r\n..#...O.O.....O...O##O..O.....O..O..#O.O..O....O.#O....#O....O..O.O......O.....#..#....O......#.....\r\nO.#...O..#O.#...O.O.O..#..##...O.O..O#..O...O#....O........O#O.#O.#.O.......#.O.O..O.......OO.#.....\r\nO#...O.O#..#O#...............OO##.#..#...#O....O....#O.OO.O..O#.O.....#O.....O..O...#..#..#...#..O.O\r\n....OO.O#.#.......O..O.O.#..#.O#.O.....#............#....O..O..O..O.O..#..#..O.....#O.#O.#.O...O..#O\r\n.....#...OOO...#.O....O#...#.....O..OO....##O.OOO..#.O...#...O.##.O#O...O.....#.#...O...O.##.#.....O\r\n....##...O#O..O...##O.OOOO...#.#.....OOO..........O.O....O.#O.#..O#..O###...O....#.O#O......OOO..O.O\r\n#..#...OO##OOO.O#....#O#.O.....O#.#...##.#O..OO.#.#.O.O..OO.O#.........##.....O..O#..O......O.....##\r\n..O..OO.##O.##OO...O#.....#O.O..........#.#.......#..#..O....O...#......#..O.#.#...#.....#OO........\r\nO.......#O.....O....OO#.#..O.....OO..#..OOO.O....O##O#O.O....OO#......#.#.O......#.OO.O.#OO....#....\r\n....O...#.O....##.OO.....#O#.O...O....O#.O##.....O.#.O#........OO##...O..#.....O...O.....O...#..O#O.\r\n#.OO.#.O##....#..O....O..#...OO...#....#.##...OO....#O.........O..#......O.OO..#..#..##......#O...#.\r\nO...#.O.##..#.#OO#.O#.O###.O.#...O#..O###.......#....O.#.........O..O..#O#..O.O.O..OO..#.#...O#..O..\r\n......#..##..#..##...O#......#..#.#O#.....#.#.O...#.#O..#O..O.O.#..O.O.O....O....#....OO.#O......#.O\r\n..OO.##.#....O.O...O.#.....##O..#....#..OO#.#...##......#...OO...#.....#...#O..#O...#O......O#...O#.\r\nOOO.O##O...O..O.O#.##O#..OO.#.O..O...O.#O..O..#.#...O.O.......#O##.#..#.#.O.......O..OOO#.O....O#..O\r\n...O...OO.O...OO...O.....O#.#.#O.O.O.O..O..O...OO....O..###...##....#O....O...#.#.##....O....#O.O..#\r\n......#OO.........##.O...#..#.O.#..OO....O..O..O.#OO......OO.O#.......O...#..O.O#..OO.##.##.OOOOO...\r\n........O.....##..O.OO..O#.....O................O........OO#...##.....O#....#...#O.O..O...#.##..#O.O\r\n#OO.O.O.O.O#.OOO....#O#.#....#...#O#O.#.....OOO.....#.O..##.O##..O...........#......#...O.#.#.O.....\r\n.#O.........#.O.##O..#..O.O...OO..#..O.O#OO#..#O.O.O....#......O.....OO#..OO#.O.O..#.#.#OO.#..O.....\r\n...OO.O#O.O#.O.......O#..#OO.O.OO..O#.O.OO.O........O.OO..#..O...#.#.#....#.#.....OO.#.O..OO.....#..\r\n###.....O..#...OO.#OO........O....#O#OO...#.O...#.....#O...#.##..O..#O#..O##.O#.O.....#.O....#O...#.\r\n#O#.##......O....#.O##..#.......#.#..O......O.OOO.#....O##.#.O..OO...O..#...#.###......OO....O#.#.O#\r\n#OOOO#.#...OO..O..O..#..O..O...#OO.O.O.O#.#.##..#....####..O#....#O.OOO..O#O.#...O....#.O......O....\r\n.##OO....#......O..OOO......#..O.....#..O...O..#.#.........OO.O..##.......#.#O#.OO......O#O..O......\r\n........OOO.....OO........O.O.O.#O...#...O...O...O..O..#.....#O..#.#..OO....O...#..##..#O......O.#O#";
    }
}

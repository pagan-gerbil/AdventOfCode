﻿namespace Day11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = _input;

            var lines = input.Split(Environment.NewLine);

            var expandedUniverse1 = new List<string>();

            foreach (var line in lines) 
            {
                expandedUniverse1.Add(line);
                if (line.All(x => x == '.')) expandedUniverse1.Add(line);
            }

            for (var i = lines[0].Length - 1; i > 0; i--) 
            {
                if (lines.Select(x => x[i]).All(x => x == '.'))
                {
                    for (var e = 0; e < expandedUniverse1.Count(); e++)
                    {
                        expandedUniverse1[e] = expandedUniverse1[e].Insert(i, ".");
                    }
                }
            }

            var galaxyStack = new Stack<(char c, int Row, int Col)>(expandedUniverse1.Select((r, Row) => r.Select((c, Col) => (c, Row, Col)).Where(x => x.c == '#')).SelectMany(x => x));

            var total = 0l;

            while(galaxyStack.Any())
            {
                var current = galaxyStack.Pop();
                foreach(var g in galaxyStack)
                {
                    var distance = Math.Abs(current.Row - g.Row) + Math.Abs(current.Col - g.Col);
                    total += distance;
                }
            }

            Console.WriteLine($"The sum of shortest paths is {total}");

            Draw(expandedUniverse1);
        }

        private static void Draw(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            Console.WriteLine(line);
        }

        private static string _test = "...#......\r\n.......#..\r\n#.........\r\n..........\r\n......#...\r\n.#........\r\n.........#\r\n..........\r\n.......#..\r\n#...#.....";
        private static string _input = "...................#.....#...............#......................#......................#...................#...........................#....\r\n..................................................#................................................#..............#.........................\r\n......#.....#.................#..............................................................#..............................................\r\n......................................................#..................#.....#............................................................\r\n.....................................................................................#.....................................#................\r\n.#............................................................................................................#.............................\r\n..................#......................#............................#..............................................................#.....#\r\n......................................................................................................#.............#.......................\r\n..............................................#........#........................#................................................#..........\r\n.....#......................#......................................#.....#...................#..............................................\r\n.........................................................................................................#..................................\r\n......................#...............#............#........................................................................................\r\n..................................................................................................#.........................................\r\n..........#..................................................................................................#..............#..........#....\r\n....#...........................#..........................#..............................#.................................................\r\n........................................#............................................#.................................#.........#..........\r\n...................................................................#...........#..........................#.................................\r\n............................................................................................................................................\r\n............................................#...............................................................................................\r\n....................#.................................#................................................................................#....\r\n............................................................................................#...............................................\r\n............................................................................#........#.........................................#............\r\n...#...................#..........................#...............#......................................................#..................\r\n..............................#........#....................................................................................................\r\n................#................................................................................#.......................................#..\r\n......#..............................................................#...................#..................................................\r\n.#.........................................#..........#.........#..............#........................#............#......................\r\n............................................................................................................................................\r\n...........#...................................#...............................................................#.............#..............\r\n........................#........#........................................#..........#..................................................#...\r\n....#.....................................................#.................................#......................................#........\r\n...............................................................#...................................#....................#...................\r\n#.............................................................................#..................................#.............#............\r\n.............................#..........#.............................#...................................#.................................\r\n........................................................#...................................................................................\r\n.............#........................................................................................................#................#....\r\n...#.............................................#..................................#......#.....#..........................................\r\n................................#..............................#............................................................................\r\n...................#........................................................#...............................................................\r\n#..........................#.........................................................................#......#...........#...................\r\n.......#...........................#.....#..............#.................................................................................#.\r\n......................#.........................#...........................................................................................\r\n.....................................................................................................................#.......#......#.......\r\n.............................................................#....................#...............#.........................................\r\n.........#..................................................................................................................................\r\n...............................#............#....................#.....#...............#..................#.................................\r\n....#...........#.........#.........................#..............................................................#..................#.....\r\n.....................#.......................................................................#..............................................\r\n....................................................................................................#.......................................\r\n.....................................#..........#...............................#...........................#..........#..........#.......#.\r\n..........................................................................................#.................................................\r\n.#..........................................#.............................#.................................................................\r\n.................#...........#............................#.............................................#......................#............\r\n.........#...........................................................#..............#.......................................................\r\n..................................................................................................#.............#.......#...................\r\n.............................................................................#.......................................................#......\r\n......#.............#...........#..........#........#...........#...........................................#...............................\r\n.........................................................................#..................................................................\r\n........................................................#...........#...........#................................................#..........\r\n........................................#....................#..........................................#.............#.....................\r\n..........#...................#................................................................#..........................................#.\r\n..................#.................................................................................#..........#............................\r\n..........................................................................................#.................................................\r\n..........................................................#...............#.................................................................\r\n............#................................#......................#..........#.........................................#......#...........\r\n..#.......................#..................................................................................#.....#........................\r\n.................................................#...........................................#..............................................\r\n.........#........#..................#...........................#.....................#...............#.............................#......\r\n......................................................................#..........................#.....................#....................\r\n............................................................................................................................................\r\n........................#.....................................................................................#............#............#...\r\n..............#............................#.................................#......#.......................................................\r\n........#..........#........................................................................................................................\r\n............................#............................................#..........................#.......................................\r\n.......................................................#......#.........................................................#......#............\r\n.........................................................................................#.....#..................#.........................\r\n.......................#................#.......................................#............................#.......................#......\r\n............................................................................................................................................\r\n.........#.......................................................................................................................#..........\r\n...#..........#................................#...........#......#.....................................................................#...\r\n....................................................................................#.......................................................\r\n.............................#.....................................................................................#.....#..................\r\n...................................#.....................................................#.............#....................................\r\n.....#.............#................................#......................................................................................#\r\n.............#............................................#...................#.................#.....................#.....#......#........\r\n#...............................#.........#..........................................#......................................................\r\n.........................#...............................................#..................................................................\r\n.................................................................................#......................................................#...\r\n....#...........#..................................#......................................................#.................................\r\n..............................................#.....................#.......................#...........................#...................\r\n..............................#.........................#.............................................#.........#...........................\r\n.........................................#.....................................#...............................................#............\r\n.#.........#..................................................#..........................#...........................#......................\r\n............................................................................................................................................\r\n.........................................................................................................................................#..\r\n.......#..........................................#.......................#................................................#........#.......\r\n............................................................................................................................................\r\n.................#.........#.........................................#.........................#.....#......#...............................\r\n............................................#..........#......................#......#......................................................\r\n....................................#.............................................................................#.........................\r\n...........................................................#................................................................................\r\n.................................................................................#........#...............#..............................#..\r\n.......#...........#..............................#.........................................................................................\r\n..#...............................................................................................#.................#............#..........\r\n..............................................#..........#...............#..................................................................\r\n..................................#.....#.....................#.......................#...............#......#.............#................\r\n..........................#.................................................................................................................\r\n....................................................#..................................................................#....................\r\n...........................................................................#..............#.....#...........................................\r\n#...................#...........................................................#...........................................................\r\n...........................................#....................#....................................................................#......\r\n.......#.....#........................................#....................................................#................................\r\n..............................#...................................................................#.........................................\r\n.............................................................................#.......................................#......................\r\n.....................#....................................................................................................................#.\r\n.................................#....................................#........................#............................................\r\n......#...........................................#.........................................................................................\r\n...........................................#................................................................................#......#........\r\n..........#...............#.........................................................#.......................................................\r\n..................#...........................................................#.............................................................\r\n...............................................................#............................................#.......#.......................\r\n....#........#...................................................................................#..........................................\r\n......................#...................................................#...........#................#....................................\r\n........#..............................................#...................................#....................#...........................\r\n..................................................#.......................................................................#..........#......\r\n.#...................................#..........................................................................................#...........\r\n..........................................#........................................#...............#........................................\r\n..........................#.....#........................................................................................................#..\r\n..................#...........................#..........#...........................................................#......................\r\n...................................................#......................#...................................................#.............\r\n.........#................................................................................#.................................................\r\n..............#................................................................#............................................................\r\n...........................#.........#..............................#...................................#..........#....................#...\r\n..................................................................................................#.............................#...........\r\n..#..............................................#..........................................................................................\r\n.................#.....................................................#.................#..................................................\r\n.................................#.........#...................................................#......#.........#...........................\r\n..........#.........................................#.....#......................#..........................................................\r\n....................#..........................#................#...........................................................#......#........\r\n#........................#.............#..................................#.................................#...............................";
    }
}

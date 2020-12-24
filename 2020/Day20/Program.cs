using System;
using System.Collections.Generic;
using System.Linq;

namespace Day20
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentTile = new Tile();
            var allTiles = new List<Tile>();

            foreach (var line in _example.Split(Environment.NewLine))
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                if (line.StartsWith("Tile"))
                {
                    if (currentTile.Id > 0) allTiles.Add(currentTile);
                    currentTile = new Tile { Id = int.Parse(line.Substring(4, line.Length-5)) };
                    continue;
                }

                if (string.IsNullOrEmpty(currentTile.Top))
                {
                    currentTile.Top = line;
                }

                currentTile.Left += line[0];
                currentTile.Right += line.Last();

                if (currentTile.Right.Length.Equals(currentTile.Top.Length))
                    currentTile.Bottom = line;
            }
        }

        public class Tile
        {
            public int Id { get; set; }
            public string Top { get; set; }
            public string Bottom { get; set; }
            public string Left { get; set; } = string.Empty;
            public string Right { get; set; } = string.Empty;
        }


        private static string _example = @"Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...";
    }
}

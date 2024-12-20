﻿using AdventUtils;
using AdventUtils.Models;
using System.Reflection;

namespace Advent2024;

internal class Day16 : DayBase
{
    protected override string _sample1 => "#################\r\n#...#...#...#..E#\r\n#.#.#.#.#.#.#.#.#\r\n#.#.#.#...#...#.#\r\n#.#.#.#.###.#.#.#\r\n#...#.#.#.....#.#\r\n#.#.#.#.#.#####.#\r\n#.#...#.#.#.....#\r\n#.#.#####.#.###.#\r\n#.#.#.......#...#\r\n#.#.###.#####.###\r\n#.#.#...#.....#.#\r\n#.#.#.#####.###.#\r\n#.#.#.........#.#\r\n#.#.#.#########.#\r\n#S#.............#\r\n#################";

    protected override string _part1 => "#############################################################################################################################################\r\n#...#.....................#.............#...........#.....#.#.........#.............#.......#...#.........#...........#.......#.#.........#E#\r\n#.#.#######.#############.#.#######.#####.#######.#.###.#.#.#.#.#.#####.#####.#####.###.#.###.#.#.#.#####.#######.#.###.###.#.#.#.#####.#.#.#\r\n#.#.......#.#...........................#.....#.#.#.....#...#...#.#.....#...#.....#...#.#...#.#...#.....#.....#...#.#...#...#.#.#.#.#...#.#.#\r\n#.#######.#.#.###.#.###.#.#.#####.#####.#####.#.#.#####.#####.#.###.#####.#.#####.###.#####.#.#########.#####.#.###.#.###.###.#.#.#.#.###.#.#\r\n#...#.......#...#.....#.#.#...#...#...#.....#.#.#...#...#...#.#.....#.....#.#.....#.#.#...#...#.#.......#.......................#...#...#...#\r\n###.#######.###.#######.#.#.#.#.###.###.###.#.#.###.#####.#.#.#############.#.#####.#.#.#.#.#.#.#.#######.#.#.#.#####.#.###.#.#.###.###.#####\r\n#...#.....#...#.........................#.#.#.....#.....#.#.#.#.............#...#...#.#.#.#.....#.#.....#.#...#.#...#.#...#.#...#...#.#.....#\r\n#.#.#.###.#.###.#.#.#####.#.#########.#.#.#.#####.#####.#.#.#.#.###########.###.#.#.#.#.#.###.###.#.#.###.#####.#.#.#.#.#.#.#####.###.#.###.#\r\n#.#.#.#.#.#.#...#.#.#...#.#...#...#...#...#...#...#.#...#.#...#.#.......#...#...#.#.#.#...............#...#.....#.#.#...#.#.#.....#.....#...#\r\n#.#.#.#.#.#.#.###.#.###.#.###.#.#.#.###.#.#.#.#.###.#.###.#####.#.#####.#.###.###.#.#.#.#.#.#.#.#.#.#.#.###.#####.#.#####.#.#.#####.###.#.#.#\r\n#.#.#.#.#.#.#.#...#...#...#...#.#.#.#...#.#...#.....#.....#.....#.#.............................#...#.#.#...#.....#...#...#.....#...#...#.#.#\r\n#.###.#.#.###.###.###.#.#######.#.#.#.#.###.#######.#########.#.###.#.#######.#.#######.###.#####.#.#.#.#.#.#.#####.#.#.#######.#.#####.#.#.#\r\n#.#...#.#...#.#...#...#.........#...#.#.....#.....#.#.........#.#...#...........#...#.....#.#.......#.#.#.#.#.#...#.#.#...#...#...#.......#.#\r\n#.#.###.###.#.#.#.#.#################.#.###.#.###.#.#####.#####.#.###.#########.#.###.###.#.#.#.#.###.#.###.#.#.#.#.#####.#.#.#####.#######.#\r\n#...#.....#.#...#.#.#.....#...#.......#.......#...#...........#.#.#.........#...#.......#.#...#.#.....#...#.....#.#.#.....#.#.......#...#...#\r\n#.#####.#.#.#####.#.#.###.#.#.#.#######.#.#####.###########.###.#.#####.###.###.#########.#####.#########.#######.#.#.#####.###.#######.#.###\r\n#.......#.#.......#.#...#.#.#...#.#.....#...#.......#...#.......#.......#.#...#...#.....#.....#...#.....#.........#.......#.#...#.....#.#...#\r\n#######.#.#########.#####.#.#####.#.#.#####.#.###.###.#.#.###########.###.###.###.#.###.###.#.#.#.#.#.#####.#####.#######.#.#.###.###.#.###.#\r\n#...#...#.......#.#.......#.#.............#.#...#...#.#...#...#.....#.....#...#.....#.....#.#.#.#...#.......#.........#...#.#...#.#...#.....#\r\n#.#.#.#.#.#####.#.#.#.#####.#.#######.###.#.#.###.#.#.#####.#.###.#.#.###.#.###.#.#######.###.#####.#########.#.#####.#.###.#.###.#.###.#####\r\n#.#.#.#.......#...#.#.....#.#...#.....#...#.#.#...#.#...#...#.....#.#.#...#.#.....#.....#...#.#...#.....#.....#.#.....#...#.#.#...#...#.....#\r\n#.#.#.#.#.#.#####.#.#.###.#.###.#.#####.###.###.###.#.#.#.#########.###.#.#.###.###.###.###.#.#.#.###.###.#####.#.#.#######.###.#####.###.#.#\r\n#.#.#.....#.......#.#.........#...#...#.#...#...#...#...#...#.....#.....#.....#...#.#.#.#...#.#.#.#...#.......#.#...#.....#...#.#...#.#...#.#\r\n#.#.###.#.#.#######.#.#######.#####.#.#.#.#.#.###.#.#.#####.#####.#######.###.#.#.#.#.#.###.#.#.#.#.###.#######.###.#.###.###.#.#.###.#.#.###\r\n#.#.....#.#.....#.#.#.#.....#.......#.#.#.#.#.#...#.#.....#.......#.....#.#.#.#...#...#...#...#.#.#...#.#.#...#...#...#.#.....#...#...#.#...#\r\n#.#####.#.#.###.#.#.###.###.#########.###.#.#.#.###.#####.###.#.#.#.#.###.#.#.###.###.###.#.###.#.###.#.#.#.#.###.#####.###.#.###.#.###.#.#.#\r\n#...#.....#.#.....#.#.....#.#...#.........#.#.#...#.#...#...#.#.....#.....#.#.#...#...#.#.#.#...#...#.#...#.#.....#.........#.....#.......#.#\r\n#.#.#.#.#.#.###.###.#.#####.#.#.###########.#.###.#.#.#.###.#.#.###########.#.#.###.###.#.###.#####.#####.#.#.#########.#################.#.#\r\n#.#...#.......#.#...#.#.....#.#.#.....#.....#...#.#...#.#...#.#.#.....#.....#.#...#...#.#...#.#...#.....#.#.#.#...#...#.....#...........#...#\r\n#.#.###.#.#.#.#.#.###.#.#.###.#.#.###.#.#######.#.#####.#.###.#.###.#.#.#.#.#.###.###.#.###.#.#.#.###.###.#.###.#.#.#.#####.#.#########.#.#.#\r\n#...#...#.#...#.#.......#.#...#...#.#.#...#.....#.....#.#.#...#.....#.#.#.#.#...#...#...#.......#.#.#.....#.#...#...#...#.#.......#.....#.#.#\r\n###.#.#.###.#############.#.#######.#.###.###.#.#####.###.###.#.#####.###.#####.###.###.#.#.#####.#.#######.#.#########.#.#######.#.#####.###\r\n#.#.#.#...#.......#...#...#.#.......#...#.....#.....#.....#...#...........#.....#.#.#...#.#...#...#...#.....#.#.....#...#...................#\r\n#.#.#.#.#.#.#####.#.#.#.#.#.###.#.#.###.#########.#.#######.###.###########.#####.#.#.###.#####.###.#.#.#####.###.#.#.#.#######.###.#.###.#.#\r\n#.#.#.#...#.....#...#.#.#.#...#.#...#.#...#.....#.#.........#.......#...#...#.......#.#.#.......#...#.#.....#...#.#.#.#.#.....#...#.#.#...#.#\r\n#.#.#.#.###.###.#.###.#.#####.#.#.#.#.###.#.#.#.#.#######.#######.###.#.#.###.#.#####.#.#########.###.#####.###.#.#.#.#.#.###.###.#.#.#.#.#.#\r\n#.#.#.#.#...#...#.#...#.....#.#.#.#.....#...#.#.#.......#.......#.#...#.#...#...#...#.........#...#.#.#...#...#...#.#.#.#...#.#...#...#...#.#\r\n#.#.#.#.###.#.###.#.#.#####.#.#.#.###########.#.#######.#.#####.#.#.###.###.#.#.#.###.#######.#.###.#.###.###.#####.#.###.###.#.###.#.###.#.#\r\n#...#.#.....#.#...#.#...#.#...#.#...........#.#.....#.#.#...#.#.#.#...#.....#.....#.......#...#...#.#...#...#.......#...#.#...#.#...#...#...#\r\n#.###.#######.#####.###.#.#####.#####.#####.#.#####.#.#.###.#.#.#.###.#####.#######.#####.#.#####.#.###.#.###########.#.#.#.###.#.#####.#.#.#\r\n#...#.....#...#.....#.#.....#.#.......#.....#.#...#...#.#...#.#.#...#.....#.#.........#...#.#.....#.......#.........#.#...#...#...#.......#.#\r\n###.#.###.#.###.#####.#####.#.#.#.#####.#####.###.###.#.###.#.#.#.#######.###.#########.###.#.###########.#.#######.#####.###.#.#########.#.#\r\n#...#...#.#...#...#.....#...#.#.#...#...#.....#...#...#...#...#.........#.....#.........#.....#.........#...#.....#.#...#...#.#.#.....#...#.#\r\n#.#####.#.###.###.#.#.#.#.###.#.###.#.###.#####.#.#.###.#.###.#########.#######.###.#.###.#####.#######.###.#.###.#.#.#.#####.#.#.###.###.#.#\r\n#.....#.#.#.......#.#...#.#.........#...#.......#.#...#...#...#.........#.........#.#.....#.....#.#...#...#.#...#.#.#.#.#.....#...#.#...#.#.#\r\n#####.###.#########.###.#.###.#####.#.#.#.#.#.#######.#.#####.#.#.#.###.###.#####.#.###.#.#.#####.#.#.###.#.#.#.#.#.#.#.#.#########.###.#.#.#\r\n#.....#...#.......#...#.#.#...#.....#.#.#.#.#.........#.....#...#.....#...#...#...#.......#.#.......#...#.#.#.#.#.#.#.#...#...........#.#.#.#\r\n#.#####.###.#####.#####.#.#.#.#.###.###.#.#####.###########.#######.#.#.#.#.#.#####.#######.#.#####.#.###.#.#.#.#.#.#.#######.#.#####.#.###.#\r\n#.....#.....#...#...#...#.#.#...#...#...#.#...#...#...#.....#.....#.#.#.....#...#...#.....#...#...#.#...#...#.#.#.#.#.......#.#.#.....#.#...#\r\n#####.#######.#.#.#.#.#.#.#.#####.###.###.#.#.###.###.#.#####.###.#.#.#########.#.#.#.###.###.#.#.#####.###.#.#.#.#.#######.###.#####.#.#.###\r\n#...#.#.......#.#.#.#.#.#...#.....#.#...#...#.#.......#.......#...#.#.#.......#.#.#.#...#...#...#.#.........#.#.#...#.....#...#.....#.#.#...#\r\n#.#.#.#.#######.###.#.#######.#.###.#.#.#####.#################.#####.#.#####.#.#.#.###.###.###.#.#.#####.###.#.###.#.###.#.#.#.###.#.#.###.#\r\n#.#...#.#...#.....#.#.......#...#...#.#.....#.#.........#.....#.......#.......#...#...#.#.#...#.#.#.......#...#...#.#.#...#.#.#.#...#.#.#...#\r\n#.#####.#.#.#####.#.###.###.#.#.#.#.#.#.#####.#.#######.#.#.#####.#####.#.#####.#####.#.#.###.#.#.#.#######.#####.#.#.#.###.#.###.###.#.#.###\r\n#.................#...#.#.....#.#.#.#.#.....#...#.....#...#.....#.#.....#.#.#...#...#.#...#.#.#.#.#...#.....#...#.#...#.....#...#.#...#.#...#\r\n#####.#.###.#.#.###.#.#.#####.#.###.#.#####.#####.#.#.#########.#.#.#####.#.#.###.#.#.###.#.#.#.#.###.#.#####.###.#########.###.#.#.###.###.#\r\n#...#.#.#...#.#...#.#.#.#...#.#...#.....#.#.......#.#.........#...#.#...#.#...#...#.#...#.#...#.#.#...#.....#...#...#...#...#...#.#...#...#.#\r\n###.#.#.###.#.###.#.#.#.#.#.#####.#.###.#.#########.###.#.#########.#.###.###.#.###.#.###.#.#.###.#########.###.###.#.#.#.###.###.###.###.#.#\r\n#...#.#.....#.#...#.#.#.#.#.....#.#.........#.....#...#...#...#.....#...#...#.#.#.#.#.#...#.#...#.............#...#.#.#.....#.....#.....#.#.#\r\n#.###.#.#####.#.#####.#.#.###.###.#########.#.#.#.###.#####.#.#.#######.###.###.#.#.###.###.###.#############.###.#.#######.#.#.#######.#.#.#\r\n#...#.#...#...#.........#...#...#.......#...#.#.#.#...#.....#...#...#.....#.#...#.#...#.......#.......#...#.......#.......#...#.......#.#.#.#\r\n#.#.#.#.#.#.###########.#.#####.#######.#####.#.#.#.#.#.#########.#.#.#.###.#.###.###.#######.#######.#.#.#######.#####.#.#########.#.###.#.#\r\n#.#.#...#.#.#...........#.#.....#.....#.#.......#.#.#.#.......#...#...#.#...#...#...#.......#.#...#...#.#.......#.#...#.#.#.......#.#.....#.#\r\n###.###.#.#.#.#.#.###.#.#.#.#####.###.#.#.#####.#.#.#########.#.#########.#.###.###.#####.###.###.#.###.#######.###.#.###.#.#####.#.#.#####.#\r\n#.....#...#...#.#.#...#.#.#.....#.#.#...#.#...#...#.#.....#...#...#...#...#...#.......#.#...#.....#.#.....#.....#...#.....#.#...#.#.#.......#\r\n#.#####.#####.#.###.#.###.#####.#.#.#####.###.#.###.#.###.#.#####.#.#.#.#.#.#########.#.###.#####.#.###.#.###.#.#.#######.#.#.###.#.#.#.###.#\r\n#.................#.#.....#...#.#.#.......#...#.....#.#.#...#...#.#.#...#.#.........#...#.#.......#...#.#...#...#.#...........#...#.....#.#.#\r\n#.#.###.#.#.###.#.#.#.#####.###.#.#.#####.#.#.###.###.#.#####.#.#.#.#######.#######.###.#.###.#######.#.###.###.#.#.#######.###.#####.###.#.#\r\n#.#.....#.#...#.#.#.#.#.......#...#.......#.#.#...............#...#.......#.#.....#.#...#...........#.#...#...#.....#...........#.#.........#\r\n#.#####.#.###.#.#.#.#.#.#####.#########.#.#.#.#.###.#######.#####.#######.#.#####.#.#.###.#.#########.#######.#.#.###.#####.#.###.#.#.#######\r\n#.....#.#.#.#.#.#.#...#...#.........#...#.#.#.#.#.#.........#...#.....#.#.#.#...#.#.#...#...........#.#.......#.#.#...#.....#.......#.#.....#\r\n#.#.###.#.#.#.###.#.#.#####.#########.#.#.#.###.#.###.#######.#.#####.#.#.#.#.#.#.#.###.###########.#.#.#######.#.#.#####.###.#######.#.###.#\r\n#.#...#...#...#...#...#...#...#.....#...#.#...........#.......#.#.....#.#.#...#...#.#...#.............#...#.#...#.#.....#.....#...#.......#.#\r\n#.###.#.###.###.#####.#.#.###.#.###.#.###.#.#########.#.###.#####.#####.#.###.#.#.#.#.###.#########.#.#.#.#.#.#########.#.#####.###.#######.#\r\n#.#.......#.#...#...#.#.#.....#.#.#.#.#...#.#...............#.....#...#.#...........#.....#...#...#.#.#.#.#.............#.#...........#...#.#\r\n#.#.#######.#.#.#.###.#.#.#####.#.#.#.#.#####.#.#############.#####.#.#.#####.###.#.#####.#.#.#.#.#.#.#.#.###############.#############.#.#.#\r\n#.#.....#...#.#.#...#.#.#.#...........#.......#.#.......#...#.#.....#.#...#...#...#.......#.#...#...#.#.#...#.....#.#...#...#.....#...#.#.#.#\r\n#######.#.#.#.#.###.#.#.###.#########.#########.#.#####.#.#.#.#.###.#####.#.#.#.#####.#.#.#.#########.#.###.#.#.#.#.#.#.###.#.###.#.#.#.#.#.#\r\n#.......#.#...#...#...#...#.#.......#.#.......#.#.....#.#.....#...#...#.....#.#.#...#.#.......#.......#.....#.#.#.....#...#...#.#...#...#.#.#\r\n#.#####.#.#.#####.#.###.#.#.#.#####.###.#####.#.#####.#.#.#####.#####.#.###.#.###.#.###########.#######.#.#####.#####.###.#####.#########.#.#\r\n#.#...#.#.........#.#...#...#...#.#.#...#...#.#.#.....#.#.#.#...#...#.#.#...#.#...#.....#.......#.....#.#.#...#.......#.#...#.........#.#...#\r\n#.#.#.#.###.#######.#########.#.#.#.#.#.#.###.#.#.###.#.#.#.#.###.#.#.#.#.###.#.#######.#.#####.#.###.#.#.#.#.#.#######.#.###.###.###.#.###.#\r\n#...#.#...........#.....#...#.#.#.....#...#...#.#.#...#...#.#.#.#.#...#...#...#.#.......#.#.....#...#.#.#...#.#.#.......#.....#.#...#.#...#.#\r\n#.###.#####.#####.#.###.#.#.#.#.#########.#.###.#.#.###.###.#.#.#.###.#####.###.###.#####.###.#.#.#.#.#######.#.###.###########.###.#.#.#.#.#\r\n#.#...#.#...#...#...#.#.#.#.#.#.....#.....#.#...#.#.....#...#...#.#.......#.#.....#.....#.#...#.#.#.#.....#...#...#.........#...#...#...#.#.#\r\n###.###.#.#.#.#.###.#.#.#.#.###.###.#.#####.#.#.#.###.###.#.#.#.#.#######.#.###.#.#####.#.#.#####.#.#####.#.#####.#####.###.#.#.#.#########.#\r\n#...#.....#...#.....#.#...#...#...#.......#.#...#...#...#.#.#.....#...#...#...#.#.#...#...#.#...#.#.#.......#...........#.....#.#.....#.....#\r\n#.###.#####.#########.#######.###.#.#.###.#.###.###.###.#.#.#.###.#.#.###.###.#.#.#.#.#####.#.#.#.#.#################################.#.#####\r\n#.#.....#...........#.......#.#...#.#.#.#...#.....#...#.#.#.#...#...#...#.....#...#.#...#.....#.#.#.#.....................#.........#.......#\r\n#.#####.#.#.#######.#.#.#####.###.#.#.#.#####.#.#####.#.#.#.###.#######.###.#.###.#.#####.#####.#.#.#.#####.#############.#.###.###.#########\r\n#.#...#...#...........#.....#...#.#.#.#.......#.......#...#...#.#.#.....#...#.....#...#.....#...#.#.......#.....#.......#.#.................#\r\n#.#.#.#################.###.###.#.#.#.#.#####.#.#######.###.###.#.#.#########.#####.#.#.#####.###.#####.#.#####.#.###.#.#.###.#.#####.###.#.#\r\n#...#.........#.........#.#...#.#.#.....#.....#...#.......#.#...#.#.................#.#...#...#...#...#.#.....#.#.#...#.....#.#.......#.....#\r\n#######.#####.#.#########.###.#.#.#.#########.###.#.#######.#.###.###.#.#############.###.#.###.###.###.#####.#.###.###.###.#.#########.#####\r\n#.....#.#.....#.#.........#.#...#.#.....#...#...#.#.#...#...#.......#.#.#.#.........#.....#.....#.....#.#.....#.....#...#...#.........#.....#\r\n#.###.###.###.#.#######.#.#.#########.#.#.#.#.#.#.#.###.#.###.#####.#.#.#.#.#.#####.#################.#.###.#####.###.#.#######.#.#########.#\r\n#...#.....#.#.#...............#.....#.#...#.#...#.#...#.#.#.......#.#...#...#.#...#.....#.#.........#.#...#.....#.#.....#.....#...#.....#...#\r\n###.#######.#.###############.###.#.#.#####.#####.###.#.#.#.#####.#.#####.###.#.#.#####.#.#.###.###.#.###.###.#.#.#.###.#.###.#.###.###.#.#.#\r\n#...#.....#...#.....#.......#.....#.#.#.....#...#...#...#.......#...#.......#.#.......#.#.....#...#.....#.#...#.#.#...#.#...#...#...#.....#.#\r\n#.###.#.###.###.#.#.###.###########.###.#####.#.###.###.#######.#########.###.#######.#.#########.###.###.#.###.#####.###.#.#####.#######.#.#\r\n#...#.#.....#...#...#...#.........#...........#.....#.#.#.......#.......#.#...#.....#.........#...#...#...#...#.......#...#.....#.......#...#\r\n###.#.#########.#.###.#.#.###.#.#.###.###.###########.#.#.#.###.#.#####.###.#.#.###.#.###.###.#.###.###.#####.###.#####.#####.#########.#.###\r\n#...#.......#...#.....#.#...#...#...#.#...#...#.......#.#.#.#.....#...#.....#...#...#.#.....#...#.#...#.#...#...#.#...#.#...#.....#.....#.#.#\r\n#.#########.#.#.#####.###.#######.###.#.###.#.#.#.#####.#.#.#######.#.#######.###.###.#.###.#####.###.#.#.#.###.#.#.#.#.#.#.###.#.#.#####.#.#\r\n#.........#...#.#.....#...#.....#.....#.#...#...#.#.......#.#.......#.......#.#.....#.#...#...#.#.....#...#.#...#.#.#.#.#.#.................#\r\n#.#.#.#.#.#######.###.#.###.###.###.###.###.#.#####.#####.#.#.#########.###.#.#####.#.###.#.#.#.#.#########.#.#.#.#.#.#.#.#######.#####.###.#\r\n#...#.#.#...........#.#.#...#.#...#...#.#...#.#.....#.....#...#...#...#...#.#.....#.#.....#...#...#...#.....#.#.#.#.#...#.....#...#.........#\r\n#.###.#.#############.#.#.###.###.#####.#.#####.#####.#.#.#####.#.#.#.#####.#####.#.###.#.#.###.###.#.#.#####.###.#.#########.#####.#####.###\r\n#...#.#.#.....#.#.....#.#.#.....#.#.....#.#.....#.....#.#.#...#.#.#.#.........#...#.#...#.#.#...#...#.#.#...#.....#...#.....#...............#\r\n###.#.#.#.#.#.#.#.###.#.#.#####.#.#.#####.#.#####.###.#.#.#.#.#.###.#####.#####.###.#.###.#.#####.###.#.#.#.#.#######.###.#.#.###.#.#.#.###.#\r\n#.#.#...#.#.#.#.#...#.#.#.......#...#.....#...#.....#.#.#.#.#...#...#...#.#.....#.#.....#.#.#...#...#.#...#.........#.....#.#.#...#.#...#...#\r\n#.#.#######.#.#.###.#.#.#######.#####.#.#####.#.#.#.#.#.#.#.###.#.#####.#.#.#####.#.###.#.#.#.#.###.#.#.#.#################.###.#.#.###.#.#.#\r\n#.#.#.......#.#.#...#.#.#...#...#.#...#.....#.#.#.#...#.#...#...#.....#...#.#...........#.#.#.#.#...#.#.#.................#.....#.#...#.#.#.#\r\n#.#.###.#####.#.#.#####.#.###.###.#.#######.#.###.#####.#########.###.#.###.#####.###.###.#.#.#.#.###.#############.#####.###.#######.#.#.#.#\r\n#.#.....#...#.#.#.......#.#...#.....#...#...#.........#...#.....#.#...#...#...#.....#.....#...#.#.#.........#.....#.....#.....#...#...#.#.#.#\r\n#.#######.###.#.#########.#.#####.#####.#.#########.#####.#.###.#.#.#########.#.###.#.#########.#.###.#####.#.###.###.###.#####.#.#.###.#.#.#\r\n#.........#...#.......#...#.....#.......#.........#.....#.....#.#.#...#...#...#...#...........#.#.....#...#.#.#...#...#...#.....#.#.#...#.#.#\r\n#.#####.###.###.###.#.#.#######.#######.###.#####.#####.#####.#.#####.#.#.#.#####.#######.#####.#####.#.#.#.#.#.#######.#.#.#####.#.###.#.#.#\r\n#...#.#...#.#...#...#.#.......#.#.#.....#...#...#.....#.......#.#...#.#.#.#.....#.#.....#.#...#.......#.#.#...#.#.......#...#.....#...#...#.#\r\n###.#.###.#.#.#.#.###.###.###.#.#.#.#.###.###.#.#####.###.###.#.#.#.#.#.#.#.###.#.#.#.###.#.#.#########.#######.#.#.#########.#####.#.#######\r\n#.....#...#.#...#.#.#.....#...#.#...#...#.....#.....#.....#.....#.#...#.#.#...#.#.#.#.....#.#.......#.........#.#.#.#.#.....#.....#.#.......#\r\n#######.###.#.###.#.###.#####.#.#.###.#.###########.#######.###.#.#####.#.#####.#.###.#####.#######.#.#####.#.#.###.#.#.#.#######.#.#######.#\r\n#.....#.#...#...#.#.....#...#.#.#.#...#.....#...#...#...#...#.......#...#.......#...#.#.#...#.........#...#.#.#.....#.#.#.....#...#.#.#...#.#\r\n#.###.#.#.#####.#.#.#####.#.###.#.#######.#.###.#.###.#.#.#########.#.#.#########.#.#.#.#.#.#####.#####.###.#########.#.#####.#.###.#.#.#.#.#\r\n#.#.....#.....#.#.#...#.....#...#.........#.#...#...#.#.......#.....#.#.#.......#.#.#...#.#...............#.......#...#.#.#...#.#.....#.#.#.#\r\n#.###########.#.#.###.#.###.#.#############.#.#.###.#.#######.#.###.#.#.#.#####.###.###.#.###.#.#####.###.#######.#.#.#.#.#.###.#######.#.#.#\r\n#...#.......#.#.#.#.#.#.#.#...#.........#...#.#.#.#...#...#.....#.#.#.#.#.#...#...#.#...#.....#.....#...#...#...#...#.#...#...#.......#.#.#.#\r\n###.#.###.###.#.#.#.#.#.#.#####.###.###.#.###.#.#.#####.#.#######.#.#.###.#.#####.#.#.#########.###.###.#.#.#.#.#####.#.#.###.#######.#.#.#.#\r\n#...#...#.....#.#.#.#.#.#.........#.............#.#.....#.......#.#.#.....#.#.....#.#.......#.#.#.#.....#.#.#.#.....................#...#.#.#\r\n#.#####.#######.#.#.#.#.#######.#.#.###########.#.#.###########.#.#.#######.#.#####.#######.#.#.#.#######.#.###.#.#.###.###.###.#########.#.#\r\n#.#...#.......#.#.#...#.......#.................#.#...#.........#.#.......#.#.#...#.#.........#...#.......#...#...#...........#.#.......#.#.#\r\n#.#.#.#####.#.#.#.###########.#.#.#.#.#.#.#.#####.###.#.#########.#######.#.#.#.#.#.#.###########.#####.#####.#####.#.#.#####.#.#.#####.#.#.#\r\n#...#.......#.#.#...............#.#.#...#.#.........#.#...#.....#.......#...#.#.#...#...................#.#...#.........................#.#.#\r\n#.#.###.#.#.#.#.#####.###.#######.#.#####.#######.###.###.#.###.#.#.#######.#.#.#######.#.#####.#.#####.#.#.###.#.#####.###.###.#####.#.#.#.#\r\n#...#...#.#...#.#.....#...#.......#.....#.#.....#.#.....#.#...#.#.#...#...#.#.#.#.......#.....#.....#.....#.....#...............#.....#...#.#\r\n###.#.#####.###.#.###.#.###.#.#####.#.###.#.###.#.#.###.#.#.#.#.###.#.#.#.#.#.#.#############.###.#.#.#.#############.###.#.#.###.#########.#\r\n#.#.#.....#...#.#.#.#.#.#...#.#.#...#.#...#...#.#.#...#.#.#.#.#...#.#...#...#.#.....#.......#.#...#...#.......#.....#...#.#.#...#.....#.....#\r\n#.#.#####.#.#.###.#.#.#.#####.#.#.###.#.#####.#.#####.#.#.###.###.###########.#.###.#.###.###.###.#####.###.###.#.#.###.#.#.###.#####.#####.#\r\n#S......#.........#...#.......#.....#.........#.......#.......#...............#...#.....#.................#.......#.......#...#.............#\r\n#############################################################################################################################################";

    protected override string Part1Internal(string input)
    {
        var grid = input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

        Coord target = null;
        Coord start = null;

        var deadEndsToCheck = new Queue<Coord>();

        for (var y = 0; y <= grid.Length; y++)
        {
            for (var x = 0; x < grid[0].Length; x++)
            {
                if (grid[y][x] == 'S')
                {
                    target = new Coord(x, y);
                    continue;
                }
                if (grid[y][x] == 'E')
                {
                    start = new Coord(x, y);
                    continue;
                }

                CheckDeadEnd(ref grid, deadEndsToCheck, y, x);
            }

            if (start != null && target != null) break;
        }

        while (deadEndsToCheck.Any())
        {
            var coord = deadEndsToCheck.Dequeue();
            CheckDeadEnd(ref grid, deadEndsToCheck, coord.Y, coord.X);
        }

        var startPath = new Path(0, Direction.Right, start);

        var paths = new Stack<Path>();
        paths.Push(startPath);
        var bestScore = long.MaxValue;

        while (paths.Any())
        {
            var path = paths.Pop();

            if (!path.LastTurnedRight)
            {
                var right = path.TurnRight();
                if (right.Score < bestScore && grid[right.Position.Y][right.Position.X] == '.' && !right.VisitedLocations.Contains(right.Position)) paths.Push(right);
                bestScore = right.Check(target, bestScore);
            }
            if (!path.LastTurnedLeft)
            {
                var left = path.TurnLeft();
                if (left.Score < bestScore && grid[left.Position.Y][left.Position.X] == '.' && !left.VisitedLocations.Contains(left.Position)) paths.Push(left);
                bestScore = left.Check(target, bestScore);
            }
            var forward = path.MoveForward();
            if (forward.Score < bestScore && grid[forward.Position.Y][forward.Position.X] == '.' && !forward.VisitedLocations.Contains(forward.Position)) paths.Push(forward);

            bestScore = forward.Check(target, bestScore);
        }

        return bestScore.ToString();
    }

    private static void CheckDeadEnd(ref char[][] grid, Queue<Coord> deadEndsToCheck, long y, long x)
    {
        if (grid[y][x] == '.')
        {
            var deadEndCount = 0;
            if (grid[y - 1][x] == '#') deadEndCount++;
            if (grid[y + 1][x] == '#') deadEndCount++;
            if (grid[y][x - 1] == '#') deadEndCount++;
            if (grid[y][x + 1] == '#') deadEndCount++;

            if (deadEndCount >= 3)
            {
                grid[y][x] = '#';
                deadEndsToCheck.Enqueue(new Coord(x - 1, y));
                deadEndsToCheck.Enqueue(new Coord(x + 1, y));
                deadEndsToCheck.Enqueue(new Coord(x, y - 1));
                deadEndsToCheck.Enqueue(new Coord(x, y + 1));
            }
        }
    }

    private class Path(long score, Direction direction, Coord position, HashSet<Coord> visitedLocations = null)
    {
        public long Score { get; set; } = score;
        public Coord Position { get; set; } = position;
        public Direction Direction { get; set; } = direction;
        public HashSet<Coord> VisitedLocations { get; } = visitedLocations ?? new HashSet<Coord>();

        public bool LastTurnedLeft { get; set; }
        public bool LastTurnedRight { get; set; }

        public Path TurnLeft()
        {
            var newDirection = Direction-1;
            if (newDirection < 0) newDirection = Direction.Left;
            return MoveForward(Score + 1000, newDirection, true, false);
        }
        public Path TurnRight()
        {
            var newDirection = Direction + 1;
            if (newDirection== Direction.Turn) newDirection= Direction.Up;
            return MoveForward(Score+1000, newDirection, false, true);
        }

        public Path MoveForward()
        {
            return MoveForward(Score, Direction, false, false);
        }

        public Path MoveForward(long score, Direction newDirection, bool lastTurnedLeft, bool lastTurnedRight)
        {
            VisitedLocations.Add(Position);
            Coord newPosition = null;
            switch (newDirection)
            {
                case Direction.Left:
                    newPosition = new Coord(Position.X - 1, Position.Y);
                    break;
                case Direction.Right:
                    newPosition = new Coord(Position.X + 1, Position.Y);
                    break;
                case Direction.Up:
                    newPosition = new Coord(Position.X, Position.Y - 1);
                    break;
                case Direction.Down:
                    newPosition = new Coord(Position.X, Position.Y + 1);
                    break;
            }

            return new Path(score + 1, newDirection, newPosition, new HashSet<Coord>(VisitedLocations))
            {
                LastTurnedLeft = lastTurnedLeft,
                LastTurnedRight = lastTurnedRight
            };
        }

        public long Check(Coord target, long bestScore)
        {
            if (Position.Equals(target))
            {
                if (Score < bestScore) return Score;
            }

            return bestScore;
        }
    }
}

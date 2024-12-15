using AdventUtils;
using AdventUtils.Models;

namespace Advent2024
{
    internal class Day15 : DayBase
    {
        protected override string _sample1 => "##########\r\n#..O..O.O#\r\n#......O.#\r\n#.OO..O.O#\r\n#..O@..O.#\r\n#O#..O...#\r\n#O..O..O.#\r\n#.OO.O.OO#\r\n#....O...#\r\n##########\r\n\r\n<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^\r\nvvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v\r\n><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<\r\n<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^\r\n^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><\r\n^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^\r\n>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^\r\n<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>\r\n^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>\r\nv^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";

        protected override string _part1 => "##################################################\r\n#...O...O##..###.O......O...O#.OO##..O#....OO#OO.#\r\n#...OO........O..O.##..O...O...#....OO..#.......O#\r\n#O.....O..#.....O..OO#OO.#O..OOO.#.#.............#\r\n#......#OOO.O.OO....#.#..OOOO.OO.O#O..O..O..##...#\r\n#.O####.O...OO.O.#.OO.O#O.OO#............O#.O#...#\r\n#....O.#..........#O...O.OO#O.#....#..O.OO....O.##\r\n#O..#...O...O.OOOO.O........O..OO.O....O.O#....O.#\r\n##O........#O.O.O.##.#..OO#....O..O......#....O.O#\r\n#...#OO.OOO..#.O..O..##...#...O#O..O.........O...#\r\n#.#O#....#.#....#.O..OO#.....#...OO#O...O.#O....O#\r\n#.........O#O#OOO....O.O........OO..#..O.OOO.#O.O#\r\n#O.#.#.O..#.O........#.OO#.....O........OO.O.O.O.#\r\n#..O.O....O.O.........#...O.O..OOO..O...O...O....#\r\n#.....O......OO....#..O.O.O.............O...#..O.#\r\n#..OO#....#...O..........O.......O..#............#\r\n#OOO.O...#....O...OO...O.O...OO##........#O......#\r\n#...O.OOOO.....OO....#.O.O.....O.............O..O#\r\n#.O#....OO.#....O.#.....#....#...OOO........O..O.#\r\n#O.O..#.#O...O#...O.....OO..#....O...O..##.O....O#\r\n#O.OO.....#O....O..OOO.....O..#.....O..O...O.OO.O#\r\n#...O#.#O...OO.O...OO..O..O..O.#OO....#...O...#OO#\r\n#O..O....OO.O...#...O......#O..#OO.O..OO#O.......#\r\n#.O............O#OO.O.#...##.O....O.O..O.....OO..#\r\n#..OOOOOOO..O.O...OOO...@.OOO#.O....#.....OO....O#\r\n#..#....O..........#O..#.....O..O..O.O....OO...O.#\r\n#O.O..OO.O..OO.O.O.##..OO..OO..O#..OOOO.O..O...#O#\r\n#.#.........OO.OO..........##...OO...#OO..#O...O.#\r\n#....O...O......O#.O.OO..#.O....O...O....OO.OO#..#\r\n##..O.....OO..O.O....O#..O...#..........OO#O.O.OO#\r\n#OO.OO..OO.OO..OO.O......O#OO..OOOOO......#..#.#.#\r\n#OO.#.O#O#.##.O..O#....O...O....O.#O....#..O..O.O#\r\n#.OO.#OO.OO.O#..OOOO.#..........O.....OO....O.O..#\r\n#O......OO..#..O.OO.OO.OO....#O.O#.....OO##.#....#\r\n#O.OO..O..#.....O.....O......#.....#......O#.....#\r\n#.O....O#.OO..O......O..O.O.....O##..OO.O..#.....#\r\n#..#......OO.....#..OO.O..#....OO.O.......#.#O.O.#\r\n#...#.OO..OO......O.#O.OO#.O.#OO.....OO.#....O.O.#\r\n#....OO.OO..O.O.O.#.OO..O......O........O..#.#O..#\r\n#..O.#..O..#.O.#.O....OO......OO.O..........#.OOO#\r\n#O....#O.....OO#.....O.O..#....O..#O...O..OO....O#\r\n#...O..#O......O#..#..O..#.........O..O...O.OO...#\r\n#....O#..#.O........O.O...#...O.....O#O.O.O....O.#\r\n#.O..OO....#OO....O....O#..O.....O..OO##.....O.###\r\n#.#..O#O........O#O..O#...O.....O#O...O##..O.O...#\r\n#...#..O...O..#O.OO...#.OO.O.....OO...OOO.OO..#..#\r\n#O.................#....#O........O..#.....OO....#\r\n#.#..........O.OO..O.............O..O..O#..O.O...#\r\n#........#.....O.....O..#..O#..#.OO.O......O.#.OO#\r\n##################################################\r\n\r\n^<<>>v<vv^vv>>v<^^>^>>v<><<^vv<<>^v^^><<>v<<vv><>vv<<^v>v>>v><><>v<v>v<^^>>>v<>><vv>>^^^>>^v^^>><v>>>^vv^v^<<<vv^v^>^>><<<^^^v<vv>vv>><<<^>v^vv<v><>v<^>^>vv^<<^<vv^^>^v<v<vv>v>v>^v<^vvv<v^>^<^>^><<^v^^<^><^^^^<>>v>>v>vvvvvv^<^<v<^<<^<<v<v>v>^>^>><vv^><<v>v>><<v<<<><v<v^^v<v<^v<<<v<^^vvv<>>v^v^<<<v^^^v>^v^^>^^^><<vv<<>vv>v^^>^<>>>^vv<<^^<^v^v^v<<>v>^v<>>>>^>vv>^v<>>>v>^<v<<><><^^^<>^>^>v^>^v^^vv>^vvv>^^>vvv<>>vv>v>>><^><v^v^<>v<>^><<^>vvv^<<^^^><v><>^^v<^^<v><^<v><>v<<<>^v<^vv^v^<>^v^^^<<><^<<>>^><v>^v^>v^v^v<><<^<>v>><>><<>><<><>^v<>><v>v>^^>^^><<^<vv^<vv><^<vv<v^<<>^><^><><v<>v<<>>>vv<<^<<>vvv^^^<>^v>vv^>v^v<v^>vv<>>v>^><><v^>v^^vv><^^^<<>><vv<v^<v^>vv^<<^^^>^<>><^<<<<v><<v>><<>v^>>^^v><<v<>>v^<>>^^vv>vv>>v>>><^^<><<v<>^<^^v>>^vvv^><v>^><<^<v<^>v<<^v><<<>^vv^<<^v^>^<>^^<>^v^<<^>v>^vv<>^^<<v^^^<>>>^>><>>^v<>><>>>^v^>v>^<<<vv^>v<v>>^<^^vvv^^v<>^<vv<^v>>v<<v^<>vvv>v^v^><v^><<^<<<<>^v>^<>v^^<<<>^<><<vv^v><v<^<^><>vvv>>^vvv^v<>^<<vv>vv^v>>v>v>>v^vv^<<>^^<^vv>^>^v>>v<^vv^>vv>><>vv^^v^v^>><>\r\n<<^vvvvv^^><^>^><^>>^<^<<v><>>v<<^v^><<<<<^<v^<^v<><<<^^^^<^v<v><<^vv<^<^v>^v<>^^>><v>v>><<^vvv>v>vv<>vvv>vv>vv><><<^>^v<v<vvv>v><^<<^<>^<v>^<<^^<>v>><>>>v<<>v^^><vv><<>^>v^^v<^^^v^v<>^^><^>^>v<>^v^^>>>v>>>v><<>^^><<^>>^<^^^^<^<^^^v>><<<^>v<^vv>^<>v<^<>>v^v^<^<v<<><vv>vvv^>^><^^<^<^v<v>v>>>vv^<><<>^^v^<^vvvvvv^^^v><^^>^vvv><>v<<v>>vv^><>^>v^>^^<<^>^<^<<v>v<<^^v>>^<v^>v^^^v<<^^<<>><>^>v<^<<^^v>^>v<vv<<>v<v>vv^v>v^v<<^^<>v^<><^<^^^vv>><^v>><>v>^>v^vv>^^>>v^><<v<<v<><><>><v>>><^v>><vv<v><>vvv^><>v^v><^v<<v<^v>>>^v^<v<^<v^>v<v<^vv<^^>^^v^^<v>>^>v>^>>v^<^<^^v>>>>>>><v^v>>><>>v><<^^>^>>v<^><^v><vv^v<<^v>>^>v<v>^<<^<^^><^v<><^^<^<<>^v<^><>^^v^v>>^<v<<<<>><^^^^v^v><<^^v<v>^<^^<^<v^^^^vv><^<>v>^>>v<^^^>^<<<^<v<><<^^><>^<<^v<^><<v^v<>>>>^>^><><v><^<v>^<<<<^v>^>v<>v><>v<><<<>><>v^<^<<v>vv>v<<<><v^<vv^^^<^><>>><><>>v><v^><^v^v>^v>><<<^<v><^^<^<>v<<^>^<v>>>^vvv>v<v>^v^<><^^>v>^><^^<<<>>vvv>^v^><>>v>v<<v^^^<v>^^<^>^>>^<^vvv^<>^^>v>v<<^<><<vv<<<^v<<<v^v<vv><<^<^^><v^<v^v^>v>v<<>^>^^v>>>>v><>v>vv<v>v>\r\n^>^v><^^>vvv>>^<<v<>v^^^<>>^v<^<<^v^^>^<v^^<<<^<>vv>^^^^<v^<v>^>vv^^^v^vv^v^vv<><vv>>v<<v>>v^v><v<<>>^^v^^>>>>>>v<^>^>><<>vv<^<<>vv<><<^>^^<vvvv<v^^^<^><<>^<<<>^>^^^v^v>^^vvv<><^^v<v><^v<>>>^>v^<^^^v<^v>v^^>>vv^<v>^>>vv>^v^^><v^^><^<<^^<<>>^v<<>vv^v>v>>>v><<^<>v^><>vv><v><>^<<v>v<<>v<>^>v^v^>^<vv^>^<v<^>><^v^<v^^><<^<<>>>^^^><v^v>v>v<<^>^^<>v^^>v^<v<v><^v<>^^<v^<^>^<>^v^<v^>v<^^vv<v^>>^v>^>>^vv^^^<v<^>^^<>>^>v^>^^><v^<<^^v^<^>>><><<^^><><><^^v<<><<<<>v^v^v<>v^><^^>v>v^<v>^<vvv>^v^v<>vv<v>^vv<<>><^^vv<<<^<v^^^^<^<v>^<^v<^>^<^>v^<v<<v<<v^v>^<<>v>v<<v<<v>>vvvv<<>v^>^^^<<v<^v^v<^^vv<v<<>v<<^^vv>>v<<v^^v<^><<<>v<<<<^v>>v<v>^><<>vv^>vvv<>>^<v<^^>vv<v^^v>v>^^<v^^v><>^^^>vv^^^v<<v>^^v<>>^<>>v<^>>^v<<>v>><v^<^v^^^v<v>>>^v^^<>^<vvv>><<>^>v^^<^vvv><v<<<^<><v>v>v^^^<^>vvv^v^^^v^^<<^vvv>v^>v<>>v^vv<^v^^<><^^^>vv<v^v><v><<>>v<>^^^>v^<^<^>^^vv<^vv>v<^^<<^>>><^>><^^^<><v<^>^v<^<<>>^^v^<<vv<v^>^>>^v^>^<v>v><<>^^><v><<<<<^^<>>v>^^v>><>>^^>^<vv>vvv>v><><vv^<><<>><^v>^v>v<<>v^>>^^<vvv<^<^<><<<v<^^<^^<<vvv\r\n<v<<<<><^<<vv^v<>>^>>>^v<<v><<vv>vv<><^<>v<^v<>v<v^>^v^^vvvv<<^^<v<^<<^>v^v<^v>><^<<v<<^>v><^v><>>^^v^<v<>>vv^<>><>>>v^<>><<>v>^>><<>^^v^^v><v^<<>^>^>^v<^>^^>^v<>><vv^^v>><>>v<>>v^^^^^>vvv^^v<<<<>^^<v>>^v><<^>><<vv^><<^<>^>^v<>v<v>v<^<>>><^<>><>^^vv^vv>><^v><>v^^vv><><><^^>>><^>>^>v^<<>^vv<v>>^^<^>><<^v>^v>v^><vv>>><v<^^>v^v^v>>^<<>^v<>><^vv^^^v<>^^^<>v<<<v<<>>^^<^<<><<v^<v>^<vv^^v<>v^^><>^>v^<v<^v<^^vv<<v>v<vvvv><v><^>>^v^><<<v><v^><<^^v<<vv^v<^<v>^<^^>v<>v<>^v>^v>v>v<><><><><<^v<vvv^v><<<>^<><^^>^vv^>>><<vv^^v^<v^<>>vv<>v^^<<<<vv<^>>^<v><<^><>^^>>>>^<>v>^>>v>>^<vv^v<^v^^vvv>><><^vv<<^^>>^>v^<<<v>v<^><><<^vv^v><^v<>v<>vvv<>^<^vvv<>^<<^<v^<>v^v^><v^<>vv^>v><^>v<<v>>^v<v<vvv<>^><v<^^vvv^<<v<<vv^<v<v<^><^>v><<^^v<v>><<>><>v>>^v<>>v>>v<>>v^^<<vvvv^^vvv>v<<v>^>v><>v<^<v>><^<^><^<^^>>>>^<>^<v<><^v>^^<<^>v^<><>v>v>>v^v^^>v^<v^v<vv<^v^^>^v<>^<^>>>>^>v>^^<<v<<^<>>^<v^^<>vv>>^<^<>vv^^v^v^v^<^v<v^<<>v>>>v>^>v^^v>>>v^vv^^^>^^^vv>>^<^v^v>^^>^>v<><^<^^>^>><>v>>^><>v<>^^><>><<vvv<<<^>^^v<<><<>v<v<v<\r\n<>>^^v<v<>vvv^>^>>vvv>>^v^>^>vvvv>v<<<vvvv>v>^^^<^<^>v^^<^<>^v^^><^^<^<<<<v>>>v^vv><<<v><>v><^<<<<><v<>>^<<v^^>>^v>v^>v><vv><^><v<><><v>v^v<^<^^v^vv<v<>>^><<v^v<>>^^<>>^^>v>^<<>vvv<^^<<<>^<^<vv<>^>^<^v><<^v^^v<<<>>v<><<^<v<v<<<^>^v><><^<<<>^vvv<v^v^^v<vv>>><>v^v<>>v<>><<<<^v^v^><<<v^v>v<v^<<<v<>>^<^<>><>v<v><v^v>>v<vvv>vvvv<^><^><vv>^<<><>v<>v<<>>><<<>v<><<^^<<<^^^v^v<^>v>^vv<<>^^<v^<>^>vv^<>v^><<>>^>>>><<<vv>vv<v>>v<><^v>>^<^^^^v^^^^vv>v^<v>v>>^v^<<^v<<>vv<v>^^vv^^<^<^^v<v^v<v<^>>>^<v>vv<v<>v>>>vvv>><^<<^<^^<>^v<vv><^v^<<>>^v^<^<><<^^<^><^><>>vvv>v><v<>v^>>^<vv>^^v<>>><><^<^>><<v<>v^<<>v^^>>^v>^^>vv>v><<^>v^^>><>>^<<v><<v>v<vv^^<^<^v><<<>v^vv<>^<><^v>v><v<^>^^><v^v^>^<<>v^^>><>vv<vv>>^^v<v<<^vv<<v^v<v<^^>v><v<vvv^^><v^^v^^v<>vv<v>v^<<^>v>v>^v<^<^v^^^<<<^>v^^v<<><<vv^<^<>v<^v>^><<><<v^^^<>^^vv>v><v^vvv>^^<<vv<v>v^vv>v^>vvv<^^v>v^<<v>v<^>>>^v<v<v>^^^>^^^<<>>v<<<v>v>^><<>^^>>>>^v><<>^v^^^>>v<<<>vvvv>>^><<<<>^v<>>><v^>^v^v<^vvv>^v<<<v>>><^><<><<>^<v<^v<^vvvvv>^>>^^<<<v>v^vv^>v^>v>v><<vv^v\r\n<v<^^<>^<><^^<v>v<vv^>v^^^>^<^^<^v^>^v<v^<<v<<>><<v>>><v<>^v<<v>v>>>^v>v>^>^vv^<v<^^vvv<><<>^v>v>^^^<v>>^<^^v^>^<>^><^><^v^>^^^vvv<>>vv>^<>^^>v^v<<>^^>v>^><^<<<<<v<>^>vv^v^v^>v<>v<^vvv^<vv<^vv<v^v^><<vv>>v^v^vvv<^>v>vv^<>^^>^>v^v<<<v^vv><>vv>>>vvvv<v^>>v^<^^<v><>^><<<<<<^>v^>><<>^<<<^<v^<^^v>^v>>^^<^v^^v>^>>>v><<>v><><<v^^^vvvv<^^vv^<>><<v^<<><vv^^>^>>><><^><<<<v>v<>>^>v^v^^<><vv>><<vv<<<v<>><><><<>>v>v^^>>v<v^>v<<<^<>^^<^<^<>v<><>v<v>^<<v><vv>>v<><^v^<v^<^v<<>><^v^v^>>v^>>^^<<v>>v>>^>>><vv><^^v>v>v^<v<<vv^<>vv>>>><v>>vvvv<^v^>v>vvvvvv<^<^v^<vv><^v^^v><vv^<vvv<<>^v<<^<>v^<<^^>vv^><v<v^<v<<><><<>>v^>>><v^<<v>v^>^<v<vv><vvvv>>>>vv<^<v^>v^^vv>v<>^><^vv^<^v>^><^<><v<>v^>v>v<v<<<>v^<>v><>><^<>v>^v^>>^v><>>><>v><>vvvvv<<^^^<>v>v^><v<^vv<v^>^v>v^^v^^vvv^>v^vvvv>><<vv<v<<^^^>>v^vv^>v<>^v^v<<^^vv<>><v>>^>>^<v<<v<^>>>>>v><vv<^<><>v^v<>^><vv<>><<>v>vv>^>^^>>>vv<^>v>><v<^^>^<^>^^^<v<vvvv^v>>>^^<<>vv<<<<<>^v>^><^<<>v><^>v^^v<><v^^<v>^<v><vvv>^<v^>><>^<vv^<><^<<v^>><>>^v<vvv<><<>><<^>v><>^<<>><<>vvv\r\n>v>v<^vv^^<<>v<><^><v<v<^>>vv^v^^<v^>>><><v^^^vv<^<^^^><>v^>>vv>>^^<><vv^^<v^v^^vv>>vv<<^^>>>vv^v>v<^^>v<^><^<^>^vvv^<>^<^^^<^>>^^>>v><><>><<>vv<>><<><^^<>>^^<^<^v^>^vvv<<<><^><v^^^v>v>^^<^>^v^><^>v^^<vv>v^v>>^>^>^>>^>v>^^^v<<v^^^^^><^<^>v^<^<^>>v^<^<<<^v<>><^>^<v>>v^^<v>^<^v>^>^<v>^vvvv<v^^v<v<v<>><<>vv<<<<vv><vvv^<<<>>v^vv>^><^^^><^^v^^^><vv>v^v><>v^><>>v<>vv><>^^>>v>v>>^<^v^^v<<>v^<v>^v<^v^^v^^><>^<vv><>^^vv^v^^v^>><^^>v<vv^^v^vv>>>>>^><<vv<>>^^v>^^^<>v^^^^>^v>vv<^v<^^^^<>v^<^v^^v>v^>^>>vv>v>v^^^^^^v^^><v><^<><vvv>^>>><<^v^>vv^<^^v<><><>>v<><v<v<^v^^>^<v>>v>>v^vv>v<<>>v>^>^>><>vvv><^^>>>vv<v>^<><v^<vv^><<v^v^<v>^v<>v><v^<v>^>><^^^><v><>>v<v<v<vv<^>v^>><v^>vv^>v^<^>^v<^^v<<v>v>^vv>><v>v<^><>^>>^^<>vv^<<v<<v^v^v>^v^<><>>vv><<>v>>v^^vvv><v<<>vv><<^<>^vv<>^<<v>^^vv^<<^v<<v^v<v^><>^<^><v<>^v>><>^<^>><><^vv^v><v<>>^>v^<v^<<v<vv>^v<>v<>^>v^^v<v<^^^v>^^v>v>v><>^>><^v>^<vvv^<v^^^^vv>>><>vv<v<v^>>^>>v><<v>><>^vv>v<v^v<v^>^^^<v^^>vv^^vv>^<v>^<^>vvv>^><>vv>vv<<v^v><<<v>^v<<>^<vv<^^^><^>>v<>v><v\r\n>^vv<<>v<>v^v>v>><<^>^v>><vv<^^^<<^<^v>>>vv<<<v<><^^>>^>^^v^v^v<v^v<^>>^>v^v<>vv><v^<v<v>^v><><>v>v^^<>>v^^><<<^>^^<><^v>^v<>>>^<^v<^^>^^>>^<v<>^>^<v<^>^<>^>>>v<><>>^^v<v^<<<<>^v^^v<^>v^v<^<<><v^v<<>^<v^>v<<v^v<^^v>v^vvv^>v<<>^v><<^vv>v^<<<<<^>^vv>>>v^<>v<^>v^>>vvv^vv^>><^^^^^v<<v^v>^^<^>>v<>v^>>^^><^^>^v>v^><vv><<<v^^v>^^^v><>^^><>v^vvv><><>v>v><<<<vv^>^^>>v<v<<vv^><^<>vv^vv<<>^^>v>^v^<>v^^^^v>><<vv>^v<v<^^v^<>^<>>^>^>v<><^vvv<>v<v^^v^v>^^^<^v<^v>>><v<<^v^^v<v^v<^>^^>v<<<^>><^vv^v^v^<<>>^>^>>^>>vv^v<<<^^>^>><^^v^>^^<<v<<<<v<vv^>>^^>^^^<^<><><^^>^vv>>^^>v<<>>>vv^<v>v<>^>vv<<^vv^><>vv<^<>v^v^>vv^v^vv>^><><v>v<v^><>><^>>>^>v<>v<v^^<<vvvv^v<<^vvv<<<>^>vvv><^v>><^^<>^v><^v<v>v>^<<v^v^<^vv^v<<<>^^<<>v>v^v<<vv<^v>^v^v>>vvv>v><<v^v^<^<<v<>v<vv>>>^vv>v<^<vvv^>>>>vv<v^v<v><^<^>v^v><^^^>>>>^vv^>>v>^^^v>^vvvv>^<<>^>><>>>^^v<<vvvv><>^>>>^>v^>>>>^v><^><<v<<>v>><>v>><^v^^^^>^>>v^><^<vvvvv^^vvv^v^vv>v^v<v<>>^v<vv<v>>vv<v<^v^><>^^<>>^^vv<>v>><>>>>^v><^^^v^^^^vv<^>><><<^^v>v><>^>^v<^^v>v<^>v>^<vvv^><>>\r\n>v<<<^v>v<><<vv^><><vv^<vv^v>>><><<>v^<>^<v^>vv>>>><v>v>vvv>^>^<vv^^>>>^<><^^<^v^>>>^^^v^>v>vv<<><v^vv^<><<vvv>v><^>>^v^v<><><v<><<<v^^v>><^><>^<^<><^>>^^<v><>vvvv<v^>>v^>^>vvv>^v^<v^v<<v^^v><<^<v><>^v>>^<^^v<^><>>>^^>^vv>^^<^^><^<^>^<v<vvv>^<v>^>v><^v<v<<<v><^v><^>^v>^^v^<>>><>>><<<^v>>v<vvv>>^^^<^<v><<^v>>>v^<^>^>^<v^^>v>^<^<v<^vv^^<<^>>>v<>v>^vv^^<<>v^^^><>^^^^<^^><^^<v<^^>><>^<v<>><^<><^vv<^^^^v>>v><>^<>>>v^>>v^^^<>v<^^v<>>^v><>^^v><v^<^>v^<<>^v^vv<<><^^>vv^<v<^>v<v><>v>vvv>v^^>^<v<^vv^^v<v<^>>><v<v^^>v^v>^><<vv<>^<^<vv<^^>^<<vvvvv>>^^^v>^v^><<><^>^v>^v<^><v^>^^<^<<^<<^v^<v^<<^>>v^^<>>^>>><><v>^>^v<<vv>v<^<<<v>^<^><^<vv<><^>^v<^vv>^^v^vv^v>v^v^>>v<^<^>^v><vv>v<vv^v>^^<vv^<<v^<<<^^^><<v>^^v^>vv^v^^v^^^>><^^^><<v><>v^^^<>v><v^vvv>>vv^>v><^<v><^^^>><<^><<^^v><v^<>>v>^>v^<>v><^v>vvv><v<><^^<v>v^^>v>v><>v^v<>v^v<<vvvvv<>^^<^^<v^^<>vvv^>^^v^><>v^^>>^^^^v>>>>v><^v>>vvv^v><vvvv<vv^v>^^v>>>>v^^v>>vvv^v>^<v<^<<<<>^vv^v^><<^<^<^^<<<<vv<v>v>^<<^^^^<^<><^><vv>>v>>v<^^<<><^^vv><>><<^<<^v<>v^^vv<\r\n<<><>vv>v^^^^<vv>><>v><<<<^^>v^<>v<v^<>v<^^^v^<<^^><>>>>>v>><v^>>><<<v<>v^^^^v>v>>v<vv<>v^<<vv>><>>^^^v<v^><v>vvv^<>><<><v^>vv>v><^^<^>^>><>^^v^>v^>>v<^><<v<v^v^<^>>>^<<>v><<<vv^^^v^<v<<<v<<^vv^^<v<>vv<^vv>vvvvv<<^vv^>v^v^^<<><^^v<<><^<>>>v>^<v>^v>v<v<v<<^v^v>><<><>vvvv>v<<>v<>>^^<^<^>v^v><<>v^v<<><>>><vv^>>>>^v<>^v<><<^<^^^<<>>v<<v^v><v^^><>v<^>>^^<^^<>vv<v^<^^v<vvv>vv<^>>><v>vv>v^^^<<^^>^<><>>>^^>>><<^vvv<^^v><v^^v^<^<^v<<<<^<>^v^^^>>^^^<<^^v>>>>^<<<<vv^^^vv<v^>^<><>><>>>>v>v<<v^v<^^<><<v^^>v^><<<^<>v<<>vv>v<^^<v^>^<>^v>>^^v^^<><>^>><<v<<vv><v<v><v<<<^><<^<<^><>^^<<^>><v^^<>v><><<<<<<<>^^<><^^><^v^<>vv<^>><>^>>>^v^^v^vv>v^<v^^>vv>v^v^>>>>^>><>^<v^^^v>>^>vv<v^<<<^>^^^vv>^>^^^v^>v>v^vv><^>v^>v<v<<<><^v^>v^^v>v^vv>v>>>v><<<^>>v<<><><^<^>v^v^vv^<^^v^<<>>><<v><<<<^^v^<^>>>vv>>^><^>>^<>v>><>>^^>>>^><>>v^<^>^<v><v>>vv<v^>^^<>^>^v><><^^>v^v<^^>v>^v<<<<>^>v>v^vv>v<^<>v<^^^<>>^>>v^v<>^>^><^v^^>v<<^v<^>^>>^^^^<v>>><>v<><>^>vv<<vvv>vvv<>>v<<v^>v><<^^^>v^>^v^^>v<>vv^v>><>><v>>vvv>v<>>^>^>^^^>^>^>\r\n<<v><^<v^v>v<>vv<v<<^>^^v>^>v^v>>vv<>>^^^v^>vv^<^<>vv^^vv><^<^<v><v^v<>^><vv<v<v>^><v<>><<v<>^>^<><<v><>^<v<^v^<><v<^>vv>v^^<^<vvv^<^v>v^^<<^^<>^<^<^>>v<<vv^^v<<v>^^>^v^^^<^^^<>v^^>vv^^vv^<<<^<^vvv>vvv^<v><<v<^<<<<^<<v^v>^v^>v>>v^v><>v^<vvv^>^^<>>^>>vv<^^vvvv<<>v>>^^^<>><^><^^>vv<^^>v^^><><^<vv><^v^<^<v>^>>v><v>^<v^<><^><><>v><vvv<^vv<^>><><vv^>>^^v<><><^^v<v>v<>^>vv>^>v<<>>>^<^v^<vv^<^^v^^^vv^<^<^^<^<<<<v^^vv^>^v^v><>v>^>vvv>>>v^^><<<^vv^<vvvv>v^vv>vv^^<>><vv^>vvvvv<^<^^>^<<^><v^^><<<>^v^>v^^v^v><<vv^v<<<<^><>><<^^>>>vv<v>^^<<v><<<v^>^^^vv><v>v<^^vv^<<>vvv>^>>v<<<v>^v^^<v<^v>v<v<<v<<v>^>><^vv<>^v^<>vv^<^v>><<v^v<<>^v<v^^<<^v>^>^v>v>vvv><<<v^^<>vv^v>^^vvvv^<v^v<>v<^>>v>^^^<>>>^>><^v<<v<<vv<v<<<v>^<<>vv^>><^v^^>vvv>>^<<>^>v><>>>^v<^<<^>v<<^>>>>>>>v>vvv^>v<>>>><<>>vv^>^^^<><<>v^>v>vvv^v<^vv><<<<<v>^^<^><>><v><^^>vv>v^v><<vvv^^<>>vv^<<<>>v<<^^<<^^<v<v>^^><v^^<<>^<^^><^<<<<v><<^v^^><<^<v^>v>^^vv>^vv<v<v>v<v<<^<>>v>v>><v<^>v><>>^<v>>v<<vv>v^v>^vv>>^vv>v<>>v^<^v>v^v<<v<vv>v^^^>>>>vv<^v<v^^^>\r\nvvv><v>><<<<^>v^>>><^><<<vvvv<^^><^<<v<^>vvvv>^vv>^^<^<<><><<<^>vv>vv<v^^vv>^<>v^>v><vv^>><^<<^vv<><><v><<^^>v^<>v>vv<v^^<<v>^v>>^>^<>v^>^v>^v<><^<^^vv^<v^>vv>^vvv^vv<<^v^v^^v^<^<>v>v>^^<v>^v<>^v>><<>>>v<^<><v^v^^>^<vv^vv<^<^<><v<v>vv>v><^v<vv<v<<>^v^<<v><^>>v><>^^^v^v^v>vv<<v^>v^v><<><vv<v^<<v><^^><<>>v>>v><>^^>^><^<<>><>v>vv^<><><<>vv<^v<><^^<>^^^>^v^>^>>vv^vvv>>^^v^^<v>>>v><^<v<>v>v>^>v<<<>vvv<>vvvvv^v^<v^^<<^^^^v^^vvvv>^v<>v>^^>v<v^<<>^<<^>>>v<vv>^>v<>>>>^<<><v^<^^^^<v<>^><>><v>^<v<>^<<>v^>><<<vvv>>>vv^<<^v>^>^>vvv^v<>^<^^<v^^>v<>vv^^^>>>><^v<^v>>>><<^^<>>^<^v^<^^<><><^vvvv<>^v<<<>>v^^<vv<>><<<>>v^<>^>^>^^^>>v^^>^v>>^><v<>^<><v>^>^<^>v>vv><^v><>^^^>^^vv>vv<>v<^v<vv^>>^<v<vv<v>^><^<<<^^<>>v<^<<<<>^><v^<<vvvvv^v>v^v^^>v<>^vv<>v<<>><<>^>v>^v<<<v><v^v<<>>v<v<^^vv^<>^v>^>>^>v^<><<vvvv><^^^^<<><>><vv>^v><>>><^^>>^v<vv>v<<^^v<v>v<><^v<vv><v^^v>>^^^^v>v>^v<><v^<^>v^^v^>>^>>><^^><>v><vv^^^><^<^>v^<<<^v<<v<v<^v><>>v>>><<v<^^v>^v>vvv<^<>^v^>>^>v<<vv>vvv^v>v^v<^^v>v>>^>^v<>vv>>v>>v^^v^^>^^^<><\r\n<vv<>^v^^^v^v<<>>vv^v^^^^<vv>vv><^><<>>^^<vv^^v<v^>^>^<v<^<^^^<><<v^^v^v^<><^<^^><v>>><^^>v^<><<v<<^<>^>^<v^^>v^^^<^v<>><<<v<>>>>v>>vv<><<^^v<<<<<v<^><v<v><><v>^^v<^v><^^vv<<vv<<><^><><v^vvv><>v<>v<<v^vv><><v><>><v>v<^v>v>><><^^v^^^vvvv^>^^><<vv><<<v<^vv^<<<v^<>v^^<^>>^<^<>^^>>^<v>>v>^<<>>^^>><<<><^vvv>>^^>>>vv<<v>v<<<<v^<^v^><>>v>>>v^>>^^^><^^^v^<>vv^^^<>^>>^>>^v><v<v<<v<><v>v><^^>v^>vv<v<^>>^>>><v<v^<<<^^>>v>^^<^v>^>^vvv><><^<^<v<vv^<v<><>>^^v<>vv<<vv><^<v^v>>>><vv^<^<<<><<v^<^^v^<<><<v<>v<v<v>>v<^^>>^><<^vv^<<<<<<>>^>^^v^<vv^<v><>^<v<<v>><<<v<>>^v<<<v^>v>>v>>^^<<vv<v^>>^^<<>v<>^>><^<><v><<^vvvv^>>^^^<^<v><v^>v<v<^^v><>^v><<^v><^<v>^vv^<<<<v^^vv<<>v>^<><v^<<v^>>^^v^<v<<>><><^<<<>^<^<vv^<>v^<v<v<>><<>vvv<^<v^v^^^<>>^>v<<<<^^v>^^v^>><^v><v>vvvv^^<<>v<v<>v<^>>^^<>^<>^v>^>>v^><^^v^>^^<v^^v<>^^v<<^v^<>v^<<<vv>v<v^<>>v<<^v><>v<v><<^>v>>^^<^>^v^>v<^^v^v<<>v<^^^>>^><>>>>^>v^><><<^v<<^>><vv>v^<v^<^v><><<^^<<v>>>^v^^^<^<^><^^><<<>v<v><v^vv>>>>v^>v^v>vvv<<<<>>v^>v>^vv>>v>v>v<>^vv^^<^v>^v>v^^v^>\r\n^^v<<^vv^<v<<><^<>>>v>>^^v><>v>^><<<><^^<>vvv>^^>^>><<^v<><><v<>^^v<v<^vv>v<<>v<v<^<<<<<<^<v<^^^>>><^<^^<<v<>^v>v^vv>vv<>>v<vv<^<<><<<<<<<<><^>^>>v^^<^><v<^<v^^v><>v<><<<>^^^v>^>v<<>vvv^<v^<v><^^>>>>v<<v^<^^v^^v^>^v>^><<vv>>^^<v<>vv>v>v^>>v<<<v^v^vv^<<v^<v^v>>^v<><<<v>>^><<^>^>v^<^^^v^^v<<v^vvv^<vv^^<^v^^><^^vv^v<^<^<><v<<>^<>>><><^^^><><>^<^><><><>v>>^>>^<v<>>>>^^^<v<<<><^<^^v>>v<<>^<>>^v^^^vv>^v>>>>v^>^><v^>>^^<<^<v^v>>^vv^v<^^vv^v^>^<<<>^<<>>^^^v^^^^<^v^v^<<>v^>^<><v<<^>><><>>vv>>v<<v>^<vv^vv><<^v<^<<<v><><>><<vv>v^^<vvv>>vv^>>>><^v<vv>>v<<<>^^^>v><^>>v<^^^^vv<^^^^^<^v>v><v<vv>><>><^<^>^^<>vv^^<v>v^<^v<^^>^^^<vv<^^^>v>>vv^<<><^^>^v<<^><>v^v^^^^^^vv><<>^>v^>v>>v<>vvv<><>>>v<<v>>^<<^^v^^^^vv><<<^^^^><<><>>^<^^>^^<>v<v<^^<>v^v^>>^^><^<vv<vvv>^>^^^v^<<v<<<vv>^^>^v<v<v><<><>v^v<<^^<v<>>^^>^^>vvv^^<^<v<v^>vvv<vv^<<^^>v^>^>^>v<vv^>^<^^<v^<>^^^^<v>vvv>vv<<^v^><<^>v<<^v>^^>v>^v^v<><vvv^<>>^v>^v>^vv^>v>v>>>>^^<vvvv<vv>v^><^<^<^^^^>v^^>^^v^^><>><v><^^<^v^v><^v<<>vvv<^<<^v^^<>^<><<^<>><^><<>><>\r\n^^<><<v^vvv^v><<>v<<<>v^>v^v^^>>vv<<>>^>^vv^>^>>>^^vv^^v<>><v^<v>>v<^>>^^<><>v>>v^^^><vv>>><>^<^^v<<><v<<v^vv><v>^<^>>^<><^<<><>^<vvv^^^<v<>^v><^><>vv>^v^vv^><<>^vv^^<^>v^<^vv><<^^>vv^v<v^^>^<vv>v<v^^><v^vv^>^><^>^>v><<^^v<^^>v>>>v^<<vv^<^>^v>v<^<<<<<<v>v^v>v>><<v>v<^<<<^<<^<vvv<vv>^v>v>>v<^v^>>^>v^^<vv><^<v^^^<v<<<^<v<^><v^<^^<>^<v^>v<^<v<^<v<><<^<<<<>><<<><v>^<>^><vv^<><>vvv^>>><>>>^><v^v>^>^<v<<^vv^>>^<<^v<>vv<vv>vv<>>>v<v^>v>vv^>vv>v>><vvv><v<><^^^^<^^>v>^><<v<v>^v^^<<><<^^v<<>>>^<>^>>^><v^vvv<v^^<<^>^v>vv>>>^<^v^^v<v>>v^v^<<v>^v^v<^><>>><v>^<<v>^<><v^<<<^v<v<<vv>^<>vv<<vv<v<<<><^^>^<^>><^^v<>>v<^vv>^<<><>v^>^^<v^v^>^<<^vv^>v<>>^^>>^<vv<>v<v><v^<><v<^>><v^^><^^^^<>^v^v^^^>^v<v<>^<>>v^v><>>v<^v>>^v<vv<><>v>v<v^<>v>>^>>^vvv<v><>>vv<v^<^^<<>^^^vv><^v><<>>vv<>^<<<<<>^^^>>^><><<<v^^v<^><^>^^vv>^v><<v^^<^<>>^>>>^>^>><>>^v^<v^<v>v>v^>v>^vv^<vvv<v>^^vv^<<^><v^<<><^vvvv>><^>>^^^^>>>v^<v><^<^<^<^v^>>^v<v>>^><<<<<>>><>v<v^^<^v^<>^v<>v<><>v<v>vv<^><v<^^<v^vvv<>><^>vvv^v>v^v><>v>^>><^<>^^>vvvv<\r\nv<<>^>v><^^^<^v^>^v<><vvv>>^<>>><v^^>vv<^^v>v<^^<<^>^>v>^vvv<<v^<>^>>>v^v>><^v<v<>v^>><>vv<><<<>vv^v>>^<v>>v<v<<<>^<^v^^<^>><^^><><^>>v<v>^v^^<><<>><v>vv>v><<^v>v>>^v>>^>>^<^v<v<<v^>^>v>v>>v>v<<<<><^vv<<<^>^^vvv<<>vvv<v<vv>>>vv^>><>vvv^^><<<>><v<^<>v>^v<v<^v^>>^>v^<<^><><v^^<>^v^<><><v>v^<v^vv><^<^<^^>^>^^<v>^<^v^^><v<<v<<><>^v<^v><<^<<^v>^>^v<v<v^v<vv>v<^v>>^^<^^vvvv<^<^<>vv<v>^<v>v>vv^vv<<^v<^<<^<<v>^^>><v<>v<<<>v<<>^v<<^vv^<v^v<><v^<^v><^vv<^><<v><<<v^v^<v<><v<>><v^^v>^v^>^^v^>v>^v>>><v^<>^<><<v<^^<<v^<<v<v<>vv>^^^>v>>>^^>>>v^v>^v>>v<^v^<><vvv<<^>v^^><vv<<vvv^<><<v>>v>^^v<^v<v<^<v>v<v>vv^><>^<^^><>><<>^^<>^^v<>>^^^>>vvv^^<^v^>v<>v^>>v>>v^>^^>v^<v^>vv^v>^>^v<<^vv<v<>vv>vv<^>^>^><^>^<>v<>^v>vv^<^^<<^^v<^vv>^>vv^><^^<>v<<<<>^^^vvv<<>v<<vvvvvv>^<^^<v>>v^<^vvv<>v^^v<>^^<^^>v^vv>><>v^^v^><v^<^>^v<>>>v^><v^>v>^^<><>v<>>v><>^<<><>>>><vvv^^v^>v>>vv>v^>>^v^<v^>><<>><v<^^<<^^v<><<<<v<^<>vv<^v><>v^vv<^><><<>v^<vv^^^^^vv><><^^<^>v^v>^v>^<^<^^>>^vvv<>>>v<v><<v<vv^<^v>^<v<>>^^^^<><^v<<^<>^^^^v><^v\r\n^v^v<^v>>^^<<^>^v<<^v><v>>>^<><^>v>v<v^v>v^v><<>>>>><><v<^^^<^v><vvv^^^v<>><><<>^^<>^^<vv><<<v><>^vv^vvv>^vv<v^<v<><>^><^>v>v>v^<v><^>v>^>>^>v>v<^>>^^vv^v>v<v>><<<^<^v<>v^><v>^v^v><v<^^^^v^><^^vv^><<v>><^>>v^v<<^v^vvvvv<v<<<v>^^><^>>v>>^<>>>><v^>>v><><<v^v<v<<^<<^><>^<><><<^>><<^>^<<^>vv>v>^>>^<^<>vv>^><>v<<<^>v><^^^<><>^v>>>vvvv>v^v<<vvvv>^>v^<<v^>><v>v<^>^^>^v>>v<<><^^v^<^^><>>^<v^>>v><<v<v><<^>vv><v>^^>>^v>v<^vv^>>^v>vvv>>v^^^v>>>^v>^<v><<v<>^^v<>vvv<<><<<vvvvv<><v><v^>^<<v^^v<<><<>^<>vv<>vvv<<>v^<^v>vvv<^v>><^vv>^><v^vv^>v^<<><vv^>v><v>v<<^>>^v<>^<vv>>^v>vv<v<v<^v>^v^>>v^^>>>vv^>v<^><<>v^^^<^v^>>v<^<>v<v<^<<>>^v^<><v<>>v^^><<>><^>>v<v^>^v>^<v<>v<v^v<<^v^^^<<<vv<<v<<v^v>>^>v>^<^^<vv<vv^v>^v>^<vv<>>>v^^<<^v><^v<<<^v^><<^^<<v<<><>v^>^^^<^><>v<vvvv><><><<<v<<>v^><v^<v>^<^>>><>>>^^>^v>^>^>v<^v<^v<v<vv^^<<v^^>>><^<^v<<v^v^^v^>><v>><^<><^><^^vv^<v<v>^v<<v<^v^<^<>>^^^<<v^v^^^v>^^^^^v^>><v><><>v<><><^><<vv<^<>^vv<>><^v^<^<vv<v>^v<><<v<^^^v<>>v^>^^><><<>v>v>>v^vvvv<^^<>>v>^^><<<v^v><vvv^<v<^\r\n>vv^^v<>vv<v>^>>>^^>^^^v^^v><>><><>v^vvv>>>^v>v^<><<^><vv<<v>v^>^<vvvv<>^<<v>><<^>vv^>>>>>><<><><^v<><^<^^v><^<^^<v>^^>vv>v^^v<<v^<vv>>v>vv<v>v^^v^>><^v^>>>v>v><^>v>>^<<^^v^<<>^^<>>vv^v<v^^>^^^<>^><><<>^vv^^<><>><^^v<>v>v>>^v><<^^>vv^<^v><><>vv^<vvv<v<><<<^<v^^v^v<<v<^><<v>^^<<><^^v>><^v<^vv>v^^^^v^<>v><<v<^vvvv<<<vv>v<vv^v^^^v^^<<<>^>^<v><v>^^vv<>^v<><<v<v>v<<>v><>v>>>v>><<^>>vv><<>>vv<v<<><^^<^^^v>v^v^>><v^^<>v^<<v^<<>>^<v^v><<v<^vv>^^<v<v>v<<>>>^<v><v^>^<v<<vv<<>>^>>><<>^^^><><>v<v^^^^v^^v^><>>vv>>^v<<^vv^<>vv^>>>^vv>v<<><><>^^><<<<v^v^<>vv<>><v>vv^<^<vvvvv><<>^v<v^>>v>v<<><>>v>v^v<v<><>v^<<>v^v^<^<<<>>>^>^<^<vv^vv<><vv>vv^<><>>^^><^><<^v^^>v<>v<<>><v^^><v<>>>^>>^v>><>^<^>v>v<><<v^^><^><<<v^v<^vv<>v<>^v^v<<><>>>v^>v^v><v<v^>>^>><<<>>^v>v^>>v^v<v>>^<v<v^<^^>><v>>v>v>^<<v^>^^<>>>><><^>>^^>^<^^<<><^v<>vv^<vv>v^^<<v<>>v^<^v>^vv>>>><^>v^>^^<^>v^vv<^><>^<<<>^>^>v^^v<v<<<>>>v^v^>^^<>><>^^v^^>^<<^<^<><v><>^^><<^v<v^><<v^><><>vv<>v>^<><^>>^>><>^^v^^<<<<<vv<<v<<^^<>>>v^><<^>>><v<><>><>><v^><^\r\n^<v<v>v<<^^v>v<<^>>^<v<><>v<>vv<<<<<<<^^^<^<^^>><><<<vv>^v>vv>^^>^>v>^vv><>>^^^<v<v<^>>vv>v^>v><v>><><>v^>v^>^^<^<>^^<^>vv<>^<<>>^<vv^><<><^v^>>v^v>v^>v<<vv^<v>>vvv^^<><^<v><>^>>>>>^^><<<^<v^^vv<<v<vvv^v<vv^<v<^v>v<>v^><^>^v^v<<>v><<^>>^>>^<>v<v<<vv<<<<><v<v^v^>^<<><^>v>^<<v<>v^>>v^>^^><><v<>><v<<^<vv>>^<<>vv^v^v>>>^><^^>v><<<>vv>^<<v>v<^<^><<<^<^>>vvv<v^<<<^>v^>>>>><^^vv>^^vv^v^>><^^>^<^vv<^>v<<<><v>^vvvv<^>>>v^^v>>><<^<><>v<^^<><^^<<v><v<v^>^^<v<^>^v^^>v<^^>^<><><>vv<^>^vv>^^>>>^><vv><^>>^v<><<<>v<>v<^>>><<<v><vv>>^>v^^<^<<<>^^><^v<>v><<vv^<v>v^^>^>v^<v>v>><v>><>^><^><vv>v>^<^>><v>v<><v^v>v<v^>vvvv>><^vv^<>^>>>^v<^<^><v<^>v>v^>vv^><>vv><^<><^<><<<>vvvv^v^v<vv<><v<<^<v<v^vvv>v<^v<vv>v<v>^>^^>vv^<v<<>^<^^v<><^v^>>v>v><^v^^>vv^v>v<<^^<vv^<^><^^vv>>vvv>^>^^<<v^^>^>vv<^^vv^><>>vv^>><<<^<>vv^v<v<>>v^v>^^>^vv>^>v^^<^v>>^^v<v>>^>><<<<>>^<<^^^^>vv^v>>>v<^<>><v^^<vv^^v^^<^>^v>vv<>v>>^v><vv>^vv><<vvv^<<^<<^v<<^v^^<<^<<v>v^<^v<>^>><^^^v>v^<^^>v>>^v<v<>>^<>v>^<^<vv<v^v<^^^^<v^v>v^>>^>v^<<<^v<<><v\r\n>vvv>^>^>v>><<<<^>^<><>>>^v^v><vv><<^v<>>>^<^><v^>^vv>^^vvv><^v<v<^<^^^v>v>><v<>v^^<><>>><<><<v<v^<><>^v<>vv<v<^<^><>>^<<^>>^>^><>v<^>^^^v>^v<vv<>^v>v^^>v<vv>^>>><v>v><<>vv<v^v<>v^<^>^^><v>>><<^>vv>^<>v<v^>^v^^>^v<<^><>^>v^>^>^>v>><<^v^>^vv>^>v<<>v<^<^<><>^<>^^^v><>^>^<v^>^^>v<vv>^v<<>^v^^>v^><>>v^^^^^<><>v^>^>v<^v>>vvv<>^vvv^^^^vv<>v<v<^v<><v<<<>>>vv><v>><<>><<><<<v^>>>^<<v^^^v>^<<vv>^v^<^v<^vv^<^<^>v^v>^^v><>^v>>^^^^><>>^<^^^v<<v<><<>v>v>><vv^>v^vv><<^vv^>^>^<>^^v^>^^><v><>vvvv^^>v^<vv><>^^><>>^<v<vv>vv>vv<<<v^^><>^<>>^><>><<>><>^^<<>v^v^v>v><>>>^vv<>^^<^<>v^^vv^v^^<>><v<^v>v^v<^>v<^v><^><<<^>>><<<v><>v>^><<^^>^v<<>v<<vv<<v^^<v^v><^^^<v^^><^<^><<vv<^v^<^^>^vv>>^v<>^><>^<<<>>^^>>>^v^>v>^v^>>v^^><vvv^<v>^vv>vv><<<><v^<>^>>v<^>>^>>>>^<^<v><v^^<<<^v<>v>v<^v<><>>>v<<><>><^^v^v><>>v<vv<^<v<^v^v^^v^v><v<<><^<v^^<vvv^<^>vv^v>v^>v^v<>^^^<<<<<^^<v><<>^^>^>>><<v<v^v>^^<v<v>^<<>vv><>^<^v>>^vv>^><>^v<>^^vv<<^>^^<<<>^v^>>v^><>^v<>^v>><>^>v><v><>v<^^<>v^>^>^^>^<vv^<v<^<^^<^vv<vv>^v>v<>>>>v>^^v^v^<v\r\n";

        protected override string Part1Internal(string input)
        {
            var index = input.IndexOf(Environment.NewLine + Environment.NewLine);
            var grid = input.Substring(0, index).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray()).ToArray();
            var instructions = input.Substring(index).Replace(Environment.NewLine, "");

            Coord robot = null;
            for (var x = 0; x < grid[0].Length; x++)
            {
                for (var y = 0; y < grid.Length; y++)
                {
                    if (grid[y][x] == '@')
                    {
                        robot = new Coord(x, y);
                        break;
                    }
                }
                if (robot != null) break;
            }

            foreach (var direction in instructions)
            {
                robot = MoveRobot(grid, robot, direction);
            }

            var count = 0L;
            for (var x = 0; x < grid[0].Length; x++)
            {
                for (var y = 0; y < grid.Length; y++)
                {
                    if (grid[y][x] == 'O')
                    {
                        count += ((y * 100) + x);
                    }
                }
            }


            return count.ToString();
        }

        private Coord MoveRobot(char[][] grid, Coord robot, char direction)
        {
            switch (direction)
            {
                case '<':
                    return MoveLeft(grid, robot);
                case '>':
                    return MoveRight(grid, robot);
                case '^':
                    return MoveUp(grid, robot);
                case 'v':
                    return MoveDown(grid, robot);
            }

            throw new Exception("robot go boom?");
        }

        private Coord MoveLeft(char[][] grid, Coord robot)
        {
            char[] path = grid[robot.Y];

            int x = Convert.ToInt32(robot.X);
            var nextWall = Array.LastIndexOf(path, '#', x);
            var start = nextWall >= 0 ? nextWall : 0;
            var nextEmptySpace = Array.LastIndexOf(path, '.', x, x - nextWall);
            if (nextEmptySpace >= 0)
            {
                for(var o = nextEmptySpace; o < robot.X; o++)
                {
                    path[o] = path[o + 1];
                }
                path[robot.X] = '.';
                return new Coord(robot.X - 1, robot.Y);
            }
            return robot;
        }

        private Coord MoveRight(char[][] grid, Coord robot)
        {
            char[] path = grid[robot.Y];

            int x = Convert.ToInt32(robot.X);
            var nextWall = Array.IndexOf(path, '#', x);
            var start = nextWall >= 0 ? nextWall : 0;
            var nextEmptySpace = Array.IndexOf(path, '.', x, Math.Abs(x - nextWall));
            if (nextEmptySpace >= 0)
            {
                for (var o = nextEmptySpace; o > robot.X; o--)
                {
                    path[o] = path[o - 1];
                }
                path[robot.X] = '.';
                return new Coord(robot.X + 1, robot.Y);
            }
            return robot;
        }

        private Coord MoveDown(char[][] grid, Coord robot)
        {
            char[] path = grid.Select(g => g[robot.X]).ToArray();

            int y = Convert.ToInt32(robot.Y);
            var nextWall = Array.IndexOf(path, '#', y);
            var start = nextWall >= 0 ? nextWall : 0;
            var nextEmptySpace = Array.IndexOf(path, '.', y, Math.Abs(y - nextWall));
            if (nextEmptySpace >= 0)
            {
                for (var o = nextEmptySpace; o > robot.Y; o--)
                {
                    grid[o][robot.X] = grid[o - 1][robot.X];
                }
                grid[robot.Y][robot.X] = '.';
                return new Coord(robot.X, robot.Y + 1);
            }
            return robot;
        }
        private Coord MoveUp(char[][] grid, Coord robot)
        {
            char[] path = grid.Select(g => g[robot.X]).ToArray();

            int y = Convert.ToInt32(robot.Y);
            var nextWall = Array.LastIndexOf(path, '#', y);
            var start = nextWall >= 0 ? nextWall : 0;
            var nextEmptySpace = Array.LastIndexOf(path, '.', y, y - nextWall);
            if (nextEmptySpace >= 0)
            {
                for (var o = nextEmptySpace; o < robot.Y; o++)
                {
                    grid[o][robot.X] = grid[o + 1][robot.X];
                }
                grid[robot.Y][robot.X] = '.';
                return new Coord(robot.X, robot.Y - 1);
            }
            return robot;
        }

    }
}

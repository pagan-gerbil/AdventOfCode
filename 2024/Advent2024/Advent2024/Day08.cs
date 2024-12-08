using AdventUtils;
using AdventUtils.Models;
using System.Net.Http.Headers;

namespace Advent2024;

internal class Day08 : DayBase
{
    protected override string _sample1 => "............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............";

    protected override string _part1 => ".C...............w.......................M.E......\r\n...............G........V.............Q....M......\r\nu........k...........V.y..3........Q..........4.a.\r\n..........c.9........k..................i..7..a...\r\n..............y.......................o....a......\r\n.......C...........6.......y.............E........\r\n.............................5....x............i..\r\n...............c.....wy..V.......5..............E.\r\n........k.......c....G..I............o.........m..\r\n............C....s......G......o..........5.......\r\n......................Q...............5....e...4i.\r\n.....I.....................................m.....j\r\n....9K.T.....I...c......w...................X.....\r\n................I.........w....f............3..e.N\r\nC............9..........6..............7...3......\r\n...Z........K.......T.................6...........\r\n......Z..................6...............HN.E.m...\r\n...K...........................1....N...e.o..X....\r\n............hz......................7........j....\r\n.........9......U.R......n.....4.Q..L...X.........\r\n..................A...........S.......0...........\r\n...............l.........p...........2.3M.......x.\r\n.h........................U.................g.....\r\n...Hld...........A..W.......................1x....\r\n.....Z.....n.......lp...e............Xj...L.......\r\n........hU................7...j...S...............\r\n......n............U..........D....S..q...........\r\n....H.....d.r..T..............0..........L.S......\r\n......H......A..T...lp.........LK....1.....2.f.x..\r\n....Z............................g....4...........\r\n..d..r............V...............f..g....2.......\r\n.rn.........D............Pp........q....g.........\r\n..................................................\r\n...................D...0.........Y..t...P.q.......\r\n.......R.s.......................q.P..1...........\r\n...........h..........................2.........f.\r\n........................W.........................\r\n...8...........O................k.................\r\n....rY...........D................P...............\r\n....................O...u.........................\r\n..s..................F............................\r\n...................R......F.......................\r\n......8...........z0....F................J.W......\r\n...................F..z................u..........\r\n..............R.........O.............v.Jt........\r\ns.............8.........m........J.t............v.\r\n......Y.....M........................u..tv........\r\n.................................................v\r\n..................................................\r\n.................z.W..................J...........";

    private class AntennaPoint(int x, int y, char antenna) : Coord(x, y)
    {
        public char Antenna { get; } = antenna;
    }

    protected override string Part1Internal(string input)
    {
        var grid = input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

        var antinodes = new HashSet<Coord>();

        var antennae = grid
            .SelectMany((x, i) => x.Select((y, j) => new AntennaPoint(i, j, y)))
            .Where(x => x.Antenna != '.')
            .GroupBy(x => x.Antenna)
            .ToDictionary(x => x.Key, x => x.ToArray());

        foreach (var a in antennae)
        {
            var q = new Stack<Coord>(a.Value);
            while (q.Any())
            {
                var test = q.Pop();
                var r = new Stack<Coord>(q);
                while (r.Any())
                {
                    var test2 = r.Pop();
                    var diff = new Coord(test.X - test2.X, test.Y - test2.Y);
                    var an1 = new Coord(
                        test.X + diff.X,
                        test.Y + diff.Y);
                    var an2 = new Coord(
                        test2.X - diff.X,
                        test2.Y - diff.Y);
                    if (an1.X >= 0 && an1.X < grid.Length && an1.Y >= 0 && an1.Y < grid.Length)
                        antinodes.Add(an1);
                    if (an2.X >= 0 && an2.X < grid.Length && an2.Y >= 0 && an2.Y < grid.Length)
                        antinodes.Add(an2);
                }
            }
        }

        return antinodes.Count().ToString();
    }

    protected override string Part2Internal(string input)
    {
        var grid = input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

        var antinodes = new HashSet<Coord>();

        var antennae = grid
            .SelectMany((x, i) => x.Select((y, j) => new AntennaPoint(i, j, y)))
            .Where(x => x.Antenna != '.')
            .GroupBy(x => x.Antenna)
            .ToDictionary(x => x.Key, x => x.ToArray());

        foreach (var a in antennae)
        {
            var q = new Stack<Coord>(a.Value);
            while (q.Any())
            {
                var test = q.Pop();
                var r = new Stack<Coord>(q);
                while (r.Any())
                {
                    var test2 = r.Pop();
                    var diff = new Coord(test.X - test2.X, test.Y - test2.Y);
                    var an1 = test;
                    while(an1.X < grid.Length && an1.Y < grid.Length && an1.X >= 0 && an1.Y >= 0)
                    {
                        antinodes.Add(an1);
                        an1 = new Coord(
                            an1.X + diff.X,
                            an1.Y + diff.Y);
                    }
                    var an2 = test2;
                    while (an2.X < grid.Length && an2.Y < grid.Length && an2.X >= 0 && an2.Y >= 0)
                    {
                        antinodes.Add(an2);
                        an2 = new Coord(
                            an2.X - diff.X,
                            an2.Y - diff.Y);
                    }
                }
            }
        }

        return antinodes.Count().ToString();
    }
}

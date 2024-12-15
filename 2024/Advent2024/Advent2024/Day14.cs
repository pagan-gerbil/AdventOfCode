using AdventUtils;
using AdventUtils.Models;
using Microsoft.Win32;
using System.Windows.Markup;
using System.Xml;

namespace Advent2024;

internal class Day14 : DayBase
{
    protected override string _sample1 => "p=0,4 v=3,-3\r\np=6,3 v=-1,-3\r\np=10,3 v=-1,2\r\np=2,0 v=2,-1\r\np=0,0 v=1,3\r\np=3,0 v=-2,-2\r\np=7,6 v=-1,-3\r\np=3,0 v=-1,-2\r\np=9,3 v=2,3\r\np=7,3 v=-1,2\r\np=2,4 v=2,-3\r\np=9,5 v=-3,-3";

    protected override string _part1 => "p=69,11 v=-25,6\r\np=67,84 v=-79,-12\r\np=24,5 v=20,-73\r\np=32,41 v=55,-12\r\np=16,81 v=89,-62\r\np=87,40 v=42,-94\r\np=59,75 v=61,94\r\np=79,18 v=-43,14\r\np=33,64 v=-43,-54\r\np=30,32 v=87,66\r\np=65,69 v=-52,80\r\np=65,101 v=62,-22\r\np=85,18 v=-99,-7\r\np=35,41 v=57,38\r\np=63,33 v=-71,-32\r\np=45,102 v=84,-39\r\np=14,75 v=-19,-67\r\np=44,74 v=-89,-9\r\np=87,95 v=37,-42\r\np=88,26 v=-95,39\r\np=42,2 v=61,76\r\np=12,34 v=-78,-32\r\np=64,22 v=-77,-32\r\np=12,25 v=-15,42\r\np=14,56 v=88,73\r\np=81,39 v=-39,-74\r\np=9,76 v=-27,49\r\np=45,46 v=-54,-87\r\np=53,101 v=67,23\r\np=81,71 v=36,32\r\np=50,87 v=-68,51\r\np=55,37 v=18,30\r\np=84,65 v=65,-17\r\np=51,80 v=-60,-1\r\np=40,78 v=-57,32\r\np=28,5 v=-29,-64\r\np=9,98 v=66,-14\r\np=6,15 v=-38,-94\r\np=72,89 v=-19,31\r\np=46,23 v=47,-71\r\np=40,67 v=55,53\r\np=59,49 v=5,11\r\np=11,102 v=-93,-76\r\np=12,74 v=17,45\r\np=80,43 v=-65,-74\r\np=6,51 v=-1,57\r\np=6,24 v=80,-11\r\np=61,46 v=-77,66\r\np=30,28 v=-76,49\r\np=80,21 v=62,42\r\np=25,4 v=29,89\r\np=51,82 v=27,-67\r\np=50,35 v=1,-46\r\np=7,99 v=-6,11\r\np=47,45 v=-37,-86\r\np=79,43 v=-21,58\r\np=69,55 v=37,74\r\np=16,42 v=-78,71\r\np=93,101 v=36,52\r\np=84,62 v=42,-58\r\np=56,16 v=3,43\r\np=99,55 v=2,66\r\np=66,28 v=-19,-3\r\np=77,81 v=88,-22\r\np=95,5 v=-24,68\r\np=59,58 v=-77,37\r\np=58,89 v=-77,44\r\np=27,64 v=26,28\r\np=44,22 v=61,9\r\np=57,44 v=41,-74\r\np=38,18 v=58,-64\r\np=82,39 v=-65,10\r\np=100,84 v=-12,-59\r\np=9,29 v=74,-53\r\np=48,0 v=6,-1\r\np=28,52 v=-26,-87\r\np=86,14 v=-22,17\r\np=86,27 v=-19,-78\r\np=11,2 v=11,26\r\np=97,32 v=-29,-12\r\np=95,8 v=74,-7\r\np=47,28 v=75,-40\r\np=30,77 v=23,-38\r\np=62,56 v=-67,81\r\np=45,80 v=-8,-50\r\np=71,30 v=4,-94\r\np=78,30 v=-94,-69\r\np=43,79 v=-40,-63\r\np=29,81 v=61,-47\r\np=13,53 v=-24,29\r\np=1,48 v=-50,33\r\np=22,68 v=-41,-92\r\np=94,97 v=-24,-47\r\np=91,65 v=-44,-66\r\np=46,4 v=9,47\r\np=28,89 v=19,-11\r\np=60,92 v=20,41\r\np=75,33 v=45,-13\r\np=81,44 v=82,17\r\np=58,13 v=-37,-60\r\np=13,4 v=69,72\r\np=57,44 v=79,-11\r\np=30,5 v=98,68\r\np=19,87 v=-84,93\r\np=2,96 v=17,68\r\np=51,93 v=-11,52\r\np=3,11 v=19,68\r\np=15,26 v=80,-55\r\np=34,64 v=-26,-13\r\np=61,23 v=-5,-77\r\np=49,1 v=96,-82\r\np=32,6 v=-3,-31\r\np=18,63 v=-32,86\r\np=59,15 v=71,-73\r\np=20,37 v=40,-53\r\np=28,32 v=-6,92\r\np=42,15 v=58,47\r\np=58,77 v=96,-71\r\np=28,69 v=-78,-30\r\np=78,72 v=-38,2\r\np=36,24 v=-75,-73\r\np=84,9 v=77,-76\r\np=92,4 v=61,-84\r\np=16,91 v=-47,15\r\np=53,59 v=-8,16\r\np=17,27 v=58,-34\r\np=84,98 v=-85,-18\r\np=91,9 v=16,-93\r\np=43,32 v=21,99\r\np=7,46 v=-70,70\r\np=77,44 v=-42,55\r\np=48,53 v=29,17\r\np=90,49 v=48,-66\r\np=11,18 v=-76,-44\r\np=89,87 v=-7,-47\r\np=84,52 v=94,-37\r\np=55,47 v=-61,-95\r\np=36,102 v=75,-43\r\np=96,90 v=-88,7\r\np=99,27 v=-98,89\r\np=9,1 v=60,-2\r\np=13,101 v=14,76\r\np=88,20 v=-53,-27\r\np=55,9 v=67,-11\r\np=65,88 v=56,19\r\np=64,86 v=47,-51\r\np=77,4 v=-35,-69\r\np=56,71 v=44,3\r\np=74,18 v=-66,92\r\np=98,40 v=-73,99\r\np=8,15 v=-83,74\r\np=34,12 v=6,-19\r\np=73,14 v=21,10\r\np=51,70 v=12,86\r\np=86,36 v=71,-24\r\np=65,41 v=-51,-25\r\np=30,69 v=78,57\r\np=2,21 v=96,85\r\np=56,11 v=87,-10\r\np=23,42 v=14,13\r\np=20,57 v=-44,94\r\np=42,71 v=-70,-58\r\np=36,5 v=3,35\r\np=89,33 v=-88,38\r\np=61,23 v=-47,37\r\np=57,68 v=-28,-75\r\np=57,102 v=9,-77\r\np=49,75 v=-57,63\r\np=11,32 v=11,-53\r\np=29,15 v=-6,-75\r\np=45,65 v=29,7\r\np=62,74 v=60,89\r\np=94,99 v=27,-3\r\np=97,68 v=25,49\r\np=30,12 v=-59,72\r\np=51,61 v=-11,49\r\np=56,68 v=21,28\r\np=73,73 v=-80,-1\r\np=6,42 v=60,13\r\np=8,23 v=80,22\r\np=16,29 v=86,38\r\np=100,88 v=74,-55\r\np=93,101 v=36,-97\r\np=89,13 v=-86,-72\r\np=3,30 v=28,-90\r\np=9,26 v=-27,-28\r\np=10,86 v=-33,75\r\np=94,49 v=87,-5\r\np=0,62 v=5,54\r\np=58,20 v=64,76\r\np=13,74 v=-98,-87\r\np=83,96 v=-10,39\r\np=68,8 v=-94,43\r\np=84,70 v=-97,48\r\np=52,101 v=-43,55\r\np=72,33 v=66,23\r\np=93,74 v=97,32\r\np=71,17 v=-31,38\r\np=50,36 v=-8,95\r\np=11,78 v=83,-52\r\np=71,97 v=-45,93\r\np=17,76 v=14,47\r\np=12,19 v=-38,55\r\np=27,42 v=-51,70\r\np=46,96 v=-75,80\r\np=45,80 v=41,36\r\np=40,39 v=81,-12\r\np=29,48 v=78,25\r\np=16,33 v=8,59\r\np=64,79 v=-5,-34\r\np=82,79 v=-71,86\r\np=43,27 v=54,-82\r\np=50,30 v=40,-99\r\np=22,41 v=20,-86\r\np=40,79 v=72,-71\r\np=36,6 v=-77,-75\r\np=18,29 v=-32,-69\r\np=10,99 v=14,-14\r\np=74,9 v=-71,-85\r\np=29,84 v=78,81\r\np=1,62 v=-57,21\r\np=6,31 v=-87,-69\r\np=23,23 v=20,88\r\np=90,38 v=-28,79\r\np=10,32 v=-64,66\r\np=36,8 v=-60,63\r\np=43,90 v=35,-26\r\np=82,63 v=77,-72\r\np=21,94 v=-46,-39\r\np=57,60 v=-57,41\r\np=76,8 v=31,-45\r\np=7,20 v=-35,-53\r\np=9,50 v=8,-45\r\np=81,0 v=13,-88\r\np=92,77 v=13,49\r\np=28,25 v=-52,-7\r\np=78,86 v=42,40\r\np=86,80 v=-7,-30\r\np=90,58 v=17,61\r\np=38,51 v=-67,-60\r\np=24,45 v=77,-33\r\np=40,16 v=81,-52\r\np=61,85 v=70,-92\r\np=25,16 v=-42,-77\r\np=44,67 v=35,-79\r\np=37,55 v=67,-87\r\np=79,48 v=59,-24\r\np=23,11 v=-61,-89\r\np=6,22 v=-70,96\r\np=5,28 v=60,-65\r\np=13,40 v=98,-95\r\np=48,18 v=33,-58\r\np=11,98 v=-15,93\r\np=99,24 v=53,-39\r\np=76,22 v=99,-40\r\np=82,12 v=48,5\r\np=33,86 v=-37,-5\r\np=40,50 v=10,45\r\np=14,4 v=-26,-27\r\np=2,42 v=57,-32\r\np=24,16 v=32,84\r\np=14,56 v=-90,53\r\np=100,59 v=16,66\r\np=91,95 v=65,73\r\np=89,85 v=48,-59\r\np=71,64 v=98,76\r\np=91,31 v=89,-21\r\np=21,66 v=20,82\r\np=56,72 v=-17,81\r\np=12,74 v=17,-12\r\np=76,99 v=30,60\r\np=29,13 v=-26,26\r\np=65,90 v=55,37\r\np=28,34 v=49,79\r\np=90,26 v=77,84\r\np=34,40 v=-84,70\r\np=72,4 v=7,63\r\np=98,100 v=86,82\r\np=92,88 v=80,-31\r\np=64,28 v=-51,-24\r\np=89,38 v=97,-94\r\np=62,1 v=-63,92\r\np=54,54 v=-69,-17\r\np=73,69 v=-42,-42\r\np=99,8 v=2,-43\r\np=92,11 v=45,96\r\np=52,16 v=47,-48\r\np=95,77 v=46,-90\r\np=42,53 v=-38,41\r\np=12,90 v=-50,93\r\np=9,10 v=16,-38\r\np=11,39 v=5,50\r\np=27,96 v=63,-49\r\np=37,25 v=82,29\r\np=3,21 v=-70,-19\r\np=51,99 v=-36,70\r\np=26,55 v=-6,16\r\np=56,21 v=-30,10\r\np=70,19 v=-45,38\r\np=53,11 v=79,-73\r\np=16,12 v=34,5\r\np=83,51 v=33,57\r\np=42,49 v=96,74\r\np=37,61 v=-43,82\r\np=60,42 v=-82,-26\r\np=46,16 v=15,47\r\np=54,25 v=21,14\r\np=16,13 v=-6,75\r\np=2,82 v=-44,-88\r\np=84,38 v=-24,95\r\np=2,36 v=-7,58\r\np=52,57 v=-99,24\r\np=77,39 v=-80,21\r\np=76,1 v=1,94\r\np=16,10 v=-4,-30\r\np=93,51 v=74,95\r\np=32,16 v=78,55\r\np=62,83 v=44,-94\r\np=10,69 v=-78,45\r\np=49,55 v=-21,-54\r\np=28,56 v=78,45\r\np=60,24 v=-5,21\r\np=19,2 v=4,2\r\np=31,15 v=46,9\r\np=62,51 v=-91,74\r\np=5,89 v=-58,97\r\np=81,40 v=-91,-85\r\np=47,83 v=-37,-26\r\np=75,16 v=-68,-52\r\np=87,26 v=-82,34\r\np=75,93 v=-19,36\r\np=47,31 v=93,71\r\np=14,69 v=-93,-99\r\np=81,72 v=-93,-85\r\np=34,50 v=77,-7\r\np=14,29 v=-26,-78\r\np=90,23 v=-53,54\r\np=18,7 v=40,37\r\np=59,62 v=18,-25\r\np=40,6 v=-14,-60\r\np=88,33 v=65,-44\r\np=33,95 v=7,-26\r\np=17,83 v=69,-88\r\np=11,47 v=63,8\r\np=93,92 v=59,25\r\np=40,9 v=6,27\r\np=38,87 v=-66,-75\r\np=51,25 v=-83,-65\r\np=88,46 v=19,37\r\np=26,37 v=-90,62\r\np=22,42 v=-84,13\r\np=39,85 v=-43,69\r\np=67,61 v=-19,-51\r\np=21,50 v=-78,92\r\np=72,9 v=-22,-89\r\np=60,25 v=-5,96\r\np=41,8 v=-52,-74\r\np=89,65 v=-68,-13\r\np=15,95 v=41,2\r\np=37,46 v=-67,56\r\np=26,19 v=72,-15\r\np=92,99 v=-27,-43\r\np=37,39 v=-34,-53\r\np=16,36 v=-81,-98\r\np=0,51 v=-18,25\r\np=78,39 v=8,-91\r\np=1,94 v=-18,-18\r\np=74,3 v=-82,-11\r\np=95,37 v=22,-20\r\np=58,35 v=-90,16\r\np=24,51 v=-74,-49\r\np=96,61 v=-70,36\r\np=39,89 v=90,7\r\np=74,33 v=59,-86\r\np=78,26 v=59,38\r\np=78,24 v=59,-3\r\np=3,87 v=-96,-88\r\np=13,13 v=49,-81\r\np=30,1 v=-49,27\r\np=49,13 v=-37,-85\r\np=8,62 v=-49,-96\r\np=68,43 v=99,-16\r\np=14,67 v=75,41\r\np=57,60 v=-12,-40\r\np=72,64 v=59,20\r\np=34,2 v=-26,-82\r\np=89,51 v=-95,24\r\np=85,96 v=48,85\r\np=50,47 v=-66,-12\r\np=64,46 v=62,-20\r\np=100,42 v=48,50\r\np=80,84 v=1,-96\r\np=14,28 v=-15,95\r\np=14,7 v=17,2\r\np=7,90 v=-64,19\r\np=55,63 v=-28,73\r\np=73,8 v=94,-31\r\np=89,101 v=-79,2\r\np=52,0 v=44,-11\r\np=75,34 v=-19,46\r\np=34,72 v=-23,49\r\np=26,29 v=23,-24\r\np=49,45 v=41,58\r\np=20,26 v=17,79\r\np=81,24 v=36,34\r\np=1,70 v=74,16\r\np=48,11 v=15,-7\r\np=64,66 v=76,-71\r\np=46,50 v=-92,37\r\np=65,59 v=-13,-70\r\np=8,101 v=-51,83\r\np=60,99 v=-39,33\r\np=45,30 v=-5,55\r\np=58,67 v=67,82\r\np=94,98 v=88,-26\r\np=16,68 v=39,35\r\np=10,79 v=-41,7\r\np=45,80 v=58,69\r\np=47,44 v=-17,82\r\np=22,96 v=-22,-23\r\np=5,93 v=5,35\r\np=13,98 v=77,64\r\np=27,17 v=-17,-62\r\np=51,15 v=-17,87\r\np=29,68 v=-49,-68\r\np=100,85 v=35,97\r\np=69,54 v=18,95\r\np=69,42 v=56,99\r\np=17,28 v=66,13\r\np=6,43 v=97,-65\r\np=40,96 v=-95,64\r\np=34,23 v=-95,-75\r\np=74,99 v=-62,89\r\np=4,82 v=83,-51\r\np=85,80 v=16,-75\r\np=0,41 v=-47,91\r\np=75,35 v=-94,91\r\np=48,9 v=95,-27\r\np=65,82 v=24,-1\r\np=47,46 v=-36,72\r\np=22,10 v=69,49\r\np=42,50 v=-86,-13\r\np=42,3 v=60,-41\r\np=39,26 v=-60,-42\r\np=26,57 v=84,41\r\np=76,70 v=-30,73\r\np=16,84 v=15,-26\r\np=44,53 v=-83,15\r\np=32,59 v=-23,53\r\np=31,99 v=-17,-98\r\np=49,27 v=-97,4\r\np=71,17 v=-41,-69\r\np=88,99 v=-82,6\r\np=33,8 v=46,2\r\np=29,45 v=46,-54\r\np=84,78 v=88,-34\r\np=65,96 v=-71,31\r\np=94,71 v=34,16\r\np=27,76 v=98,73\r\np=84,70 v=25,74\r\np=67,69 v=4,-9\r\np=51,91 v=90,22\r\np=1,40 v=34,83\r\np=98,4 v=34,-66\r\np=74,85 v=-91,77\r\np=51,32 v=87,-94\r\np=68,85 v=-68,3\r\np=65,7 v=12,-42\r\np=16,69 v=40,28\r\np=65,53 v=76,25\r\np=55,97 v=95,93\r\np=94,43 v=-99,91\r\np=92,12 v=79,4\r\np=46,84 v=15,7\r\np=51,39 v=-80,46\r\np=14,43 v=-87,21\r\np=15,18 v=-12,51\r\np=79,58 v=16,78\r\np=97,12 v=-5,-5\r\np=33,27 v=80,58\r\np=76,72 v=-97,89\r\np=16,46 v=-61,62\r\np=22,53 v=51,-40\r\np=8,62 v=59,50\r\np=56,79 v=-5,65\r\np=83,7 v=39,-81\r\np=28,35 v=91,65\r\np=76,11 v=-89,-89\r\np=62,99 v=33,17\r\np=83,57 v=66,24\r\np=84,43 v=44,76\r\np=0,8 v=-86,-62\r\np=100,13 v=51,-85\r\np=67,38 v=67,34\r\np=48,11 v=-66,51\r\np=46,80 v=67,69\r\np=79,17 v=62,26\r\np=8,100 v=-73,-80\r\np=99,60 v=-73,-50\r\np=89,43 v=-82,-24";

    protected override string Part1Internal(string input)
    {
        var robots = input.Split(Environment.NewLine).Select(x=>new Robot(ParseCoord(x,false), ParseCoord(x,true))).ToArray();

        var maxX = 101;
        var maxY = 103;

        for(var seconds = 0; seconds < 100; seconds++)
        {
            foreach(var r in robots) r.Move(maxX, maxY);
        }

        var quadrant1 = robots.Count(x => x.Position.X < maxX / 2 && x.Position.Y < maxY / 2);
        var quadrant2 = robots.Count(x => x.Position.X > maxX / 2 && x.Position.Y < maxY / 2);
        var quadrant3 = robots.Count(x => x.Position.X < maxX / 2 && x.Position.Y > maxY / 2);
        var quadrant4 = robots.Count(x => x.Position.X > maxX / 2 && x.Position.Y > maxY / 2);

        return (quadrant1 * quadrant2 * quadrant3 * quadrant4).ToString();
    }

    protected override string Part2Internal(string input)
    {
        var robots = input.Split(Environment.NewLine).Select(x => new Robot(ParseCoord(x, false), ParseCoord(x, true))).ToArray();
        if (input != _part1) return string.Empty;
        var maxX = 101;
        var maxY = 103;
        var seconds = 0;

        while (true) 
        {
            foreach (var r in robots) r.Move(maxX, maxY);

            for (var j = 0; j < maxY; j++)
            {
                for (var i = 0; i < maxX; i++)
                {
                    var count = robots.Count(r=>r.Position.X == i && r.Position.Y == j);
                    if (count == 0) Console.Write(' '); else Console.Write('X');
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(seconds++);
            var k = Console.ReadKey();
            if (k.KeyChar == 'q') break;
        }

        var quadrant1 = robots.Count(x => x.Position.X < maxX / 2 && x.Position.Y < maxY / 2);
        var quadrant2 = robots.Count(x => x.Position.X > maxX / 2 && x.Position.Y < maxY / 2);
        var quadrant3 = robots.Count(x => x.Position.X < maxX / 2 && x.Position.Y > maxY / 2);
        var quadrant4 = robots.Count(x => x.Position.X > maxX / 2 && x.Position.Y > maxY / 2);

        return (quadrant1 * quadrant2 * quadrant3 * quadrant4).ToString();

    }

    private Coord ParseCoord(string input, bool reverse)
    {
        var v = !reverse
            ? input.Substring(input.IndexOf('=') + 1, input.IndexOf(' ') - input.IndexOf('='))
            : input.Substring(input.LastIndexOf('=') + 1);

        var values = v.Split(',').Select(int.Parse).ToArray();
        return new Coord(values[0], values[1]);
    }

    private class Robot(Coord p, Coord v)
    {
        private readonly Coord v = v;

        public Coord Position { get; private set; } = p;

        public void Move(int maxX, int maxY)
        {
            long x = Position.X + v.X;
            long y = Position.Y + v.Y;

            if (x >= maxX) x -= maxX;
            if (x < 0) x += maxX;
            if (y >= maxY) y -= maxY;
            if (y < 0) y += maxY;

            Position = new Coord(x, y);
        }
    }
}

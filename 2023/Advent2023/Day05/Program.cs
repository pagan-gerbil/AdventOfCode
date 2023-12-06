﻿using System.Data;
using System.Net.Http.Headers;

namespace Day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = _input1;

            Puzzle1(input);
            Puzzle2(input);
        }

        private static IReadOnlyDictionary<string, IEnumerable<Map>> GetMaps(IEnumerable<string> lines)
        {
            var maps = new Dictionary<string, IEnumerable<Map>>();

            IList<Map> currentMap = new List<Map>();

            foreach (var line in lines.Skip(1))
            {
                if (char.IsLetter(line[0]))
                {
                    currentMap = new List<Map>();
                    maps.Add(line.Substring(0, line.IndexOf('-')), currentMap);
                    continue;
                }

                var numbers = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                currentMap.Add(new Map(numbers[1], numbers[0], numbers[2]));
            }

            return maps;
        }

        private static void Puzzle1(string input)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var maps = GetMaps(lines);
            var initialSeeds = lines[0].Substring(lines[0].IndexOf(':') + 1).Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);

            var lowest = long.MaxValue;

            foreach (var seed in initialSeeds)
            {
                var newLowest = GetLowestLocationNumber(lines, maps, seed);
                lowest = newLowest < lowest ? newLowest : lowest;
            }
            Console.WriteLine($"lowest location: {lowest}");
        }

        private static void Puzzle2(string input)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var maps = GetMaps(lines);

            var allNumbers = lines[0].Substring(lines[0].IndexOf(':') + 1).Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            var lowest = long.MaxValue;

            Console.WriteLine();
            for (var i = 0; i < allNumbers.Length; i += 2)
            {
                var seed = new SeedRange(allNumbers[i], allNumbers[i + 1] - 1);

                var newLowest = GetLowestLocationNumber(maps, seed);
                lowest = newLowest < lowest ? newLowest : lowest;

                var cursor = Console.GetCursorPosition();
                Console.SetCursorPosition(0, cursor.Top - 1);
                Console.WriteLine($"Processing {i}");
            }

            Console.WriteLine($"lowest location: {lowest}");
        }

        private static long GetLowestLocationNumber(IReadOnlyDictionary<string, IEnumerable<Map>> maps, SeedRange firstSeed)
        {
            var inQueue = new Queue<SeedRange>();
            inQueue.Enqueue(firstSeed);
            foreach (var map in maps)
            {
                var outQueue = new Queue<SeedRange>();

                while (inQueue.Any())
                {
                    var seedRange = inQueue.Dequeue();

                    var mapRange = map.Value.SingleOrDefault(x => x.SourceStart <= seedRange.Start && x.SourceEnd >= seedRange.Start);

                    if (mapRange == null)
                    {
                        mapRange = map.Value.SingleOrDefault(x => x.SourceStart <= seedRange.Start + seedRange.Range && x.SourceEnd >= seedRange.Start + seedRange.Range);
                        if (mapRange == null)
                        {
                            outQueue.Enqueue(seedRange);
                            continue;
                        }
                        else
                        {
                            var distance = mapRange.SourceStart - seedRange.Start;
                            outQueue.Enqueue(new SeedRange(seedRange.Start, distance));
                            inQueue.Enqueue(new SeedRange(mapRange.SourceStart, seedRange.Range - distance));
                            continue;
                        }
                    }

                    if (mapRange.SourceEnd <= seedRange.Start + seedRange.Range)
                    {
                        var distance = seedRange.Start - mapRange.SourceStart;
                        var remainder = seedRange.Start + seedRange.Range - mapRange.SourceEnd;
                        outQueue.Enqueue(new SeedRange(mapRange.DestinationStart + distance, seedRange.Range - remainder));
                        if (remainder > 0)
                        {
                            inQueue.Enqueue(new SeedRange(mapRange.SourceEnd + 1, remainder));
                        }
                        continue;
                    }

                    if (mapRange.SourceEnd >= seedRange.Start + seedRange.Range)
                    {
                        var distance = seedRange.Start - mapRange.SourceStart;
                        outQueue.Enqueue(new SeedRange(mapRange.DestinationStart + distance, seedRange.Range));
                        continue;
                    }

                    throw new Exception("Should never reach here...");
                }

                inQueue = outQueue;
            }

            return inQueue.Select(x => x.Start).Min();
        }

        private static long GetLowestLocationNumber(string[] lines, IReadOnlyDictionary<string, IEnumerable<Map>> maps, long seed)
        {
            var steps = new List<long>();

            var currentValue = seed;
            foreach (var mapList in maps)
            {
                var map = mapList.Value.SingleOrDefault(x => x.SourceStart <= currentValue && x.SourceEnd >= currentValue);
                currentValue = map != null
                    ? map.DestinationStart + (currentValue - map.SourceStart)
                    : currentValue;
                steps.Add(currentValue);
            }

            return steps.Last();
        }


        private static long GetLowestLocationNumber(string[] lines, IEnumerable<long> initialSeeds)
        {
            var maps = new Dictionary<string, IEnumerable<Map>>();

            IList<Map> currentMap = new List<Map>();

            foreach (var line in lines.Skip(1))
            {
                if (char.IsLetter(line[0]))
                {
                    currentMap = new List<Map>();
                    maps.Add(line.Substring(0, line.IndexOf('-')), currentMap);
                    continue;
                }

                var numbers = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                currentMap.Add(new Map(numbers[1], numbers[0], numbers[2]));
            }

            var steps = initialSeeds.ToDictionary(x => x, x => new List<long>());

            foreach (var seed in initialSeeds)
            {
                var currentValue = seed;
                foreach (var mapList in maps)
                {
                    var map = mapList.Value.SingleOrDefault(x => x.SourceStart <= currentValue && x.SourceEnd >= currentValue);
                    currentValue = map != null
                        ? map.DestinationStart + (currentValue - map.SourceStart)
                        : currentValue;
                    steps[seed].Add(currentValue);
                }
            }

            Console.WriteLine($"There are {maps.Count} maps");
            return steps.Values.Select(x => x.Last()).Min();
        }

        private record Map
        {
            public Map(long sourceStart, long destinationStart, long rangeLength)
            {
                SourceStart = sourceStart;
                SourceEnd = sourceStart + rangeLength - 1;
                DestinationStart = destinationStart;
            }

            public long SourceStart { get; set; }
            public long SourceEnd { get; set; }
            public long DestinationStart { get; set; }
        }

        public record SeedRange
        {
            public SeedRange(long start, long range)
            {
                Start = start;
                Range = range;
            }

            public long Start { get; set;  }
            public long Range { get; set; }
        }

        private static string _test1 = "seeds: 79 14 55 13\r\n\r\nseed-to-soil map:\r\n50 98 2\r\n52 50 48\r\n\r\nsoil-to-fertilizer map:\r\n0 15 37\r\n37 52 2\r\n39 0 15\r\n\r\nfertilizer-to-water map:\r\n49 53 8\r\n0 11 42\r\n42 0 7\r\n57 7 4\r\n\r\nwater-to-light map:\r\n88 18 7\r\n18 25 70\r\n\r\nlight-to-temperature map:\r\n45 77 23\r\n81 45 19\r\n68 64 13\r\n\r\ntemperature-to-humidity map:\r\n0 69 1\r\n1 0 69\r\n\r\nhumidity-to-location map:\r\n60 56 37\r\n56 93 4";
        private static string _input1 = "seeds: 565778304 341771914 1736484943 907429186 3928647431 87620927 311881326 149873504 1588660730 119852039 1422681143 13548942 1095049712 216743334 3671387621 186617344 3055786218 213191880 2783359478 44001797\r\n\r\nseed-to-soil map:\r\n1136439539 28187015 34421000\r\n4130684560 3591141854 62928737\r\n2493176649 2843539493 216586902\r\n4035246184 3979580848 40675839\r\n784987951 2449883248 10512167\r\n1230114095 458474273 89127842\r\n3591141854 4278550666 16416630\r\n795500118 1007741104 49669915\r\n4075922023 4020256687 54762537\r\n1170860539 385724159 59253556\r\n1754134353 1447758461 710855281\r\n2464989634 0 28187015\r\n3811089926 3654070591 224156258\r\n367106182 564462768 34737691\r\n0 3060126395 64826339\r\n1438999297 87449756 298274403\r\n1319241937 901480302 106260802\r\n1425502739 444977715 13496558\r\n906091129 2158613742 230348410\r\n401843873 2460395415 383144078\r\n1737273700 547602115 16860653\r\n64826339 599200459 302279843\r\n2709763551 1057411019 390347442\r\n845170033 2388962152 60921096\r\n3607558484 4075019224 203531442\r\n3100110993 3124952734 265337006\r\n4193613297 3878226849 101353999\r\n3365447999 62608015 24841741\r\n\r\nsoil-to-fertilizer map:\r\n2997768542 2385088490 141138894\r\n2483957796 2361581050 23507440\r\n98641524 1346083581 385280737\r\n3138907436 2256873732 8670947\r\n0 2158232208 98641524\r\n3147578383 2265544679 96036371\r\n1035235183 2879344429 108036359\r\n2567031012 2526227384 63435416\r\n740156227 2589662800 180702628\r\n2630466428 1790930094 367302114\r\n1029837856 0 5397327\r\n1143271542 5397327 1340686254\r\n483922261 2987380788 256233966\r\n2507465236 1731364318 59565776\r\n920858855 2770365428 108979001\r\n\r\nfertilizer-to-water map:\r\n1539871014 1431400479 38399903\r\n4189242304 3947275099 105724992\r\n2012473116 0 61612686\r\n3673653298 3769966020 177309079\r\n25380533 833117788 21807501\r\n143369400 1411638591 19761888\r\n2698209531 61612686 40666379\r\n401367210 2888296065 27849039\r\n3850962377 4057978463 170640183\r\n1076364770 854925289 39443942\r\n0 2048878915 25380533\r\n2682826842 1483785677 15382689\r\n4026580932 4228618646 66348650\r\n790899137 2074259448 70405647\r\n2738875910 2609016218 230235412\r\n2090748148 1854132037 12185242\r\n163131288 1499168366 238235922\r\n1115808712 3002097202 63461270\r\n545943998 1215727887 195910704\r\n4092929582 3673653298 96312722\r\n1000530579 3065558472 75834191\r\n2074085802 2916145104 16662346\r\n429216249 1737404288 116727749\r\n1578270917 2174814019 434202199\r\n2969111322 102279065 44844471\r\n1179269982 669063687 164054101\r\n2463111278 507301424 161762263\r\n741854702 2839251630 49044435\r\n3013955793 894369231 236513741\r\n861304784 2144665095 30148924\r\n1525885719 1469800382 13985295\r\n132032949 2932807450 11336451\r\n2102933390 147123536 360177888\r\n47188034 1130882972 84844915\r\n4021602560 4053000091 4978372\r\n2624873541 2944143901 57953301\r\n891453708 3141392663 109076871\r\n1343324083 1866317279 182561636\r\n\r\nwater-to-light map:\r\n1509583382 1639808290 20361832\r\n3841220400 2799952377 116887408\r\n1472887638 3349716751 36695744\r\n1375316591 4197396249 97571047\r\n1030032900 38536653 44339012\r\n3776233310 1557050237 64987090\r\n1857053855 3386412495 71799907\r\n2963593546 2694182899 38493443\r\n3758462347 1622037327 17770963\r\n1018869652 82875665 11163248\r\n1308040556 2732676342 67276035\r\n1928853762 3953749938 243646311\r\n2488961036 3503789336 239267964\r\n3562290347 3458212402 6096433\r\n3568386780 1308040556 190075567\r\n2728229000 1997029610 235364546\r\n215668494 0 38536653\r\n1646361217 3743057300 109790942\r\n1529945214 3233300748 116416003\r\n1756152159 3852848242 100901696\r\n3958107808 1660170122 336859488\r\n3503356233 1498116123 58934114\r\n254205147 552157437 522214475\r\n3002086989 3464308835 39480501\r\n776419622 94038913 242450030\r\n2172500073 2916839785 316460963\r\n0 336488943 215668494\r\n3041567490 2232394156 461788743\r\n\r\nlight-to-temperature map:\r\n3498288578 2645051323 42074132\r\n608593503 673232568 65024140\r\n0 1287033796 108723708\r\n3979313387 3634135302 315653909\r\n2652759587 3018896130 103365881\r\n1093544955 942695289 7961217\r\n2756125468 3501628238 132507064\r\n419683046 1625547778 126722533\r\n683243352 349510049 26140330\r\n1101506172 511314709 142580382\r\n1283347805 375650379 135664330\r\n673617643 24016268 9625709\r\n709383682 1238532395 48501401\r\n3763762608 2402322728 184668443\r\n3948431051 2621479653 23571670\r\n3660408219 2687125455 102463666\r\n3561232935 2586991171 34488482\r\n2459767392 3122262011 192992195\r\n1244086554 1754618583 31645052\r\n1073753155 1497748002 19791800\r\n3972002721 3949789211 7310666\r\n3540362710 4077337854 20870225\r\n1419012135 738256708 79984976\r\n1746461061 1457945428 39802574\r\n3595721417 4190079809 64686802\r\n1616767336 653895091 19337477\r\n1275731606 823578131 7616199\r\n108723708 818241684 5336447\r\n546405579 1395757504 62187924\r\n1498997111 950656506 117770225\r\n2888632532 3957099877 102103275\r\n1744112789 1752270311 2348272\r\n2233819388 2077946837 225948004\r\n3762871885 2401432005 890723\r\n2136282224 2303894841 97537164\r\n3311914546 3315254206 186374032\r\n2118147522 4059203152 18134702\r\n308182087 831194330 111500959\r\n114060155 0 24016268\r\n2077946837 4254766611 40200685\r\n971525741 33641977 102227414\r\n1636104813 1517539802 108007976\r\n138076423 1068426731 170105664\r\n3220042816 4098208079 91871730\r\n2990735807 2789589121 229307009\r\n757885083 135869391 213640658\r\n\r\ntemperature-to-humidity map:\r\n1130946446 972737563 146373650\r\n1277320096 1760175559 41760032\r\n4151385320 4147641404 143581976\r\n2634337722 0 466605084\r\n1992884166 956487184 16250379\r\n4147641404 4291223380 3743916\r\n641064346 466605084 489882100\r\n1319080128 1801935591 673804038\r\n2009134545 2475739629 625203177\r\n0 1119111213 641064346\r\n\r\nhumidity-to-location map:\r\n3903940466 3635148971 125939893\r\n1458128760 2186815403 67353660\r\n3125319983 1458128760 728686643\r\n2261072201 3994982121 66012689\r\n3854006626 2992363154 49933840\r\n1525482420 3780550419 183145699\r\n2233668127 3967578047 27404074\r\n2442260515 3138011064 466023456\r\n740912129 0 327948845\r\n2422798960 3761088864 19461555\r\n1708628119 3963696118 3881929\r\n2327084890 3042296994 95714070\r\n4029880359 3604034520 31114451\r\n1712510048 2471205075 521158079\r\n367508399 695457244 373403730\r\n2908283971 2254169063 217036012\r\n0 327948845 367508399\r\n";
    }
}

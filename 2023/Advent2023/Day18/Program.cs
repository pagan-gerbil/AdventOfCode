using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Day18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = _input;

            var trenchList = new List<(int, int)>();

            var lines = input.Split(Environment.NewLine);

            var current = (0, 0);
            foreach(var line in lines)
            {
                var distance = int.Parse(line.Substring(1, line.IndexOf(' ', 2) - 1));

                switch (line[0])
                {
                    case 'U':
                        trenchList.AddRange(Enumerable.Range(current.Item2 - distance, distance).Select(x => (current.Item1, x)));
                        current = (current.Item1, current.Item2 - distance);
                        break;
                    case 'R':
                        trenchList.AddRange(Enumerable.Range(current.Item1, distance).Select(x => (x, current.Item2)));
                        current = (current.Item1 + distance, current.Item2);
                        break;
                    case 'D':
                        trenchList.AddRange(Enumerable.Range(current.Item2, distance).Select(x => (current.Item1, x)));
                        current = (current.Item1, current.Item2 + distance);
                        break;
                    case 'L':
                        trenchList.AddRange(Enumerable.Range(current.Item1 - distance, distance).Select(x => (x, current.Item2)));
                        current = (current.Item1 - distance, current.Item2);
                        break;
                }
            }

            Console.WriteLine(trenchList.Count);

            trenchList = trenchList.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();

            var lowestX = trenchList.Select(x => x.Item1).Min();
            var lowestY = trenchList.Select(x => x.Item2).Min();
            var highestX = trenchList.Select(x => x.Item1).Max();
            var highestY = trenchList.Select(x => x.Item2).Max();

            var count = trenchList.Count();

            for (var i = lowestX; i <= highestX; i++)
            {
                for (var j = lowestY; j <= highestY; j++)
                {
                    if (trenchList.Contains((i, j)))
                    {
                        Console.Write('O');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine(count); // 51922 is too low

        }

        private static IEnumerable<(int, int)> GetTrenchBits(string line)
        {
            var trenchList = new List<(int, int)>();
            var distance = int.Parse(line.Substring(1,line.IndexOf(' ', 2) - 1));

            var current = (0, 0);

            switch (line[0])
            {
                case 'U':
                    trenchList.AddRange(Enumerable.Range(current.Item2, distance).Select(x => (current.Item1, x)));
                    break;
                case 'R':
                    trenchList.AddRange(Enumerable.Range(current.Item1 - distance, distance).Select(x => (x, current.Item2)));
                    break;
                case 'D':
                    trenchList.AddRange(Enumerable.Range(current.Item2 - distance, distance).Select(x => (current.Item1, x)));
                    break;
                case 'L':
                    trenchList.AddRange(Enumerable.Range(current.Item1, distance).Select(x => (x, current.Item2)));
                    break;
            }

            return trenchList;
        }

        private static string _test = "R 6 (#70c710)\r\nD 5 (#0dc571)\r\nL 2 (#5713f0)\r\nD 2 (#d2c081)\r\nR 2 (#59c680)\r\nD 2 (#411b91)\r\nL 5 (#8ceee2)\r\nU 2 (#caa173)\r\nL 1 (#1b58a2)\r\nU 2 (#caa171)\r\nR 2 (#7807d2)\r\nU 3 (#a77fa3)\r\nL 2 (#015232)\r\nU 2 (#7a21e3)";
        private static string _input = "L 5 (#088ba0)\r\nU 3 (#250f31)\r\nL 9 (#61e7e0)\r\nU 3 (#250f33)\r\nL 3 (#1e8420)\r\nU 5 (#36bd43)\r\nR 6 (#32a5b2)\r\nU 7 (#383191)\r\nR 2 (#144d42)\r\nU 2 (#383193)\r\nR 6 (#4204b2)\r\nU 7 (#1a4b53)\r\nR 3 (#21b4f0)\r\nU 7 (#1afab3)\r\nR 3 (#42ab20)\r\nD 8 (#11f323)\r\nR 5 (#3c1e00)\r\nD 8 (#6e7903)\r\nR 7 (#390a00)\r\nU 6 (#0457b3)\r\nR 5 (#123502)\r\nU 8 (#148e03)\r\nR 2 (#452742)\r\nU 3 (#148e01)\r\nR 7 (#1dcbc2)\r\nU 4 (#15b8f3)\r\nR 7 (#4e9e80)\r\nD 8 (#3ed153)\r\nR 5 (#2bc4a0)\r\nD 8 (#29b6c3)\r\nR 2 (#5cdb42)\r\nD 5 (#33cac3)\r\nR 4 (#1a4f52)\r\nU 5 (#135e03)\r\nR 3 (#1d0ca0)\r\nD 5 (#396ca3)\r\nR 5 (#465630)\r\nU 3 (#1dd753)\r\nR 2 (#6362d2)\r\nU 5 (#2fd793)\r\nR 3 (#2a5610)\r\nU 7 (#0f29f3)\r\nR 8 (#66eb00)\r\nD 7 (#20d683)\r\nR 3 (#15fcf0)\r\nU 6 (#43a7d3)\r\nR 2 (#441e02)\r\nU 4 (#2f31a3)\r\nR 10 (#300850)\r\nU 2 (#39d293)\r\nR 2 (#41d100)\r\nU 6 (#320743)\r\nL 7 (#71d952)\r\nU 4 (#193043)\r\nL 3 (#441e00)\r\nU 7 (#2a7503)\r\nL 2 (#07b292)\r\nU 3 (#299211)\r\nR 7 (#64aa22)\r\nU 5 (#299213)\r\nL 10 (#108b42)\r\nU 3 (#0772c3)\r\nL 2 (#2a5612)\r\nU 3 (#0fab63)\r\nL 6 (#663a30)\r\nU 4 (#40d973)\r\nL 3 (#0d5e60)\r\nU 3 (#285103)\r\nL 9 (#451af0)\r\nU 4 (#1d4e43)\r\nL 4 (#451af2)\r\nU 8 (#39a913)\r\nR 5 (#0d5e62)\r\nU 4 (#290d13)\r\nR 4 (#113652)\r\nU 9 (#45ace3)\r\nR 3 (#5503e2)\r\nU 5 (#0c8c43)\r\nR 7 (#68f4e0)\r\nD 5 (#119833)\r\nR 9 (#0e35b0)\r\nU 4 (#56a843)\r\nR 6 (#44ca32)\r\nU 4 (#0d16f3)\r\nL 9 (#42fdb2)\r\nU 4 (#575f23)\r\nL 5 (#2ff902)\r\nU 5 (#0470b3)\r\nL 2 (#270252)\r\nD 5 (#091833)\r\nL 6 (#2ff720)\r\nU 5 (#2836c3)\r\nR 3 (#659ea2)\r\nU 6 (#2c7113)\r\nL 5 (#659ea0)\r\nU 6 (#2827b3)\r\nR 5 (#2ff722)\r\nU 7 (#1c1a43)\r\nR 3 (#2497b0)\r\nD 7 (#299d33)\r\nR 2 (#0ec8f0)\r\nD 5 (#49a851)\r\nR 3 (#37d650)\r\nD 7 (#49a853)\r\nR 8 (#404e10)\r\nU 5 (#06e5c3)\r\nR 3 (#409362)\r\nU 4 (#391103)\r\nL 7 (#2ddba0)\r\nU 3 (#0bc9e1)\r\nR 8 (#5a03e0)\r\nU 8 (#0bc9e3)\r\nL 8 (#41cce0)\r\nU 5 (#0dc663)\r\nR 7 (#1e9d10)\r\nU 3 (#438d13)\r\nR 3 (#30fd72)\r\nU 8 (#4baeb3)\r\nR 6 (#0a2600)\r\nU 10 (#01d6e3)\r\nL 5 (#430fd0)\r\nU 4 (#0a6f73)\r\nL 4 (#1b14d2)\r\nU 7 (#634bb3)\r\nR 9 (#322102)\r\nD 5 (#2a2623)\r\nR 4 (#4f02b2)\r\nD 5 (#244c11)\r\nR 3 (#30e472)\r\nD 6 (#134061)\r\nR 6 (#4d5ef0)\r\nD 5 (#22ea21)\r\nL 7 (#05c6b0)\r\nD 6 (#33b3a1)\r\nL 2 (#164612)\r\nD 4 (#2d0f61)\r\nR 6 (#3cdf92)\r\nD 8 (#2a2d41)\r\nR 6 (#3764e2)\r\nU 3 (#32fca3)\r\nR 5 (#6b2fd0)\r\nU 6 (#3c6513)\r\nR 4 (#6b2fd2)\r\nU 9 (#151243)\r\nR 3 (#218012)\r\nU 9 (#3fe151)\r\nR 2 (#12b722)\r\nU 3 (#0afd41)\r\nR 5 (#5b3f12)\r\nU 9 (#31f0c1)\r\nR 4 (#05e1c2)\r\nU 5 (#096b91)\r\nR 3 (#381280)\r\nU 6 (#1f8291)\r\nR 4 (#381282)\r\nU 3 (#279b01)\r\nR 5 (#030c92)\r\nU 7 (#417ff1)\r\nR 6 (#5b1152)\r\nU 3 (#1add53)\r\nR 3 (#0b3ee2)\r\nU 6 (#4ce103)\r\nR 6 (#0b3ee0)\r\nD 5 (#4d66d3)\r\nR 3 (#27a722)\r\nD 3 (#05ab03)\r\nR 4 (#373e50)\r\nD 5 (#6c3d33)\r\nR 4 (#373e52)\r\nD 9 (#080ec3)\r\nR 6 (#2c82e2)\r\nD 6 (#1731c3)\r\nR 7 (#0b4b60)\r\nD 8 (#22b143)\r\nR 6 (#61da00)\r\nD 7 (#407ed1)\r\nL 5 (#075b90)\r\nD 4 (#407ed3)\r\nL 3 (#5f6480)\r\nD 9 (#22b141)\r\nL 6 (#3012b0)\r\nU 5 (#0a8cb3)\r\nL 4 (#318600)\r\nU 3 (#479bf3)\r\nR 4 (#324280)\r\nU 7 (#2c86a3)\r\nL 7 (#2072a0)\r\nD 4 (#624cb3)\r\nL 9 (#0f7db0)\r\nD 6 (#21abc3)\r\nR 9 (#1325d0)\r\nD 5 (#1f8a41)\r\nL 4 (#2f6ec0)\r\nD 5 (#57a2d1)\r\nL 4 (#3b9370)\r\nU 7 (#25de21)\r\nL 4 (#0cbdd0)\r\nU 3 (#2cfa43)\r\nL 4 (#130402)\r\nD 10 (#361463)\r\nL 5 (#130400)\r\nU 5 (#39fc93)\r\nL 3 (#246bb0)\r\nD 2 (#4abf91)\r\nL 7 (#5b17e0)\r\nD 3 (#3c6ab1)\r\nL 6 (#068d42)\r\nD 5 (#148a91)\r\nL 3 (#41dfe0)\r\nU 10 (#512d51)\r\nL 2 (#262db0)\r\nU 2 (#27b471)\r\nL 4 (#036982)\r\nD 12 (#31a3d1)\r\nL 4 (#036980)\r\nD 3 (#1aee01)\r\nR 10 (#262db2)\r\nD 2 (#1409e1)\r\nR 3 (#41dfe2)\r\nD 3 (#209c71)\r\nL 4 (#068d40)\r\nD 6 (#446921)\r\nR 4 (#10b5a2)\r\nD 2 (#0d6221)\r\nR 5 (#4a6242)\r\nD 3 (#10eb81)\r\nL 4 (#1e26e0)\r\nD 3 (#23fd11)\r\nL 5 (#307170)\r\nD 5 (#716191)\r\nR 3 (#387cb0)\r\nD 8 (#04bda1)\r\nR 8 (#10e9d0)\r\nU 2 (#515da1)\r\nR 2 (#3b4450)\r\nU 9 (#4e6751)\r\nR 5 (#31af90)\r\nD 3 (#2e2951)\r\nR 4 (#6073a0)\r\nD 8 (#06e601)\r\nR 4 (#0302c0)\r\nD 4 (#335f81)\r\nR 11 (#22a740)\r\nD 5 (#3e4ca3)\r\nR 11 (#23ed32)\r\nD 3 (#5b3c03)\r\nR 6 (#23ed30)\r\nD 7 (#1d4d83)\r\nR 5 (#5ae0c0)\r\nD 5 (#3ab641)\r\nR 3 (#3c91e2)\r\nD 8 (#059f81)\r\nR 5 (#0f93c0)\r\nD 6 (#34d761)\r\nR 2 (#022170)\r\nD 6 (#371071)\r\nR 6 (#022172)\r\nD 3 (#09d461)\r\nR 3 (#0f93c2)\r\nU 10 (#0cf061)\r\nR 2 (#3c91e0)\r\nU 4 (#23bc51)\r\nR 4 (#32d760)\r\nU 8 (#3eea73)\r\nR 3 (#099c62)\r\nD 6 (#45c4f3)\r\nR 4 (#099c60)\r\nD 5 (#296c33)\r\nR 8 (#00bad0)\r\nD 8 (#3f4d53)\r\nL 8 (#357a80)\r\nD 3 (#0cc741)\r\nR 6 (#551fb0)\r\nD 9 (#0cc743)\r\nR 3 (#59a840)\r\nD 5 (#039fc1)\r\nR 7 (#1bbd50)\r\nD 6 (#24ae01)\r\nL 5 (#233910)\r\nD 7 (#300613)\r\nL 9 (#39f1b0)\r\nD 3 (#300611)\r\nL 6 (#1cd0e0)\r\nD 3 (#3666a1)\r\nL 4 (#225770)\r\nD 4 (#5eb463)\r\nL 3 (#3d91d0)\r\nU 8 (#4ab363)\r\nL 2 (#59a060)\r\nU 2 (#2950b3)\r\nL 7 (#0d05d2)\r\nU 5 (#178e73)\r\nL 6 (#380f22)\r\nD 5 (#5120f3)\r\nL 3 (#277032)\r\nD 4 (#060761)\r\nR 8 (#0e3912)\r\nD 4 (#4b1991)\r\nR 7 (#4d9402)\r\nD 5 (#178e71)\r\nR 12 (#4e61a2)\r\nD 5 (#5bb183)\r\nR 6 (#00f842)\r\nD 5 (#5fdd03)\r\nR 4 (#10c532)\r\nD 2 (#05b483)\r\nR 4 (#3795e2)\r\nD 11 (#2ed143)\r\nL 4 (#3b2da0)\r\nU 6 (#45ab83)\r\nL 7 (#588760)\r\nU 9 (#129a53)\r\nL 4 (#4066c2)\r\nD 7 (#0d9733)\r\nL 4 (#2489a2)\r\nD 8 (#0d9731)\r\nL 7 (#2ec4a2)\r\nD 6 (#1f12d3)\r\nR 4 (#1fe602)\r\nD 7 (#057393)\r\nR 2 (#3771c0)\r\nD 6 (#056461)\r\nR 4 (#05e3a0)\r\nD 2 (#5cfe23)\r\nR 3 (#4068c0)\r\nD 7 (#2b4153)\r\nR 4 (#35c120)\r\nD 6 (#2d0891)\r\nR 7 (#6e6c62)\r\nD 8 (#365941)\r\nL 9 (#6e6c60)\r\nD 6 (#24dda1)\r\nL 2 (#2d0b50)\r\nD 4 (#056463)\r\nR 4 (#277d60)\r\nD 3 (#40bc61)\r\nR 4 (#2e7130)\r\nU 6 (#40bc63)\r\nR 11 (#497400)\r\nD 6 (#0ed393)\r\nR 5 (#66d050)\r\nD 7 (#437e73)\r\nR 3 (#21fc40)\r\nU 8 (#0d7663)\r\nR 4 (#4ea030)\r\nU 5 (#3ee1b1)\r\nL 4 (#239040)\r\nU 3 (#3160d1)\r\nL 10 (#3f5060)\r\nU 7 (#248831)\r\nR 7 (#1ba900)\r\nU 4 (#109051)\r\nR 7 (#2b1820)\r\nU 4 (#345291)\r\nR 11 (#2fa5c2)\r\nD 3 (#184f81)\r\nL 6 (#2fa5c0)\r\nD 8 (#3ce4d1)\r\nL 2 (#2b1822)\r\nD 7 (#5472d1)\r\nR 8 (#22eaa0)\r\nD 5 (#0d2f21)\r\nR 8 (#351920)\r\nU 9 (#5125d1)\r\nR 5 (#08c970)\r\nD 7 (#133c21)\r\nR 3 (#484fe0)\r\nD 7 (#0113c1)\r\nR 8 (#6f62b0)\r\nD 3 (#16f621)\r\nR 3 (#2a66c0)\r\nU 5 (#105451)\r\nR 6 (#36cc80)\r\nD 5 (#6d8671)\r\nR 4 (#229ce0)\r\nD 2 (#31df41)\r\nR 6 (#5f50c0)\r\nU 9 (#386501)\r\nL 2 (#1f0b12)\r\nU 4 (#36ae41)\r\nL 10 (#1731f2)\r\nU 5 (#517921)\r\nL 9 (#40dd62)\r\nU 6 (#517923)\r\nL 7 (#25dd22)\r\nU 7 (#0914d1)\r\nR 6 (#462962)\r\nU 9 (#378011)\r\nR 2 (#1e6780)\r\nU 3 (#179711)\r\nR 5 (#63ed30)\r\nU 2 (#481f81)\r\nR 4 (#2cf690)\r\nD 7 (#4dfc31)\r\nR 4 (#37ee50)\r\nD 3 (#3e8381)\r\nR 2 (#0bacb2)\r\nD 4 (#0f4b31)\r\nR 3 (#1304c2)\r\nU 4 (#1b2bf1)\r\nR 2 (#201462)\r\nU 4 (#3e6cc3)\r\nR 6 (#48c9b2)\r\nU 10 (#3e6cc1)\r\nL 6 (#0945f2)\r\nU 9 (#2f82d1)\r\nR 5 (#25f520)\r\nD 2 (#13e573)\r\nR 4 (#532820)\r\nD 4 (#13e571)\r\nR 7 (#0c0b80)\r\nD 7 (#385b71)\r\nL 7 (#0bacb0)\r\nD 6 (#433611)\r\nR 2 (#17ac02)\r\nD 3 (#066be3)\r\nR 6 (#563452)\r\nD 4 (#492883)\r\nR 7 (#103102)\r\nU 4 (#4f9461)\r\nR 3 (#3f9812)\r\nD 3 (#4889a1)\r\nR 9 (#272882)\r\nD 4 (#315081)\r\nR 2 (#52c142)\r\nD 9 (#2d10a1)\r\nR 4 (#0346e2)\r\nD 2 (#107821)\r\nR 9 (#4efeb2)\r\nD 2 (#53bca1)\r\nR 2 (#3c0e72)\r\nD 6 (#49f991)\r\nR 5 (#112cf2)\r\nD 2 (#243621)\r\nR 8 (#6b51e2)\r\nD 9 (#341b41)\r\nL 3 (#1c3d42)\r\nD 6 (#27e271)\r\nL 6 (#267432)\r\nD 3 (#52b6c1)\r\nL 4 (#359980)\r\nD 11 (#1ebe91)\r\nL 3 (#3e14a2)\r\nU 3 (#211261)\r\nL 3 (#3452d2)\r\nU 11 (#225291)\r\nL 5 (#27c720)\r\nD 6 (#707e51)\r\nL 5 (#3c60d0)\r\nD 7 (#707e53)\r\nL 5 (#0e3f80)\r\nD 7 (#2e3e91)\r\nL 5 (#3b6e30)\r\nD 4 (#32e213)\r\nL 4 (#375b72)\r\nD 7 (#1fe7a3)\r\nL 3 (#375b70)\r\nU 5 (#3d9863)\r\nL 5 (#3cfba0)\r\nU 8 (#17f261)\r\nL 3 (#112cf0)\r\nU 5 (#0f5b11)\r\nL 3 (#4020d0)\r\nD 6 (#2e4231)\r\nL 8 (#053e90)\r\nD 2 (#4fc851)\r\nL 10 (#2ce8f2)\r\nD 5 (#1d5fa1)\r\nL 6 (#187672)\r\nD 6 (#579551)\r\nL 7 (#221cd2)\r\nU 6 (#2dd571)\r\nL 3 (#6886f2)\r\nD 6 (#321921)\r\nL 2 (#42b222)\r\nD 5 (#075a03)\r\nL 11 (#422fd2)\r\nD 5 (#595193)\r\nL 8 (#17a072)\r\nU 5 (#3c2423)\r\nL 6 (#542ef2)\r\nU 5 (#02c373)\r\nL 4 (#2a4f02)\r\nU 7 (#402271)\r\nL 2 (#0cf6b0)\r\nU 4 (#13a071)\r\nL 3 (#277b10)\r\nD 7 (#3c9e81)\r\nL 6 (#4f7880)\r\nD 8 (#0b1901)\r\nL 3 (#340292)\r\nD 3 (#076ff1)\r\nL 4 (#2118f2)\r\nD 3 (#076ff3)\r\nL 8 (#2ecec2)\r\nU 6 (#0418c1)\r\nL 5 (#368892)\r\nU 5 (#382671)\r\nL 7 (#454ec2)\r\nU 10 (#42c991)\r\nL 4 (#0e86d0)\r\nD 7 (#1d62c1)\r\nL 8 (#0e86d2)\r\nU 8 (#3751a1)\r\nL 8 (#321af2)\r\nD 8 (#64b3f3)\r\nL 5 (#3f1cf2)\r\nD 3 (#3ae963)\r\nL 4 (#3dbbc2)\r\nD 7 (#008451)\r\nR 7 (#0f9032)\r\nD 5 (#67c611)\r\nR 11 (#0f9030)\r\nU 5 (#3752f1)\r\nR 7 (#0ac792)\r\nD 8 (#3cb351)\r\nR 2 (#347a52)\r\nD 3 (#382911)\r\nR 3 (#5b34d2)\r\nD 2 (#49b0b1)\r\nR 10 (#0de010)\r\nD 3 (#1d3fc3)\r\nR 5 (#357230)\r\nD 7 (#280c73)\r\nR 5 (#6def10)\r\nU 5 (#280c71)\r\nR 5 (#235bc0)\r\nU 7 (#1d3fc1)\r\nR 9 (#5d5ca0)\r\nD 4 (#15abb1)\r\nR 3 (#5cbf60)\r\nD 10 (#41dfa1)\r\nL 2 (#232ec2)\r\nD 2 (#3511d1)\r\nL 6 (#232ec0)\r\nD 6 (#575671)\r\nL 6 (#44f6a2)\r\nD 6 (#5aa8f1)\r\nR 6 (#310932)\r\nD 6 (#10c091)\r\nL 5 (#1f8ac2)\r\nD 3 (#21fc31)\r\nL 5 (#2e3ca2)\r\nU 5 (#277bf3)\r\nL 9 (#0bfd22)\r\nU 5 (#277bf1)\r\nR 9 (#390102)\r\nU 7 (#33a471)\r\nL 5 (#041602)\r\nU 4 (#235f11)\r\nL 9 (#20fd92)\r\nD 3 (#69cb71)\r\nL 4 (#333e82)\r\nD 10 (#039d51)\r\nL 6 (#00df02)\r\nD 7 (#602a01)\r\nL 6 (#44dae2)\r\nD 4 (#342721)\r\nR 6 (#088ea2)\r\nD 4 (#2c5b91)\r\nL 6 (#2e3352)\r\nD 6 (#47d9c1)\r\nL 4 (#45d272)\r\nU 11 (#2895e3)\r\nL 2 (#1bcf12)\r\nU 3 (#2dc413)\r\nL 6 (#1bcf10)\r\nD 4 (#3c31b3)\r\nL 8 (#032bb2)\r\nU 7 (#486c23)\r\nL 2 (#032bb0)\r\nU 4 (#3d4b73)\r\nL 3 (#5b1c32)\r\nU 4 (#4ae353)\r\nL 2 (#167e12)\r\nU 8 (#13b6d3)\r\nL 4 (#719a40)\r\nD 7 (#358da3)\r\nL 2 (#5e4700)\r\nD 5 (#448473)\r\nL 4 (#2b0390)\r\nU 3 (#437863)\r\nL 9 (#3fe5a0)\r\nU 2 (#104f93)\r\nL 7 (#1ba080)\r\nU 3 (#104353)\r\nL 7 (#281e40)\r\nU 10 (#4f3f93)\r\nR 7 (#39ede2)\r\nU 6 (#6fa903)\r\nL 4 (#39ede0)\r\nU 7 (#0fb493)\r\nL 6 (#0bb5d2)\r\nU 7 (#03a6a1)\r\nL 5 (#6268d2)\r\nU 2 (#03a6a3)\r\nL 10 (#1585c2)\r\nU 6 (#1f2823)\r\nL 4 (#42ca62)\r\nU 5 (#3e7c83)\r\nL 6 (#1e1160)\r\nD 5 (#068313)\r\nL 5 (#414f22)\r\nU 4 (#4bb1f3)\r\nL 5 (#414f20)\r\nU 7 (#2ea7c3)\r\nL 2 (#1e1162)\r\nU 4 (#06a053)\r\nL 4 (#468032)\r\nU 5 (#0ab563)\r\nL 9 (#1898e0)\r\nU 3 (#124ae3)\r\nL 4 (#324bc0)\r\nD 3 (#53bac3)\r\nL 4 (#3f02b2)\r\nD 8 (#097a11)\r\nR 4 (#68a852)\r\nD 4 (#097a13)\r\nL 2 (#06d032)\r\nD 4 (#2ce463)\r\nL 3 (#5e5b10)\r\nU 3 (#479663)\r\nL 3 (#4f2c20)\r\nU 10 (#059913)\r\nL 2 (#00f400)\r\nU 6 (#095173)\r\nL 4 (#324bc2)\r\nU 4 (#294473)\r\nL 10 (#1898e2)\r\nU 2 (#064dd3)\r\nL 2 (#0a4e42)\r\nU 4 (#41d683)\r\nR 4 (#0a9762)\r\nU 2 (#075d03)\r\nR 8 (#312c42)\r\nU 5 (#29ec71)\r\nL 5 (#32d172)\r\nU 5 (#1f4711)\r\nL 8 (#313232)\r\nU 4 (#3932b1)\r\nR 5 (#1c2b02)\r\nU 9 (#473081)\r\nL 5 (#049552)\r\nU 6 (#09f6b1)\r\nL 5 (#025212)\r\nU 6 (#15d451)\r\nL 4 (#40ae22)\r\nU 7 (#6a1941)\r\nR 4 (#1b4c22)\r\nU 4 (#1411a3)\r\nL 7 (#63bc52)\r\nU 9 (#1411a1)\r\nL 8 (#0cb412)\r\nD 9 (#5ba4b1)\r\nL 4 (#35df62)\r\nU 9 (#311e33)\r\nL 4 (#206802)\r\nU 4 (#3496b3)\r\nL 4 (#678fd2)\r\nU 5 (#110833)\r\nL 5 (#4772e2)\r\nU 5 (#3aa053)\r\nL 3 (#5db2e0)\r\nU 3 (#2ce593)\r\nR 6 (#5db2e2)\r\nU 7 (#3c90c3)\r\nL 6 (#15c962)\r\nU 3 (#148ff3)\r\nL 4 (#64ab02)\r\nD 10 (#1990b3)\r\nL 2 (#1439a2)\r\nD 3 (#1cf7d3)\r\nL 4 (#1a0832)\r\nU 5 (#3e3f43)";
    }
}

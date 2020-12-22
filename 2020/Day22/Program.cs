using System;
using System.Collections.Generic;

namespace Day22
{
    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new Queue<int>();
            var player2 = new Queue<int>();

            foreach (var line in _player1Input.Split(Environment.NewLine))
                player1.Enqueue(int.Parse(line));
            foreach (var line in _player2Input.Split(Environment.NewLine))
                player2.Enqueue(int.Parse(line));

            while (player1.Count > 0 && player2.Count > 0)
            {
                var p1Play = player1.Dequeue();
                var p2Play = player2.Dequeue();

                if (p1Play > p2Play)
                {
                    player1.Enqueue(p1Play);
                    player1.Enqueue(p2Play);
                }
                else
                {
                    player2.Enqueue(p2Play);
                    player2.Enqueue(p1Play);
                }
            }

            var score = 0;

            while (player1.Count > 0 || player2.Count > 0)
            {
                if (player1.Count > 0) score += (player1.Count * player1.Dequeue());
                if (player2.Count > 0) score += (player2.Count * player2.Dequeue());
            }

            Console.WriteLine($"The winning score is {score}");
        }

        private static string _player1Example = @"9
2
6
3
1";

        private static string _player2Example = @"5
8
4
7
10";

        private static string _player1Input = @"31
24
5
33
7
12
30
22
48
14
16
26
18
45
4
42
25
20
46
21
40
38
34
17
50";

        private static string _player2Input = @"1
3
41
8
37
35
28
39
43
29
10
27
11
36
49
32
2
23
19
9
13
15
47
6
44";
    }
}

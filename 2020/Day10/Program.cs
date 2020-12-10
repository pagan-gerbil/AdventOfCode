using System;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapters = _example
                .Split(Environment.NewLine)
                .Select(x => int.Parse(x));
            var device = adapters.Max() + 3;
            
            adapters = adapters
                .Concat(new[] { device })
                .OrderBy(x => x);

            var diff1 = 0;
            var diff2 = 0;
            var diff3 = 0;

            var lastAdapter = 0;

            foreach (var adapter in adapters)
            {
                if (adapter - lastAdapter == 1)
                    diff1++;
                if (adapter - lastAdapter == 2)
                    diff2++;
                if (adapter - lastAdapter == 3)
                    diff3++;
                if (adapter - lastAdapter > 3)
                    Console.WriteLine("Something odd?");
                lastAdapter = adapter;
            }

            Console.WriteLine($"{diff1} differences of 1 jolt; {diff3} differences of 3 jolt");
            Console.WriteLine($"Answer is {diff1 * diff3}");

            var validJumps = adapters.Select(x => adapters.Count(y => y > x && y - x <= 3)).Where(x => x > 0);
            var permutations = 1;
            foreach (var jump in validJumps)
            {
                permutations *= jump;
            }

            Console.WriteLine($"There are {permutations} permutations.");
        }

        private static string _example = @"16
10
15
5
1
11
7
19
6
12
4";
        private static string _longerExample = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
        private static string _input = @"71
30
134
33
51
115
122
38
61
103
21
12
44
129
29
89
54
83
96
91
133
102
99
52
144
82
22
68
7
15
93
125
14
92
1
146
67
132
114
59
72
107
34
119
136
60
20
53
8
46
55
26
126
77
65
78
13
108
142
27
75
110
90
35
143
86
116
79
48
113
101
2
123
58
19
76
16
66
135
64
28
9
6
100
124
47
109
23
139
145
5
45
106
41";


    }
}

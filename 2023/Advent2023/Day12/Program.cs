﻿using System.Security;
using System.Text.RegularExpressions;

namespace Day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // day 12 is a picross solver

            var input = _input;

            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var total = 0;

            foreach (var line in lines)
            {
                var numbers = line.Split(' ')[1].Split(',', StringSplitOptions.TrimEntries).Select(int.Parse);
                var fields = line.Split(' ')[0].Trim();

                var str = string.Empty;
                foreach(var n in numbers)
                {
                    str += $"[#]{{{n}}}[.]+";
                }
                str = str.Remove(str.Length - 1) + "*";
                var regex = new Regex($"^[.]*{str}$");

                var expandQueue = new Queue<string>();
                expandQueue.Enqueue(fields);

                var allExpanded = new List<string>();

                while (expandQueue.Any())
                {
                    var current = expandQueue.Dequeue();
                    var i = current.IndexOf('?');
                    if (i >= 0)
                    {
                        expandQueue.Enqueue(current.Remove(i, 1).Insert(i, "."));
                        expandQueue.Enqueue(current.Remove(i, 1).Insert(i, "#"));
                    }
                    else
                    {
                        allExpanded.Add(current);
                    }
                }

                //foreach (var a in allExpanded.Where(x=>regex.IsMatch(x)).ToArray())
                //{
                //    Console.WriteLine(a);
                //}


                var matches = allExpanded.Count(regex.IsMatch);
                //Console.WriteLine($"{matches} variations");

                total += matches;
            }

            Console.WriteLine($"Total of {total} variations");
        }

        private static string _test = "???.### 1,1,3\r\n.??..??...?##. 1,1,3\r\n?#?#?#?#?#?#?#? 1,3,1,6\r\n????.#...#... 4,1,1\r\n????.######..#####. 1,6,5\r\n?###???????? 3,2,1";
        private static string _input = ".?????...? 1,1,1\r\n#????????.#?#?????? 2,1,1,5,1\r\n???##?###????? 1,2,3,4\r\n?#?????##????#?? 1,9\r\n?.?.??#?...????? 1,2,1\r\n.#.#???..??#???#?? 1,1,1,1,1,4\r\n?#??#??#..#?#???. 1,4,1,1,2\r\n??######???.??.. 7,1,1\r\n.?#???#?#?#??.?.?.#? 2,7,1,1,1\r\n.?#.???.???.#??? 2,1,1,3,4\r\n?????????#?. 2,1,3\r\n??.?.?.#??##?#?#?. 1,9\r\n?....?.?#?#???? 1,1,7\r\n?.??.????#?#??##??#. 1,9,2\r\n?.??#...#? 1,1,1\r\n?###??????#??#? 7,5\r\n??????##????# 1,7,2\r\n??????.????.. 1,2\r\n??##??#??#.. 5,2\r\n#????#?#???????#??#. 8,8\r\n???#..????###??? 2,2,3,2\r\n?##?#?#?????#?.#??? 2,3,1,1,4\r\n??#?..?#???? 3,3,1\r\n??#.?#??.?#????? 1,4,2,1\r\n???.?#????? 1,5\r\n.?#.???##??? 2,6\r\n...#.?#?##. 1,1,2\r\n????.?????? 1,2,1\r\n?#?????????# 2,2,1,2\r\n??##??????. 5,1,1\r\n???..??#???#????## 1,1,1,9\r\n??#??##??# 1,3,1\r\n??#????#??.?????##. 9,3\r\n??.?#??#??#.???#?.?? 2,2,1,1,4,1\r\n?#??#?#??#??#????. 11,1,1,1\r\n.#...??###? 1,5\r\n???#?#?#??????? 1,1,1,6,1\r\n.???#.??##?..#??# 3,4,2,1\r\n???#?.???# 1,1,1\r\n???#??###?#?#???? 1,12,1\r\n??.#?????? 2,2,2\r\n#?#??..#?# 5,1,1\r\n#?..?????##?#.???#?? 2,2,5,6\r\n????#?.??##?.??#?? 6,5,1,1\r\n.??.#?##????. 1,6\r\n#??#?####??#?.?? 1,1,8,1\r\n?#.??#?#?#??#???? 1,1,9,1\r\n.???????#?. 4,3\r\n.?.?#???#?#?#??#.? 1,10,2\r\n????#??#??#..?. 1,1,1,2,1\r\n.??#??#????.??? 7,2\r\n??#?#?????.?? 3,2,1,1\r\n???#.??#????#??# 2,3,4\r\n??.??#?.#??#??#?? 1,1,2,4,1\r\n????#.????.?#???? 5,3,1,1,1\r\n?????##??????? 1,1,9\r\n?????.???#??.? 3,6\r\n.?????##????. 5,1\r\n??????????. 3,1,2\r\n?####.??#???.? 4,5\r\n?.#??.??????.?#??#? 2,5,5\r\n?..#?????????? 1,1,5\r\n???????#.???? 4,1\r\n?.??.?????#????. 2,2,1,1,2\r\n????#..?????#.?? 3,5,1\r\n???????????#???# 7,5,1\r\n.???#..???? 1,1,2\r\n??.?.?.???#? 2,1,2\r\n??##???#?????. 3,4\r\n??.????..??###??? 1,4\r\n.??#????#?# 4,3\r\n???.????#.?#?##???# 1,1,1,1,1,8\r\n??????#?.?.??? 3,2\r\n?.???..????? 2,3\r\n?..??#??????? 1,2,1,1\r\n?.#???.?#??? 1,1,3\r\n??????#???.??????? 7,1,1,1\r\n???#?#???????#?. 4,3,2,2\r\n??###?.??#?#? 3,5\r\n?#???.??????????# 5,1,1,1,4\r\n???#.????#???.# 1,1,4,2,1\r\n???.#???#?? 2,7\r\n?#.?#?###??#?. 1,10\r\n.?..????#?#?? 1,2,2,1\r\n.??.?????# 1,3,1\r\n???#??.????#??? 6,1,3,1\r\n??#?#?#???# 3,1,3\r\n?????????????????? 3,4\r\n#????#????##?????? 13,2\r\n????#??.#?#?##?#??? 1,2,8,2\r\n.??#?##??.?#?????#?? 5,9\r\n?##..#???? 3,1\r\n?##.##???#??.##???# 2,3,4,6\r\n#?????????#? 1,1,3,2\r\n???#?????????? 2,2,1,1\r\n??#??##??#?.? 1,5,1,1\r\n?#??.??##???????.?? 1,1,9,1,1\r\n??#?##??##?.??#??? 10,1,2,1\r\n..??#..?#?.? 1,2\r\n??#?.?.????? 1,1,1,1\r\n#.?##??.?.? 1,2,1\r\n..?..??#????#..? 1,8\r\n.?#??.??????. 3,5\r\n??.????#???#????? 1,1,3,2,1\r\n??.#??..?? 1,3,2\r\n#?.#??????.?? 2,2,3,1\r\n????.???.? 3,1\r\n#???.??????# 1,2,1,2\r\n?.?.??.?#??.??? 1,1,1,1,3\r\n?.#????#.? 1,1,1\r\n.????#??.? 2,4,1\r\n???##??#?..#??#??? 5,1,4\r\n??#??##?.???#? 5,4\r\n??#??#???##????.? 3,3,6\r\n.?##??.#?..? 2,2\r\n?????#.?#?#???#??? 3,9\r\n.#.??#???? 1,3\r\n??????.??.? 5,1,1\r\n.??.???????????. 1,7\r\n??????##???#?##??.#? 2,13,2\r\n??#???????#?? 3,1,1,3\r\n?????.?#??? 2,3\r\n????.????????? 1,6\r\n#?#.??#?.#?? 1,1,2,1\r\n?#?????#?###?????# 4,7,2,1\r\n?????#???.?.? 3,1\r\n#?#?.#?##??. 3,6\r\n??#.????????? 1,1,3,1\r\n??????#????.?? 1,1,2,2\r\n??????#?.??##??? 1,3\r\n?.###???#???? 4,2,1\r\n??.????.??.#.#??#? 2,1,1,1,2,2\r\n??##.???##?##?.##?#? 3,2,5,4\r\n??.?????????#?? 1,2,5\r\n.##????????. 4,1\r\n??..?##.???? 1,2,2,1\r\n.?#?.????.#?##?... 2,2,1,3\r\n#?????.???#?#??? 1,1,1,7\r\n?#.#???.#??#???.???. 2,1,1,1,4,2\r\n??????????##???#??? 1,1,7\r\n???#?#???.##.. 3,2\r\n.??##?#.??#?. 6,1\r\n?##?.###?#?? 3,5\r\n????###?..???..? 1,6,3\r\n..#????#?#??? 1,3,2\r\n#?#????????# 4,1,4\r\n?#???????????#?? 2,3,1,3\r\n.#???#?..??#?????# 1,2,9\r\n??.?#.???. 1,1,1\r\n?#?#??.???.#? 1,2,2,1\r\n??##??#???#? 3,5\r\n?#???????. 3,1\r\n.#?????.??? 3,2\r\n.#?#?##??????#?? 1,4,6\r\n??.??.?##?.?? 1,1,3,1\r\n??##??.#.?.?# 4,1,1,2\r\n#???????#?? 1,1,4\r\n????#??.?#???? 1,4,1,3\r\n#?.?##???.? 1,3\r\n????#?????##?##???.? 8,6\r\n??.?#?.???.#??? 2,1,1,2\r\n??#??#.??.???. 2,1,3\r\n.?.?.??.?##### 1,1,5\r\n???#??.???#??#.?? 1,3,1,5,1\r\n..#????##??#?#?.? 1,10\r\n?#.????#??. 2,5\r\n#.????????#?#??#??? 1,1,7,2,1\r\n.?.?...?##?#?#?#?. 1,9\r\n???????????# 1,1,6\r\n??#???????#?..?? 9,1\r\n..?#?????? 1,3\r\n.?.???????? 2,4\r\n.??.#??.??? 2,1,1\r\n??#.????.? 1,1,1\r\n.#.??.????#???.???? 1,2,1,1,3,3\r\n??#??????.??? 5,1,2\r\n????????.??.?? 1,4,1,1\r\n???????#?? 3,3\r\n??#?????#???##. 2,1,2,2\r\n??#???????# 2,6\r\n?#?#??#??#.?.#?? 6,1,2\r\n##?##?#?.??#?? 8,1,1\r\n.?#??###?????#?? 8,3\r\n????#.#?#????? 3,6\r\n#??.????#??#.#??..?? 2,6,1,3,1\r\n??????.????? 2,1\r\n????.?????. 1,2,1\r\n???????#..#? 1,2,2,2\r\n????#??#?? 4,4\r\n???.?????##?##???? 1,14\r\n??#.???#.?#??.???? 2,2,1,1,1,1\r\n?.???#?.?. 1,5\r\n#.#?#.?##????? 1,3,5,1\r\n.?..?#???????#???#? 1,14\r\n.#?#??##??#?..??#?. 3,2,3,4\r\n.??#?#?.????.???.?# 6,1,1,1,1\r\n.?#.????.#.? 1,1,1,1\r\n?#?.??#??#?? 1,8\r\n??..?????? 1,5\r\n???.?????.? 2,4\r\n??#???.##?#?.??. 5,2,1,1\r\n??#???#?....???#?.?? 3,3,4,2\r\n?..???##..?.?. 1,5,1\r\n?#????????.?? 3,2,1\r\n?#??????.## 4,1,2\r\n.??.###.?#??. 1,3,3\r\n?.??????#?#??? 1,1,8\r\n?#.?.??????#?.???? 2,1,6,1\r\n.???????#?#???. 2,6\r\n???#????.?#??#??? 4,1,1,5\r\n??#???##???#? 7,2\r\n#??????.?? 2,2\r\n?.?#.?##???.?#?## 1,2,4\r\n.?#.??????#? 1,2,2,1\r\n#?#?#?#?##.??#?#.? 1,3,4,2,1,1\r\n???#?????#?#?? 1,6\r\n?????##?#?#?##??? 1,11\r\n#?????????##?.#??.? 1,2,1,6,2,1\r\n???#?.???????.?.. 1,3,2,2,1\r\n.??.#?????? 1,2,1\r\n??#?????#.? 6,1\r\n.????#??#??????. 12,1\r\n?.?...#??...?###??.? 2,4\r\n??.??.?##??..?? 2,1,5,1\r\n?#????.#??###? 2,1,6\r\n#.???#?.?#?#??.? 1,5,5\r\n#?#?????????#? 11,1\r\n#???#??#?#???.#..#? 12,1,1\r\n.??#?#?.????? 5,1\r\n?????.?????#????? 1,1,1,6\r\n.??#?.?????#???#??? 2,1,1,1,4\r\n?#???##????.#???? 7,1,4\r\n.?#?#??#.. 3,2\r\n..????????.#?????#.? 4,1,7,1\r\n??.????#.#??.?# 1,5,3,2\r\n?#??????.???##.? 3,3,2\r\n.#.?#???#???##??#?# 1,8,3,3\r\n??#.??#?..####?#?##? 1,1,4,4,5\r\n?#?????????#?# 5,5,1\r\n???????.?? 1,3,1\r\n???????..??.? 1,2,1,1\r\n.?##.#???? 2,2\r\n?#?.?#??#.#?? 1,5,2\r\n?.???.???##??????. 3,9\r\n?#.?????.?.???.??## 2,2,1,1,3,3\r\n???????#??.??#????. 5,2,3,3\r\n?????.???.? 4,1,1\r\n???????.?#?##?.? 1,1,5,1\r\n.??????.#??.??? 4,3,1\r\n??.?#??#?? 2,2\r\n?.#?.??#?.??#??.. 1,2,4,1,2\r\n??#?.??????? 2,1,1,1\r\n???????###????.#??. 3,9,2\r\n.#??.#??.###??#????# 3,3,7,1,1\r\n.??????.?? 2,2\r\n????#.#??#?##???? 1,1,11\r\n#???????##.? 1,1,4\r\n.?#?#???#?.???? 8,2\r\n?.??#?.#?.???..????? 1,3,2,1,5\r\n???#????#.#####?? 1,3,2,5,1\r\n??#?#?????? 6,2\r\n??.????#??#? 1,6,1\r\n#????.##?#. 2,2,4\r\n?#?#????????????? 9,1,1\r\n????##?#???? 6,4\r\n?????.?????? 5,1,1,1\r\n????????????????###. 1,8,7\r\n??.????????#??#?.?? 1,13,1\r\n????.#???.####? 2,1,5\r\n??#?#?????????#. 7,1,1\r\n??.#??##?? 1,1,5\r\n?.???#??#???#??#?# 1,1,9,1,1\r\n????#???#?#. 1,7\r\n???.???#???##.#?? 1,1,7,1\r\n??#.????#. 1,2,1\r\n.##.??#?#.? 2,4,1\r\n??#?.?.#.???? 3,1,1,2\r\n#???#??#?#?.???.? 10,1,1\r\n???..#??## 3,5\r\n.?????#??##???#. 6,2,1\r\n.???#???????????. 5,5\r\n?????#?.??? 1,2,2\r\n?#?#??..?.?#??.. 6,1,4\r\n???.?#.???? 1,2,1\r\n????.#??????##???.. 1,1,2,8\r\n.?????????.????##? 5,3,5\r\n?##???#????#?#??? 3,11\r\n?????##?.?#? 2,2,2\r\n?.????#????? 1,5,1\r\n???#.??#???.?#? 1,2,4,1,2\r\n##???#??..#?????? 3,1,1,5\r\n??????.??#.? 1,2,1,1\r\n?#????###??#?##? 2,9\r\n#.??#?.??####? 1,1,1,7\r\n?????#??.??#?????#? 5,9\r\n?#.??#.???##?? 1,3,4,1\r\n.#..??#???????.???? 1,4,1,2,1,1\r\n##?#.??###?## 2,1,7\r\n?#?#?#?.?? 3,1,2\r\n.??..???.???..#?? 1,1,1,1\r\n.?????????.?????#??? 2,3,3\r\n#.#?.???.????.???#. 1,2,1,4,1,2\r\n??????.?##?.. 4,3\r\n?.##?#??.#?###?###?# 6,9,1\r\n?.????.?.??????#??? 4,1,1,2,1\r\n.?.????.?#???. 1,5\r\n.?#????#??#.??#????? 3,4,5,1\r\n?#.#?##???#?????#? 1,9,1,1\r\n.???.??????#??#?. 2,7,2\r\n?????#??##?##?????? 2,1,9,1\r\n###?????????.?. 6,1,1,1\r\n??????????..#? 1,1,6,1\r\n????.??.?#.??.####?? 1,1,1,1,2,6\r\n?????#?#?##?#??# 1,13\r\n????#??#?????? 5,1,1,1\r\n..???##.#????#. 1,3,3,1\r\n??.?#?????? 2,5,1\r\n.??..??????#???#?? 1,2,3,3\r\n#?..?#?#??#??#?? 1,10\r\n?#??#?#?#???????? 7,5,2\r\n#?.??#??????.#.#? 1,3,2,1,2\r\n??#.???#.???????? 3,4,5\r\n..????..?##...? 2,3\r\n.??.??...? 2,1,1\r\n##...??#?.????## 2,4,5\r\n###.??#??#?#?.?# 3,8,1\r\n.??#??????#?#..??. 1,4,1,1,1,1\r\n????????#??##??? 2,1,1,6,1\r\n???.##?.??#. 3,3,1,1\r\n????????#????##??#?# 9,1,3,1,1\r\n??.??#??## 1,3,2\r\n????#?#??#?.???. 1,1,5,1,1\r\n??#???#.???? 2,1,1,1\r\n?????#???#??#??#?#.? 1,1,1,8,1\r\n??.?????.?.#??.?? 2,1\r\n??..?#???# 1,3,1\r\n.?##??????????? 7,1\r\n??????.??????.#.? 1,2,2,1,1\r\n.??????.??? 4,1\r\n?#????#.?.??? 2,1,1,3\r\n#.??#??#.##????. 1,3,2,2,3\r\n??.#?#?.?.??#?????. 1,1,1,1,1,4\r\n????#?????????#?.?? 1,3,7,1\r\n????????.?? 4,2,2\r\n.????????? 2,1\r\n#???#?#?.?????????? 1,5,2,1,3\r\n.?#??#??##?#. 2,7\r\n??#?.????#??###?.?? 1,5,4,2\r\n??.???.?##?? 1,3,4\r\n?.?????.???? 1,5,2\r\n??????#??? 3,1,1\r\n#..?#????????##? 1,12\r\n#???#?.??? 3,1,1\r\n????#?.?.????????? 1,1,2,1,4,3\r\n#?????#??#??.??????? 1,8,1,1,4\r\n..?#??##?? 1,3\r\n.#???.?##?##????? 1,10\r\n??#??#?..??#??.??#? 7,5,2\r\n??..??..#??? 1,1,1,1\r\n???.????##?#.? 2,7\r\n.?##???????.?#?.?.?# 2,3,3,1\r\n.?.??#??????#?#??? 1,1,1,3,6\r\n#?.???#?????#.#???. 2,4,2,2,1\r\n?#?#???.?#????#?? 4,6\r\n????.?????#?????#?? 1,2,2,9\r\n??.??#?#.???#??.?##? 1,5,2,1,2\r\n????#.?.???#??..? 1,6\r\n??.?.?###?#???.????? 1,1,6,1,2,1\r\n??#.###.#???. 3,3,1,2\r\n????#?..#?#???? 1,1,1,2,1\r\n.??#??#????????##?# 1,1,5,1,6\r\n#??##.??#???#?? 5,8\r\n???????#??? 3,4\r\n.??.#.??.??.???? 1,1,1,2,1\r\n??#??.?#?.?? 4,1,2\r\n.???????.???#?????.? 3,6\r\n???#????#????#??#??. 3,14\r\n????????..?????.? 3,1,2\r\n?????#?#?.#??? 1,4,1\r\n#???.??##.???? 4,2,1\r\n?.?#????#? 2,3\r\n?.?.???##???. 1,7\r\n...#####?.??##? 6,3\r\n?#???#?????? 1,3,2,1\r\n???.##?###? 1,7\r\n#?#???#????? 7,2\r\n.??#???.?#???.???# 5,3,4\r\n?#?#??#??#.?#???.#?? 1,5,1,2,1,1\r\n??????##??##??#??. 4,8,1,1\r\n??#????..??##???#??? 4,1,9\r\n?.??#?.?.? 2,1\r\n?#????#?.?? 7,2\r\n???????##?????? 4,4,2\r\n??##?.?#???.#?.????? 1,3,3,1,1,5\r\n.?.?????#????? 1,1,3,1\r\n?????.??#?????###? 5,1,2,1,3\r\n???#??.#??????.?. 1,4,1,5\r\n??#????????#.? 2,1,4\r\n?.??????#..? 3,3\r\n?????##..#.? 2,2,1\r\n.#?..????#####???#. 1,13\r\n.??.?????#?#?.#? 1,1,6,1\r\n??????????#??. 6,2\r\n???.?..??? 3,1,1\r\n??#???????#?????? 3,6,2\r\n?.???.????.??#? 1,2\r\n????.???????????? 2,8\r\n.#.??????. 1,5\r\n?????.???. 2,1,2\r\n??.??#???#..?###???. 1,5,1,6\r\n#????#.??##?.??# 3,1,3,3\r\n???#???.#?.?.?????.? 6,2,1,3,1,1\r\n.###.???.? 3,1\r\n???????..??#? 6,2\r\n????#??????#? 5,2,2\r\n????????.??#?? 2,3,1\r\n#?#.???.??? 3,1,2\r\n?###?###???.?? 8,2\r\n?#??.#..#?.?#???. 1,1,2,3\r\n?????.?#????? 5,1,1\r\n.?#??????.?.?.?? 3,1\r\n.#??##??.???#?#.. 7,3\r\n???#?.?????? 2,4\r\n???#.???.. 3,1\r\n?.???#??#.????# 1,1,1,1,2\r\n??????##.??#????#?? 7,1,2,5\r\n?????.?.?? 1,1,1\r\n#??#?????.????. 1,3,3,2,1\r\n?.???##????.??#?#.. 5,2,3,1\r\n?#.#?????? 1,1,1\r\n??????#?##?#?.?#?. 1,1,1,2,1,3\r\n??#????.##? 3,2\r\n??.?.#.??#? 2,1,1\r\n?????##?.?#??? 3,3,1,1\r\n???#.?#???? 2,3\r\n???????..?#??#??#??? 3,2,6,1,1\r\n.??#?#??.????#??#??# 7,1,7\r\n???#.?#?.# 2,2,1\r\n??.?##?#.??# 5,2\r\n?.????#?#.? 4,1\r\n????.???#.? 1,3\r\n?#????#??#???#? 1,1,2,2,3\r\n.?????#??#??#??. 1,10\r\n?#?#??#?????#?#?#??? 13,1,1,1\r\n?#??.?#?#.???? 1,1,3,1\r\n???#.???#?? 1,1,5\r\n#???????##???? 1,1,7\r\n?#.?????###? 1,1,6\r\n?..??.????# 1,3,1\r\n?.#??.????#? 3,1,3\r\n?.#?#??#??????? 1,1,4,1,2\r\n.???????..#.??????#. 4,1,1,1,2,1\r\n???#..?#..?.??##?# 1,1,2,1,5\r\n??????????.#. 1,1,3,1\r\n????..????????????# 1,1,1,3,1,2\r\n.#.??#???? 1,1,1\r\n??????????????????? 4,1,4,1,1\r\n??????????#??#?????? 4,8,1\r\n.???#?.??? 2,1,2\r\n???.???#???.?.??#? 2,6,4\r\n?.?.??????#?#?#? 8,2\r\n??#?.????? 1,4\r\n??#???#??????#???. 2,5,2,1\r\n?#???.#??? 2,2\r\n#??.##?####??#? 1,11\r\n#????##??.????.?##.? 4,4,1,1,3,1\r\n???...?#??#??? 2,6\r\n???????????? 1,1,3\r\n?#.????#??.#..?? 1,1,4,1,1\r\n.?.?????##??##???? 1,1,12\r\n????????..??## 1,5,3\r\n?????#?#..#??? 7,1,1\r\n.?##???.#?#.??#? 2,1,3,1\r\n.??##??#????#.???..? 8,2,1\r\n?#????.??.##???? 3,1,3\r\n#??#????#????? 5,4,1\r\n##?#?????#? 4,2\r\n???#??#??.. 2,3\r\n?#????#????.#.###? 2,5,1,3\r\n?.?????#?#??.????#?? 1,4,2,5,1\r\n#????#??.??? 2,2,1,1\r\n.?????#??.????.? 4,3,1,1,1\r\n?#..?#??.# 2,1,1\r\n#?.??#??.?##?? 1,4,5\r\n??????##??.? 1,1,4\r\n???..#?.????.? 1,2,2\r\n???#?.#?.?#??#..#? 5,2,3,1,2\r\n?.#?#????#?????????? 10,1\r\n??????#??.? 3,3\r\n????#?#??#??###?? 5,7\r\n?????.?.?.#?.? 3,1,1\r\n?????#?#####?# 3,9\r\n?#??.?..??. 3,1,1\r\n?#?????#?#??#.??? 4,6,3\r\n?????#?.??. 1,4,1\r\n????#?###???..? 10,1\r\n.???#??#?.??#?# 1,1,1,3,1\r\n#????#??#.? 1,6,1\r\n#????#?.#?#?.#.?? 3,1,4,1,2\r\n#.?.?.?#.??.???#? 1,1,2,1,5\r\n??????..?????#??.?. 1,1,1,4,1,1\r\n????..?..?????# 1,1,1,1,2\r\n??.#???.?#? 1,3,1\r\n????.??#?. 1,2\r\n?#??#??????.??? 8,1\r\n??????###??#.??.?? 1,6,2,1,1\r\n????..##??#?#??????? 2,11\r\n?.???##??????. 2,7\r\n.#??#?.?????? 2,1,4,1\r\n?.?#??#??##?#???#??# 1,8,8\r\n#????.#?????#??????? 1,1,1,7,1,1\r\n?...?#?.????##?? 1,1,7\r\n..???.???????#? 2,6\r\n#?#???#?????????? 5,5,1,2\r\n??.??????? 1,1,1\r\n..?.???.??? 1,2\r\n#.????.?#????###???? 1,2,2,7\r\n??.?..??????#???? 1,1,2,6\r\n.?#????##.#.??#???? 8,1,5\r\n#??##?.?#???# 6,3,1\r\n???#?????????????? 9,1,1,1\r\n?#????.???#??# 3,1,3,2\r\n????.??????????.? 1,1,2,1,3\r\n?..?#?????..?#?.??# 1,2,2,1,3,2\r\n??#???#?#??#??#??? 4,3,6\r\n.????#.???????? 2,1,1,1,1\r\n.??????.#?#.# 4,1,3,1\r\n.?#?#?#??#?????#? 1,6,1,1\r\n???.????#.????? 2,4,1\r\n.?.??#???? 1,1\r\n?.?#????#?##?#?? 3,7\r\n..???##??#.#.???? 7,1,1,1\r\n?.???#??????###??.#? 1,1,1,4,3,1\r\n????#???.???..# 2,1,1,1,1\r\n??????.?.#???. 4,2\r\n.??#??.?##.#??? 5,2,1,1\r\n?.?.???##?????#???.? 1,1,11,1\r\n??##??#?????.?????? 10,3\r\n.???#.??????????# 1,1,5,3\r\n??.#??##???##??##?? 10,3\r\n?#.???#??.? 1,5,1\r\n??????.?...??#??#?.. 3,7\r\n?.???????????. 2,1,2\r\n??????????..?###??. 5,3\r\n??????#?.?? 1,5\r\n.?##..#??? 3,2\r\n??#?..???#??? 3,1,2,1\r\n????????.#??## 1,1,2,2\r\n#??????#?..# 1,3,1,1\r\n??.#?.?????# 1,1,1,1\r\n???#?????.?. 5,1,1,1\r\n?????????#? 2,7\r\n?##?.##????? 3,2,1,2\r\n?#.????.?###? 2,2,4\r\n?.#?.?#???? 2,1,2\r\n??#???.???.??. 2,1,3,1\r\n.?#?#????? 1,1,2\r\n.???.???#?###?? 2,7\r\n?#?#??????????# 6,1,1,1,1\r\n??????.???? 1,2,1\r\n..??.?#???#.??#??#?. 2,5,2,3\r\n?????#?.???##??#?? 2,2,6,1\r\n???..??.??...#?#..?. 2,3\r\n#?.?#??#?? 1,2,2\r\n?????????.??#???.??# 2,5,1,1,1,2\r\n#????##?#?#?.?? 2,3,1,2,1\r\n#????????????#??? 1,2,11\r\n?????????..? 1,5,1\r\n???????..?????.#???? 1,4,1,1,3,1\r\n???.????????????#? 1,1,1,1,2,5\r\n??.????###?#? 1,8\r\n.?##???.??????# 5,4,1\r\n.????????.??.???? 2,2\r\n?#?#.????#??? 3,6\r\n???#??.#??#.?#?.?? 1,3,1,1,1,1\r\n??..?.??#? 1,1,1\r\n???..????#.?#? 1,1,3,1\r\n???#?????????.? 1,2,1,1,1\r\n?????.###?#?.???? 1,6\r\n??##???#####.??.?.? 11,1,1,1\r\n????.#?#??..??. 3,1,3,1\r\n???#????????????? 2,1,2,5,1\r\n?#????.?.#??? 1,1,1,4\r\n#?????#???#?#. 1,1,2,3\r\n????#????#??#???? 1,12,1\r\n..#.?#.??#?.?.#.??? 1,1,3,1,1,3\r\n???????##?# 1,2,4\r\n????????#????? 4,4\r\n#??...?#?.#.???? 1,1,2,1,4\r\n?#?.???.###?.#???? 3,1,3,2,1\r\n?#???????? 2,1,1\r\n.#???#?????###? 1,4,3\r\n???#?.??.?????#?. 4,6\r\n????##??#??#?##?. 1,3,1,4\r\n?.???#?##??#?? 6,1\r\n?????????.??????#?# 1,1,5,1,1,4\r\n??????#??##???.?# 1,10,1\r\n.?#...??.??.???? 1,1,1,4\r\n#?#.#?##?..#??#? 1,1,4,1,2\r\n.#??.????##?..?? 1,1,1,3,1\r\n??????#??#?? 7,1,1\r\n??##?#??.#?#. 5,3\r\n?...????.##??# 1,2,5\r\n.#?.???..? 1,1,1\r\n???.?..????#???. 3,5\r\n???????#???#??#??#?? 1,9,1\r\n??#?##???.#??.#.???? 4,1,1,1,1,3\r\n.?????..????##?? 1,7\r\n??????###??##?#????? 1,2,14\r\n???#???.#???.??? 1,4,2\r\n??.?#??????????? 1,11,1\r\n??.?.????..???##??.? 1,1,5\r\n#??????#??.??????. 2,5,1,3,1\r\n??#?.?.???#?##? 2,1,6\r\n.????..????? 2,2\r\n????##???..?##?..? 1,4,3\r\n..????.?.??????????? 1,2,1,6,3\r\n#??#?###??#????#. 4,6,3\r\n#?##?#???.????##???. 9,9\r\n.#?????.?..? 1,1,1,1\r\n???##??#??###?##?? 8,8\r\n??.????#??.?#..# 2,7,1,1\r\n??????#??????????#? 2,4,10\r\n??##?#?????##??.#?? 11,1,2\r\n??..?.#?#?? 1,1,5\r\n????###?#??.?#??.?. 6,4\r\n??.##????#?..? 1,2,5,1\r\n??????#??##??????. 8,2\r\n????##???.##??#???? 6,5,1\r\n???????##?.?..?????. 6,3\r\n#????##..?? 3,2,1\r\n??#??##??#?..? 1,5,2,1\r\n???#???.???#??? 1,3,5\r\n.??#.#???.?#?.#?.?? 3,4,3,2,1\r\n.???##...????? 5,1\r\n?#??.??#?.#???##.#?. 1,1,1,6,2\r\n.?#??#??#?#?##??# 4,9\r\n???#????.???.??#.?? 8,2,3,1\r\n.??#.?.?##.. 2,3\r\n????##?#?.? 1,5,1\r\n?.?.??????###? 1,2,7\r\n?#????????????? 3,1,4,2\r\n..#??#????????? 4,1\r\n???.?.??????#??#?? 1,1,2,1,5,1\r\n.???#??#?#????????#? 11,3\r\n.???#??.#??.? 3,2,1\r\n????#????#???#?# 1,4,1,3,1\r\n?####?#????.??##??? 10,1,5\r\n#???.??.?#. 1,1,2\r\n??####?????#? 7,1\r\n????????##?.#???.? 2,6,4\r\n?#????##.?????? 3,1,2,1,1\r\n??#?#??????.#? 6,1,1\r\n?????????.#.# 7,1,1\r\n??????????????? 6,5\r\n.?.?.##??? 1,3\r\n.##?.#??.???#? 3,1,5\r\n???#???#???????? 4,1,2,1\r\n..???????? 1,1\r\n???????????? 7,1\r\n..????.???????? 3,1,3\r\n???.???????#???##?? 1,2,1,2,4\r\n.?###?.???? 4,1,1\r\n?.?#?#??#?###???#??? 2,12,1\r\n????#??.?.?????.?? 2,1,1\r\n?????#???????#???? 1,6,4\r\n?.???.?#???? 2,4\r\n??###..????##???##?? 5,9\r\n??????????. 1,3,1\r\n#??????###?? 5,4\r\n#?#..?#??#?##??? 1,1,3,7\r\n??#?.?###?????##?. 3,5,4\r\n??#???????##.?##? 10,2\r\n#.??###?#? 1,5\r\n?...##??##?##??. 1,9\r\n.??#???#.???????? 6,2,1\r\n#??#?#??.#??#?##??. 8,9\r\n?..?.#???????#?? 1,1,3,4\r\n??.?#??#?.?.#??? 5,4\r\n?..???????#??##???? 1,1,5,3,2\r\n.?#?????.. 2,1\r\n???###..??? 4,1\r\n????#??????###???#?? 1,2,1,1,9\r\n??#????.????.#??#??? 5,3,4\r\n?#???#..?.??????.# 2,1,1,2,2,1\r\n??...??##?#???#?? 1,9\r\n???.#??.????#? 3,2\r\n?????...???.#???. 2,1,1,1\r\n???#???##???#??..?## 1,1,4,4,2\r\n??????#??..??. 2,2,1\r\n?????##?????????# 1,6,1,3\r\n.#.#.?#???.? 1,1,4\r\n?????.???.???? 1,1,3\r\n???.??#??.????#??? 1,3,1,8\r\n??##???????.?##??? 3,1,2,4\r\n???#???????.?#. 9,1\r\n????#.??????. 3,1,4\r\n.????.#?##??#. 1,1,7\r\n?.???????? 1,1,2\r\n.????#.?##?#?#???. 5,8,1\r\n?#??.??.?#?? 3,2,2\r\n?????????? 2,1,1\r\n#.??????##??????## 1,2,3,5\r\n?#??.?#?#?? 1,5\r\n.##???#?#?????#??? 8,1,4,1\r\n??.?????.??#?????# 2,5,4,2\r\n?..?.??.??#? 2,4\r\n???..??.???##? 1,1,6\r\n#??#?..???.???.#??. 5,1,1,2,1,1\r\n?????#?#??#?# 3,4\r\n#???.?..??##?# 1,1,1,6\r\n.#????.???#??? 5,1,3\r\n#.???#???? 1,1,4\r\n.?????..?????#? 2,1,1,1,1\r\n.#???#??.?#?. 1,3,2\r\n????.????#??? 1,2,4\r\n?##?#???###??..?##? 5,6,3\r\n??????#??#???. 1,1,1,5\r\n#???????????. 5,2\r\n#.??.????????.??? 1,2,7,1,1\r\n??#.??.?????###? 1,1,2,5\r\n.#?.?..#???????? 1,4\r\n?###?##.?? 4,2,1\r\n.????.?#?##.? 1,4\r\n?.##?.?..?? 2,1,1\r\n?#?.?#.???? 1,2,1\r\n.???##????????. 6,4,1\r\n.##???????##???#??#? 2,1,9\r\n#???????## 2,4\r\n#????#.#.?#? 6,1,2\r\n??#?#??#?? 3,2\r\n##.??.??.?.#?? 2,1,1,1\r\n?#????????#?##?#??#? 2,1,1,1,7\r\n?????#????????. 1,7,1,1\r\n??.???#???#?#? 5,4\r\n.????.#?####?#????? 1,1,11\r\n???.??.?????#????.?? 1,1,8,1,2\r\n??????.?.#?#????# 3,1,8\r\n#?.??????..# 2,2,1,1\r\n???#?????? 2,2\r\n?????#??.????##? 7,5\r\n.???????#??? 1,8\r\n?.???????.??? 5,1\r\n.????##???#???????? 1,5,3,3\r\n.?#???###?#???#? 1,8,2\r\n?##??#????#???#?.?? 3,5,2,1,1\r\n??#?#.???? 1,3,1\r\n?????????????? 1,3,2,4\r\n??#??.?????#??#? 3,9\r\n#.#????##?..? 1,2,5\r\n?#????#??????? 1,1,7,1\r\n.??#??#????###??? 8,3\r\n?.???#??#?? 1,3\r\n?#??.???#?????????? 4,6,4\r\n?.?.?#.?#???#??????# 1,1,2,8,1\r\n??#???????? 1,4\r\n.#????????. 3,1,1\r\n.#?#?#????????? 1,1,1,6,1\r\n???#???#?????? 3,1,1,2\r\n?.#??#???????#????.? 1,1,5,5,1\r\n.#????#.????# 4,1,1,1\r\n#.?.#?#?.??#?#?#? 1,1,4,7\r\n.?????.???. 1,2\r\n??.???#????#?#..??? 2,2,2,5,2\r\n.????.????##?? 2,6\r\n??#?.??####??. 3,5\r\n?#?#?????#?????# 7,4,1\r\n??.#????#?? 1,4,1\r\n?????##???#??.? 5,1,3,1\r\n????????.#??? 3,2,1,1\r\n???.???#?. 1,1,1\r\n#?.#?.?##. 2,1,3\r\n???#??.???#. 4,2\r\n?#?#????#.??#..????. 9,1,1,1,1\r\n?#??.??#??#? 2,1,3,2\r\n?##???#??????##.?.? 2,11\r\n????#?.?????. 5,4\r\n???#?.?????#???? 3,3,4\r\n????####??.??#????? 8,5\r\n???#??#??? 1,3,3\r\n???#?#????#??#??..# 14,1\r\n???..?.???? 1,2\r\n#...??????.?#??.? 1,5,3\r\n???#?#??????.??##?? 3,1,5,1,2,1\r\n?##??.?.?#? 3,1,1\r\n##?????#?#??????#.? 8,1,4\r\n.##???##??#?###??.?? 4,11,2\r\n###.???????.???? 3,1,2\r\n?...??????????#???? 1,5,3\r\n????.?.#??##???.? 4,1,2,1,1\r\n#??.?#?.#???. 2,3,3\r\n?#??#?#?..???????? 1,4,1,1,1,1\r\n.????.?#?#.?????.?# 3,3,1,1,2\r\n##?.???.#????#?#???? 2,2,1,1,8\r\n.?????##????#?.#.? 8,2,1\r\n?#??###???#??????#? 12,1\r\n.?..??.??????#??.#?. 1,7,2\r\n?#????#?...?#?? 1,3,1\r\n??????????????? 3,1,3\r\n??????.????##? 1,2,6\r\n.???.?##???? 1,3,1\r\n?####?.#????.#? 5,3,1\r\n?.#?#????????..# 1,3,4,2,1\r\n#?.?.????#?? 2,1,2,3\r\n??#???????#???##?# 10,5\r\n.???#?????.? 1,6\r\n?.#?.???##?????????? 1,2,6,7\r\n???????#?#??#? 1,1,1,7\r\n?#??#?#??..##???.. 8,4\r\n????????.#? 2,1,1\r\n#.#??..?.#???? 1,3,3,1\r\n#???.??#???? 2,1,4,1\r\n????.????? 3,1,3\r\n?????.##???.??? 1,2,2,1,1\r\n??#??.#?????#?? 3,2,3\r\n.??#???.??###??? 1,1,6\r\n?????.???.? 1,2\r\n?.?#?????#???. 8,1\r\n.???????#?#??????# 1,6,3\r\n????##?#????.. 1,4,2\r\n?.??.?.?????? 1,1,5\r\n?????.###.? 4,3,1\r\n???..??#.##? 1,3,2\r\n#.#??#??.?????#.?? 1,4,1,1,1,1\r\n.#?????.?##???.?# 2,3,4,1,1\r\n???#????.??????.??.? 4,1,1,1,2\r\n...???.?.#. 2,1\r\n???#?.##.???.????? 3,2,2,1,1\r\n??????#??.##???????. 4,9\r\n#?#????????? 5,4\r\n.#????##???.?? 1,7,2\r\n???#.?.?#. 1,1,1\r\n???#?##.??#??#??.##. 6,6,2\r\n???????#?#?#?###?#. 1,11\r\n????#.#??.? 2,1\r\n?.#??.?????#??????? 3,2,8\r\n?#.???????? 2,4,1\r\n??.?#??#??? 2,7\r\n.?????????#? 3,4,2\r\n?.???.???#.? 3,3\r\n.#?#??##??? 4,3\r\n?.?????????? 3,3\r\n?????.?.#????????? 1,1,1,1,5,1\r\n?#?.???????#?#???#? 2,3,3,2\r\n.?#?#?????.????..? 8,3\r\n.?#?#.?..???? 3,4\r\n?.?????.?.##.??.? 5,1,2,1\r\n??????#???.? 3,4,1\r\n#?.????.?####?? 2,1,1,4\r\n????#?????????#? 2,3,6\r\n?.#??#????##?????#? 1,2,1,2,4\r\n??..????##???? 2,8\r\n?##?####??# 8,1\r\n?.?#####?????#.?. 6,3\r\n###??#..##??.??#?. 6,3,2\r\n?????#??.???#? 2,4\r\n?.??????#?#?#?? 1,6\r\n????#?????? 5,1,1\r\n#??#?#.#?????#.???? 1,2,1,3,1,3\r\n??#?????##???.. 3,6\r\n???#??#?????? 4,2,1\r\n?.??###.??? 4,1\r\n???.???????.??? 3,3,2,1\r\n????????#?????#?.?? 4,2,1,1,1,1\r\n????.???????#?? 1,1,1,4\r\n##??....##??? 4,3\r\n.?#???#?????.?#???. 8,1,2,2\r\n?.?##?????.. 1,5,1\r\n##???#????? 2,4,2\r\n??.?.????##?????. 1,10\r\n?##???###??.?????#. 10,1,1\r\n???????#???? 3,1\r\n?.??..???#.? 1,1,2,1\r\n#????#.... 2,1\r\n?#?.?????? 3,1,2\r\n??.#?.??#?.. 1,1,4\r\n?.??.#???????#?? 1,7\r\n???#??#??#??#?? 4,2,2,3\r\n???..#?##? 1,4\r\n.???#??..??. 4,2\r\n?#?.????#???#? 2,1,2,2\r\n???????#.???#?#?. 4,1,2,1,1\r\n?????.??#??? 2,5\r\n??????.?####?? 3,6\r\n???##??????? 9,1\r\n????##?#?.??.#??.??? 1,7,1,1,1,1\r\n#????###??##?.?.?? 2,8,1\r\n???.??..?. 1,1,1\r\n.?#??#????#?#?#? 1,11\r\n?.???#.???????? 1,2,6\r\n?????##?.??#??## 8,3,2\r\n?.?????????? 4,3\r\n???.???#?##???????? 2,1,6,3\r\n..??????##?#????? 8,2,1\r\n.?.#??#???##..#??#? 1,9,2,1\r\n?.?#.??#?# 1,1,5\r\n.#.??#?#?#? 1,5\r\n.#??????.?# 1,2,2\r\n.?????????.???.# 1,4,1,3,1\r\n#?????##?#?????????? 1,1,8,1,1,2\r\n?##?#???.???????##? 7,10\r\n#.?.##.?#? 1,2,1\r\n?##??..???#? 4,2\r\n??#?#????# 6,2\r\n#?.##?#??? 1,6\r\n???#.?#???###.????# 2,1,7,5\r\n??????#?##??.? 3,7\r\n?#?#??#??????.. 3,1,1,2\r\n.??#??#?.?.??????? 1,5,1,3,1,1\r\n#??.#??.#??#??????? 3,3,1,5,2\r\n.##??????????????? 3,2,2,5\r\n??##??.#?####.. 4,6\r\n?.???###?.#..?? 6,1,1\r\n???????????? 1,1,7\r\n???#?#?#??????##??? 9,3,1\r\n??????.???. 5,3\r\n.????#??????##??? 6,8\r\n..?#??#???#?#?.??## 5,4,2\r\n?????#???###?.#?.??? 1,9,2,2\r\n#?.??#?#?? 2,3,1\r\n#?#???.???##? 3,3\r\n#????#???????.??#? 12,1,1\r\n#???.?????###?#? 1,2,2,5\r\n#?.?????#?##???##?? 1,1,11\r\n??#??#????#?# 1,1,1,6\r\n..#??.??#???? 3,1,1\r\n???##??????#?##?. 6,4\r\n.???????.#.??#?????? 4,1,1,8\r\n..??.????#?.?# 1,2,2,1\r\n.????#??.?#?.??##??. 5,1,1,4\r\n?#.??????? 2,1,2\r\n????#?##??#????? 9,2\r\n?????????#. 2,1,1\r\n?.?#????##????#? 1,9,1,1\r\n..?#??#??.???? 6,2\r\n?##??????.??????# 6,2,1,1\r\n????#??#??#?#?.. 5,7\r\n?#?#???.?###???????# 5,7,1,2\r\n??#?#??#???? 1,1,2,1\r\n?.?.?#???### 1,1,2,3\r\n?????.???????#?.??.? 2,1,9,2,1\r\n.??##???#.?.????#? 6,1,2,1\r\n??.?????????.??.. 2,4,1\r\n??#???#?##?? 4,5\r\n???#??####?.????? 10,1\r\n??????#????#??#? 1,10,1\r\n##?.????????# 2,3,1,3\r\n?#??.?.??###?.#?## 1,1,1,1,3,4\r\n???#?????##? 1,2,1,3\r\n?#???.?.##???.?????. 4,1,3,5\r\n#..?..?.?##?#?? 1,1,6\r\n?.??.?????..? 2,2\r\n???#??.?#??#? 5,2,3\r\n##??????#??? 3,3\r\n??#.?.??.#????#?#? 3,1,2,5\r\n?.?????????#???????? 10,2\r\n???.?#.?????????#. 2,1,10\r\n???#??##??????# 9,1,2\r\n??##?#?????###.? 8,3\r\n?##????.?.???#??. 2,2,1,4,1\r\n.?#?###???????????? 7,1,1,2\r\n#????#???#?#?.????# 1,1,5,2,1,1\r\n.??????.???????. 6,1,1,1,1\r\n??????.??#. 1,1,3\r\n??.??##??.? 1,2\r\n??????#???.?.??. 1,5,1,1\r\n???##.??#??? 4,1\r\n..???#??#? 4,2\r\n#????.#?.?????#???? 5,1,1,1,2,1\r\n?.??#???.#?.????. 4,2\r\n?.#.#?.?.??#??? 1,2,1,1,3\r\n?.???###??##?..???. 7,2,1,1\r\n?##?.????????? 2,3,3\r\n???????????????##??? 1,1,5,1,3,1\r\n?#.?????#????#??#??? 1,2,1,7,2\r\n###?.???#?#????????? 4,7,5\r\n.??#?????. 1,1,1\r\n..###??#??? 3,3\r\n???#???#?.#?.#??# 5,2,2,4\r\n??.???#.???????.. 4,3\r\n?#???.?????? 1,1\r\n??..??????? 1,3,1\r\n??#???????.??.?#? 7,1,2,2\r\n?????????.???#?. 3,1,1,3\r\n.????#.???##?? 5,6\r\n??????.??? 1,2,2\r\n?????????? 2,1,3\r\n?????.??#?? 2,4\r\n?.?.??#??????.? 1,4,3\r\n?#?#???????????# 12,1\r\n#?.?#????? 1,7\r\n????#?#?#????# 1,6,1,1\r\n...?#??????????##?# 8,4\r\n??????#??? 3,4\r\n??.????????????? 1,1,2,1,2\r\n?#??#?#??#.?#???? 7,2,3\r\n????..???#??#??. 1,2,1,6\r\n?????.??#?????.??. 1,5\r\n?#.????????? 1,1,1,3\r\n??##?.#?#??? 3,5\r\n";
    }
}

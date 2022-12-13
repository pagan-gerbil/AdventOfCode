using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day12
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle1();
            if (puzzlePart == 2) Puzzle2();
        }

        private static void Puzzle1()
        {
            var rawInput = _input;
            var grid = rawInput.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

            var rowCount = grid.Length;
            var colCount = grid.First().Length;

            var process = rawInput.Replace(Environment.NewLine, string.Empty);

            var currentIndex = process.IndexOf('E');
            var targetIndex = process.IndexOf('S');

            process = process.Replace('S', 'a').Replace('E', 'z');

            var thisPath = new List<int>();

            var deadEndPaths = new Dictionary<int, List<int[]>>();

            thisPath.Add(currentIndex);
            while (currentIndex != targetIndex)
            {
                var possibleSteps = GetPossibleSteps(colCount, process, currentIndex, targetIndex, thisPath, deadEndPaths);//, map);

                if (!possibleSteps.Any())
                {
                    if (deadEndPaths.ContainsKey(currentIndex) && deadEndPaths[currentIndex].Any(x => x.SequenceEqual(thisPath.AsEnumerable().Reverse())))
                    {
                        Console.WriteLine("DUPLICATE DEAD END REACHED");
                        break;
                    }
                    if (!deadEndPaths.ContainsKey(currentIndex))
                    {
                        deadEndPaths.Add(currentIndex, new List<int[]>());
                    }
                    deadEndPaths[currentIndex].Add(thisPath.AsEnumerable().Reverse().ToArray());

                    Console.WriteLine($"Dead-end reached: {currentIndex}\t  length: {thisPath.Count}\t  endpoint: [ {process[currentIndex]} ]");
                    while (GetPossibleSteps(colCount, process, thisPath.Last(), targetIndex, thisPath, deadEndPaths).Count() < 1)
                    {
                        var badIndex = currentIndex;
                        thisPath.Remove(badIndex);
                        currentIndex = thisPath.Last();
                    }
                    continue;
                }

                currentIndex = possibleSteps.First();

                thisPath.Add(currentIndex);
            }

            Console.WriteLine($"Number of steps taken: {thisPath.Count - 1}");
        }

        private static IEnumerable<int> GetPossibleSteps(int colCount, string process, int currentIndex, int targetIndex, List<int> thisPath, Dictionary<int,List<int[]>> deadEndPaths)
        {
            var possibleSteps = GetAllSteps(process, colCount, currentIndex).ToArray();

            var result = possibleSteps
                .Where(x => Math.Abs(process[x] - process[currentIndex]) <= 1 && !thisPath.Contains(x)) // not too high or low; not visited before
                .Where(x => process[x] - process[currentIndex] <= 0) // head down
                .Where(x => !deadEndPaths.ContainsKey(x))// || !deadEndPaths[x].Any(y => y.SequenceEqual(thisPath.AsEnumerable().Union(new[] { x }).Reverse()))) // not visiting a dead end
                .OrderBy(x => deadEndPaths.ContainsKey(x) ? deadEndPaths[x].Count : 0).ThenByDescending(x => process[x]).ThenBy(x => Math.Abs(targetIndex - x))
                .ToArray();

            if (result.Length > 0) return result;

            return possibleSteps
                .Where(x => Math.Abs(process[x] - process[currentIndex]) <= 1 && !thisPath.Contains(x)) // not too high or low; not visited before
                .Where(x => process[x] - process[currentIndex] <= 0) // head down
                .Where(x => !deadEndPaths.ContainsKey(x) || !deadEndPaths[x].Any(y => y.SequenceEqual(thisPath.AsEnumerable().Union(new[] { x }).Reverse()))) // not visiting a dead end
                .OrderBy(x => deadEndPaths.ContainsKey(x) ? deadEndPaths[x].Count : 0).ThenByDescending(x => process[x]).ThenBy(x => Math.Abs(targetIndex - x))
                .ToArray(); ;
        }

        private static IEnumerable<int> GetAllSteps(string process, int colCount, int currentIndex)
        {
            if (currentIndex % colCount > 0)
            {
                yield return currentIndex - 1;
            }

            if ((currentIndex + 1) % colCount > 0)
            {
                yield return currentIndex + 1;
            }

            if (currentIndex >= colCount)
            {
                yield return currentIndex - colCount;
            }

            if (currentIndex + colCount < process.Length)
            {
                yield return currentIndex + colCount;
            }
        }

        private static void Puzzle2()
        {
        }

        private static string _testInput = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

        private static string _input = @"abccccaaacaccccaaaaacccccccaaccccccccaaaaaaccccccaaaaaccccccccccaaaaaaaaacccccccaaaaaaaaaaaaaaccaaaaaccccccccccccaccacccccccccccccccccccccccccccccccccccccccaaaaaa
abccaacaaaaaccaaaaacccccaaaaaccccccccaaaaaaccccccaaaaaacccccccccaaaaaaaaaaaaacccaaaaaaaaaaaaaaaaaaaaaccccccccccccaaaacccccccccccccccccccccccccccccccccccccccaaaaaa
abccaaaaaaaaccaaaaaacccccaaaaaccccccaaaaaaaacccccaaaaaaccccccccccaaaaaaaaaaaacccaaaaaacaaaaaacaaaaaaaaccccccccccaaaaacccccaccccccccccccccccccaaacccccccccccccaaaaa
abcccaaaaaccccccaaaacccccaaaaacccccaaaaaaaaaaccccaaaaaacccccccccaaaaaaaaaaaaaacaaaaaaaaaaaaaacaaaaaaaaccccccccccaaaaaacccaaacccccccccccccccccaaaccccccccccccccaaaa
abaaacaaaaacccccacccccccaaaaaccccccaaaaaaaaaaccccccaaaccccccccccaaaaaaaaacaaaaaaaaaaaaaaaaaaacccaaacaccaaaccccccaaaaaaaacaaacccccccccccaaccccaaacccccccccccccccaac
abaaacaacaaaaccccccccccccccaaccccccacaaaaacccccaacccccccccccccccaaaacaaaaaaaaaacccaacccaaacaacccaaccccaaaaccccccccaacaaaaaaaaaaccccccccaaaaccaaaccccccccccccccaaac
abaaccaaccaaacacccccccccccccccccccccccaaaacccaaaaaaccaaaccccccccccaacaaaaaaaaaacccaaccccccccccccccccccaaaaccccccccccccaaaaaaaaaccccccciiiiiaaaaacccccccccccccccccc
abaaccccaaaaaaaacccccccccccccccccccccccaaccccaaaaaaccaaaaaccccacccaaccaaacaaaaacccccccccccccccaacccccccaaaccccccccccccccaaaaacccccccciiiiiiiiaaaaaccccccaaaccccccc
abaaacccaaaaaaaacccccccccccccccccccccccccccccaaaaaacaaaaaccccaaaaaaaccaaccaaacccccccaaaaacacccaaccccccccccaacccccccccccaaaaaaccccccciiiiiiiiijjaaaaaccccaaacaccccc
abaaaccccaaaaaaccccccccccccccccccccaaccccccccaaaaaccaaaaacccccaaaaaaaaccccccccccccccaaaaaaaaaaaaccccccccccaaacaaccccccaaaaaaaccccccciiinnnnoijjjjjjjjjjaaaaaaacccc
abccccccccaaaaacccccaacccccccccccaaaacccccccccaaaacccaaaaaccccaaaaaaaaacccccccccccccaaaaaaaaaaaaaaccccccccaaaaaacccaacaaacaaacccccchhinnnnnoojjjjjjjjjkkaaaaaacccc
abcccccccaaaaaacaaacaacccccccccccaaaaaaccccccccccccccaacccccccaaaaaaaaacaaccccccccccaaaaaaaaaaaaaaacccccaaaaaaacccaaaaccccccacaaccchhinnnnnoooojjjjjjkkkkaaaaccccc
abaacccaccaaaccccaaaaaccccccccccccaaaaccccccccccccccccccccccccaaaaaaaacaaaaaaaccccccaaaaaaaaaaaaaaacccccaaaaaaacccaaaaccccaaacaaachhhnnntttuooooooooppkkkaaaaccccc
abaacccaaaaaaaccccaaaaaacccccccccaaaaaccccccccccccccccccccccccaaaaaaacccaaaaacccccccccaaacaaaaaaaaccccccccaaaaacccaaaacccccaaaaacchhhnnnttttuooooooppppkkkaaaccccc
abaacccaaaaaaccccaaaaaaacccccccccaacaaccccccccccccccccccccccaaaccaaaccaaaaaaacccccccccccccaaaaaaaccccccaacaacaaacccccccccccaaaaaahhhhnntttttuuouuuuupppkkkcccccccc
abaaaacaaaaaaaaaaaaaaacccccccccccccccccccccccccccccccccccccaaaacccaaacaaaaaaaaccccccccccccaccaaaccccccaaacaaccccccccccccccaaaaaahhhhnnntttxxxuuuuuuupppkkkcccccccc
abaaaacaaaaaaaaaaacaaacccaaacccccccccccccccccccccacccccccccaaaacccccccaaaaaaaaccccccccccccccccaaacccccaaacaaacccccccccccccaaaaaahhhhmnnttxxxxuuyuuuuuppkkkcccccccc
abaaaccaaaaaaaaccccaaaccccaaaccacccccccccccaaaaaaaaccccccccaaaacccccccccaaacaacccccccccccccccccccccaaaaaaaaaacccccacccccccaacaghhhmmmmtttxxxxxxyyyuupppkkccccccccc
abaaccaaaaaaaccccccccccccaaaaaaaacccccccccccaaaaaaccccccccccccccccccccccaaccccccaacccccccccccccccccaaaaaaaaacccccaaccccccccccagggmmmmttttxxxxxyyyyvvppkkkccccccccc
abaacccaccaaacccccccccccaaaaaaaaccccccccccccaaaaaaccccccccccccccccccccccccccaaacaaaccccccccccccccccccaaaaaccccaaaaacaacccccccgggmmmmttttxxxxxyyyyvvpppiiiccccccccc
SbaaaaaccccaaccccccccccaaaaaaaaacacccccccccaaaaaaaacccccccccccccccaacccccccccaaaaaccccccccccaaaacccccaaaaaacccaaaaaaaaccaaaccgggmmmsssxxxEzzzzyyvvvpppiiiccccccccc
abaaaaaccccccccccccccccaaaaaaaaaaaaaaaaaccaaaaaaaaaacccccccccccaaaaacccccccccaaaaaaaccccccccaaaaaccccaaaaaaaccccaaaaacccaaaaagggmmmsssxxxxxyyyyyyvvqqqiiiccccccccc
abaaaaacccccccccccccccccaaaaaaaacaaaaaacccaaaaaaaaaaccccccccccccaaaaacccccccaaaaaaaacccccccaaaaaaccccaaacaaacccaaaaacccaaaaaagggmmmssswwwwwyyyyyyyvvqqqiiicccccccc
abaaaaccccccccccccccccccccaaaaaaaaaaaaacccacacaaacccccccccccccccaaaaacccccccaaaaaaaacccccccaaaaaaccccacccccccccaacaaaccaaaaaagggmmmsssswwwwyyyyyyyvvvqqiiicccccccc
abaaaaacccccccccccccccccccaacccaaaaaaaaaccccccaaaccccccccccccccaaaaaccccccccaacaaacccccccccaaaaaacccccccccccccccccaaccccaaaaagggmmmmssssswwyywwvvvvvvqqiiicccccccc
abaaaaaccccccccccccccccccaaacccaaaaaaaaaacccccaaaccccccaacccccccccaaccaaccccccaaaacaccccaacccaacccccccccccccccccccccccccaaaaccggglllllssswwwywwwvvvvqqqiiicccccccc
abaccccccccccccccccccccccccccccaaaaaaaaaaccccaaaacccaaaacccccccccccccaaaccccccaaaaaaaaaaaacccccccccccccccccccccccccccccccccccccffffllllsswwwwwwrrqvqqqqiiicccccccc
abccccccccccccccccccccccccccccccccaaacacaccccaaaacccaaaaaacccccccccaaaaaaaaccccaaaaaaaaaaaacccccccccccccccccccccccccccccccccccccfffflllssrwwwwrrrqqqqqqjjicccccccc
abcccccccaaaccccccccaaccccccccccccaaacccccccccaaaccccaaaaacccccccccaaaaaaaaccaaaaaaacaaaaaaacccccccccccccccccccccccccccccccccccccfffflllrrwwwrrrrqqqqjjjjjcccccccc
abaaaccaaaaacccccccaaacaaccccccccccaacccccccccccccccaaaaacccccccccccaaaaaacccaaaaaaaaaaaaaaaccccccccccccccccccccccccccccccccccccccffffllrrrrrrrkjjjjjjjjjcccaccccc
abaaaccaaaaaacccccccaaaaacaacaaccccccccccccccccccccccccaacccccccccccaaaaaacccaaaaaaaaaaaaacccccccccccccccccccccccccccccccccccccccccfffllrrrrrrkkjjjjjjjcccccaccccc
abaaaccaaaaaacccccaaaaaaccaaaaacccccccccccccccccccccccccccccccccccccaaaaaacccccaaacaaaaaaacccccccccccccccccccccccccccccccccccccccccfffllkkrrrkkkjjddcccccccaaacccc
abaaaccaaaaaccccccaaaaaaaacaaaaaccccccccccccccccccccccccccccccccccccaaacaacccccaaaccccccaaaaccccaaaccccccccccccccccaaaccccccccccccccfeekkkkkkkkkdddddccccaaaaacccc
abaaacccaaaaccccccaacaaaaaaaaaaaccccccccccccccccccccccccccccccccccccccaacaacccccccccccccccaaccccaaaacccccccccccccccaaaacccccccccccccceeekkkkkkdddddddcccaaacaccccc
abaccccccccccccccccccaacccaaaaccccccccccccccccccccccccccccaaccaaccaacccaaaaccccccccccccaaaaaaaacaaaacccccccccccccccaaaacccaaaaacccccceeeekkkkdddddaaccccaacccccccc
abccccccccccccccccccaaccccccaaccccccccccccaaacccccccccccccaaaaaaccaaaacaaaaacccccccccccaaaaaaaacaaaccccccccccccccccaaaacccaaaaaccccccceeeeeeedddcacacccccccccccccc
abccccccccccccccccccccccccccccccccccccccccaaaacaacccccccccaaaaacccaaaaaaaaaaccccccccccccaaaaaacccccccccccccccccccccccccccaaaaaacccccccaeeeeeeddcccccccccccccccaaac
abccccccccccccccccccccccccccccccccccccccccaaaaaaacccccccccaaaaaaccaaaaaaaacaccccccaaacaaaaaaaacccccccccccccccccccccccccccaaaaaacccccccccceeeeaaccccccccccccccccaaa
abcccccccccccccccccccccccccccccccccccccccccaaaaaaccccccccaaaaaaaaccaaaaaaaccccccccaaaaaaaaaaaacccccccccccccccccccccccccccaaaaaacccccccccccccaaaccccccccccccccccaaa
abccccccccccccccccccccccccccccccccccccccaaaaaaaaccccaaaccaaaaaaaacaaaaaaaaaacccccccaaaaaaaccaacccccccccccccccccccccccccccccaacccccccccccccccaaaccccccccccccccaaaaa
abccccccccccccccccccccccccccccccccccccccaaaaaaaaacccaaaaccccaaccaaaaaaaaaaaaaccccaaaaaaaaaacccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaaa";
    }
}

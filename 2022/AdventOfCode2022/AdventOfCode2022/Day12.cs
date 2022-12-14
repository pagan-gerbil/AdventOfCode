using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            // credit to https://www.koderdojo.com/blog/breadth-first-search-and-shortest-path-in-csharp-and-net-core for assisting with the search function

            var colCount = _input.IndexOf(Environment.NewLine);
            var map = _input.Replace(Environment.NewLine, string.Empty);

            var graph = new Graph<int>();
            for (var i = 0; i < map.Length; i++) graph.AddVertex(i);

            var startIndex = map.IndexOf('S');
            var endIndex = map.IndexOf('E');

            map = map.Replace('S', 'a').Replace('E', 'z');

            for (var i = 0; i < map.Length; i++)
            {
                graph.AddVertex(i);

                var c = map[i];

                if (i % colCount != 0 && map[i - 1] <= c + 1) graph.AddEdge(new (i, i - 1));
                if ((i - 1) % colCount != 0 && i + 1 < map.Length && map[i + 1] <= c + 1) graph.AddEdge(new (i, i + 1));
                if (i >= colCount && map[i - colCount] <= c + 1) graph.AddEdge(new (i, i - colCount));
                if (i + colCount < map.Length && map[i + colCount] <= c + 1) graph.AddEdge(new (i, i + colCount));
            }

            var path = new List<int>();

            var algorithms = new Algorithms();

            var f = algorithms.ShortestPathFunction(graph, startIndex, (start, finish) => map[start] + 1 >= map[finish]);
            var output = f(endIndex);

            Console.WriteLine(string.Join(", ", output));
            Console.WriteLine($"The shortest path is {output.Count()}");

            DrawMap(map, output, colCount);
        }

        private static void DrawMap(string map, IEnumerable<int> output, int colCount)
        {
            for(var i = 0; i < map.Length; i++)
            {
                if (i > 0 && i % colCount == 0) Console.Write(Environment.NewLine);
                if (output.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write(map[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public class Graph<T> where T : notnull
        {
            public Graph() { }
            public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
            {
                foreach (var vertex in vertices) AddVertex(vertex);

                foreach (var edge in edges) AddEdge(edge);
            }

            public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

            public void AddVertex(T vertex)
            {
                AdjacencyList[vertex] = new HashSet<T>();
            }

            public void AddEdge(Tuple<T, T> edge)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }

        public class Algorithms
        {
            public HashSet<T> BFS<T>(Graph<T> graph, T start, Action<T> preVisit = null) where T : notnull
            {
                var visited = new HashSet<T>();

                if (!graph.AdjacencyList.ContainsKey(start))
                    return visited;

                var queue = new Queue<T>();
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    var vertex = queue.Dequeue();

                    if (visited.Contains(vertex))
                        continue;

                    if (preVisit != null)
                        preVisit(vertex);

                    visited.Add(vertex);

                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor))
                            queue.Enqueue(neighbor);
                }

                return visited;
            }

            public Func<T, IEnumerable<T>> ShortestPathFunction<T>(Graph<T> graph, T start, Func<T, T, bool> isValidFunc = null) where T : notnull
            {
                var previous = new Dictionary<T, T>();

                var queue = new Queue<T>();
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    var vertex = queue.Dequeue();
                    foreach (var neighbor in graph.AdjacencyList[vertex])
                    {
                        if (previous.ContainsKey(neighbor))
                            continue;

                        if (isValidFunc != null && isValidFunc(vertex, neighbor))
                        {
                            previous[neighbor] = vertex;
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                Func<T, IEnumerable<T>> shortestPath = v => {
                    var path = new List<T> { };

                    var current = v;
                    while (!current.Equals(start))
                    {
                        path.Add(current);
                        current = previous[current];
                    };

                    path.Add(start);
                    path.Reverse();

                    return path;
                };

                return shortestPath;
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

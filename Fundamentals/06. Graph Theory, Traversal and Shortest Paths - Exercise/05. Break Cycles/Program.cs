namespace _05._Break_Cycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static SortedDictionary<string, List<string>> graph = new SortedDictionary<string, List<string>>();
        private static HashSet<Tuple<string, string>> edges = new HashSet<Tuple<string, string>>();

        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            FillGraph();

            RemoveCycles();
        }

        private static void RemoveCycles()
        {
            List<Tuple<string, string>> removedEdges = new List<Tuple<string, string>>();

            foreach (var edge in edges)
            {
                while (graph[edge.Item1].Contains(edge.Item2))
                {
                    graph[edge.Item1].Remove(edge.Item2);
                    graph[edge.Item2].Remove(edge.Item1);
                    visited = new HashSet<string>();

                    bool isCyclic = IsCyclic(edge.Item1, edge.Item2);

                    if (!isCyclic)
                    {
                        graph[edge.Item1].Add(edge.Item2);
                        graph[edge.Item2].Add(edge.Item1);
                        break;
                    }

                    removedEdges.Add(edge);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.Item1} - {edge.Item2}");
            }
        }

        private static bool IsCyclic(string node, string endNode)
        {
            if (node == endNode) return true;

            if (visited.Contains(node)) return false;

            visited.Add(node);

            foreach (var destination in graph[node])
            {
                if (IsCyclic(destination, endNode))
                {
                    return true;
                }
            }

            return false;
        }

        private static void FillGraph()
        {
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()!.Split("->", StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToArray();

                string source = input[0];

                var targets = input.Length > 1
                    ? input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).OrderBy(d => d).ToList()
                    : new List<string>();

                graph.Add(source, targets);
            }

            foreach (var sourceDes in graph)
            {
                foreach (var destination in sourceDes.Value)
                {
                    var edge = new Tuple<string, string>(sourceDes.Key, destination);
                    var reversedEdge = new Tuple<string, string>(destination, sourceDes.Key);

                    if (edges.Contains(reversedEdge))
                    {
                        continue;
                    }

                    edges.Add(edge);
                }
            }
        }
    }
}
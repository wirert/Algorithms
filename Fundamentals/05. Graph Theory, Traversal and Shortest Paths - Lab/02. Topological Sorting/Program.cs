namespace _02._Topological_Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static Dictionary<string, int> parentsCount = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            FillGraph(n);

            PrintSortedTopological();
        }

        private static void PrintSortedTopological()
        {
            var sorted = new List<string>();
            bool hasLoop = false;

            while (parentsCount.Count > 0)
            {
                var node = parentsCount.FirstOrDefault(kvp => kvp.Value == 0);

                if (node.Key == null)
                {
                    hasLoop = true;
                    break;
                }

                sorted.Add(node.Key);

                parentsCount.Remove(node.Key);

                foreach (var child in graph[node.Key])
                {
                    parentsCount[child]--;
                }
            }

            string result = hasLoop
                ? "Invalid topological sorting"
                : $"Topological sorting: {string.Join(", ", sorted)}";

            Console.WriteLine(result);
        }

        private static void FillGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()!
                    .Split(" ->", StringSplitOptions.RemoveEmptyEntries);

                string node = line[0];
                var children = line.Length > 1
                    ? new List<string>(line[1].Trim().Split(", ", StringSplitOptions.RemoveEmptyEntries))
                    : new List<string>();

                graph.Add(node, children);

                if (!parentsCount.ContainsKey(node))
                {
                    parentsCount.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!parentsCount.ContainsKey(child))
                    {
                        parentsCount.Add(child, 0);
                    }

                    parentsCount[child]++;
                }
            }
        }
    }
}

namespace _03._Cycles_in_Graph
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static Dictionary<string, int> parentCount = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            FillGraph();

            Console.WriteLine($"Acyclic: {IsAcyclic()}");
        }

        private static void FillGraph()
        {
            var line = Console.ReadLine()!.Split("-");
            while (line[0] != "End")
            {
                var node = line[0];
                var child = line[1];

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<string>();
                }
                graph[node].Add(child);

                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<string>());
                }

                if (!parentCount.ContainsKey(node))
                {
                    parentCount.Add(node, 0);
                }

                if (!parentCount.ContainsKey(child))
                {
                    parentCount.Add(child, 0);
                }
                parentCount[child]++;

                line = Console.ReadLine()!.Split("-");
            }
        }

        private static string IsAcyclic()
        {
            while (parentCount.Count > 0)
            {
                var node = parentCount.FirstOrDefault(kvp => kvp.Value == 0);

                if (node.Key == null)
                {
                    return "No";
                }

                foreach (var child in graph[node.Key])
                {
                    parentCount[child]--;
                }

                parentCount.Remove(node.Key);
            }

            return "Yes";
        }
    }
}

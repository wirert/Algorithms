namespace _01._Connected_Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            graph = new List<int>[n];
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    var edges = line.Split(' ').Select(int.Parse).ToList();
                    graph[i] = edges;
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                var graphComponent = new List<int>();

                DFS(i, graphComponent);

                if (graphComponent.Count > 0)
                {
                    Console.WriteLine($"Connected component: {string.Join(" ", graphComponent)}");
                }
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {                
                DFS(child, component);
            }

            component.Add(node);
        }
    }
}

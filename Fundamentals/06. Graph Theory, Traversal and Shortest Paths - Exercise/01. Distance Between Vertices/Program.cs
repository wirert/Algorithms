namespace _01._Distance_Between_Vertices
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine()!);
            int distancePairsCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < nodesCount; i++)
            {
                var line = Console.ReadLine()!.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(line[0]);
                var children = line.Length == 1
                    ? new List<int>()
                    : line[1].Split().Select(int.Parse).ToList();

                graph.Add(node, children);
            }

            for (int i = 0; i < distancePairsCount; i++)
            {
                var line = Console.ReadLine()!.Split("-").Select(int.Parse).ToArray();
                var startNode = line[0];
                var endNode = line[1];
                var visited = new HashSet<int>();
                var parent = new Dictionary<int, int>();

                int distance = FindDistance(startNode, endNode, visited, parent);

                Console.WriteLine($"{{{startNode}, {endNode}}} -> {distance}");
            }
        }

        private static int FindDistance(int startNode, int endNode, HashSet<int> visited, Dictionary<int, int> parent)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == endNode)
                {
                    return GetPathDistance(node, parent);
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        parent[child] = node;
                    }
                }
            }

            return -1;
        }

        private static int GetPathDistance(int node, Dictionary<int, int> parent)
        {
            int count = 0;

            while (parent.ContainsKey(node))
            {
                node = parent[node];
                count++;
            }

            return count;
        }
    }
}

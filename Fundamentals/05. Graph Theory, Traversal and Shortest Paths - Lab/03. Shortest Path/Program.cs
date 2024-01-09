namespace _03._Shortest_Path
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static bool[,] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine()!);
            graph = new bool[nodeCount + 1, nodeCount + 1];
            visited = new bool[nodeCount + 1];
            parent = new int[visited.Length];

            int edgesCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

                graph[edge[1], edge[0]] = true;
                graph[edge[0], edge[1]] = true;
            }

            int startNode = int.Parse(Console.ReadLine()!);
            int endNode = int.Parse(Console.ReadLine()!);

            FindAndPrintPath(startNode, endNode);
        }

        private static void FindAndPrintPath(int startNode, int endNode)
        {
            var queue = new Queue<int>();
            visited[startNode] = true;
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == endNode)
                {
                    PrintPath(node);
                    return;
                }

                for (int i = 1; i < graph.GetLength(1); i++)
                {
                    if (graph[node, i] && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                        parent[i] = node;
                    }
                }
            }
        }

        private static void PrintPath(int node)
        {
            var resultPath = new Stack<int>();
            resultPath.Push(node);

            while (parent[node] != 0)
            {
                node = parent[node];
                resultPath.Push(node);
            }

            Console.WriteLine($"Shortest path length is: {resultPath.Count - 1}");
            Console.WriteLine(string.Join(" ", resultPath));
        }
    }
}

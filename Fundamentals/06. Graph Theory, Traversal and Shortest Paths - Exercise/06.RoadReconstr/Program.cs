namespace _06.RoadReconstr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        class Street
        {
            public Street(int first, int second)
            {
                First = first;
                Second = second;
            }

            public int First { get; set; }

            public int Second { get; set; }
        }

        private static List<int>[] graph;
        private static HashSet<int> visited;
        private static List<Street> streets;

        static void Main(string[] args)
        {
            FillGraph();

            List<Street> importantStrets = FindImportantStreets();

            Console.WriteLine("Important streets:");

            foreach (var street in importantStrets)
            {
                var first = Math.Min(street.First, street.Second);
                var second = Math.Max(street.First, street.Second);

                Console.WriteLine($"{first} {second}");
            }
        }

        private static void FillGraph()
        {
            int n = int.Parse(Console.ReadLine()!);

            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            int streetsCount = int.Parse(Console.ReadLine()!);

            streets = new List<Street>(streetsCount);

            for (int i = 0; i < streetsCount; i++)
            {
                var input = Console.ReadLine()!.Split(" - ").Select(int.Parse).ToArray();

                int first = input[0];
                int second = input[1];

                graph[first].Add(second);
                graph[second].Add(first);

                streets.Add(new Street(first, second));
            }
        }

        private static List<Street> FindImportantStreets()
        {
            var importantStrets = new List<Street>();

            foreach (var street in streets)
            {
                visited = new HashSet<int>();

                graph[street.First].Remove(street.Second);
                graph[street.Second].Remove(street.First);

                if (!IsAlternativeRoad(street.First, street.Second))
                {
                    importantStrets.Add(street);
                }

                graph[street.First].Add(street.Second);
                graph[street.Second].Add(street.First);
            }

            return importantStrets;
        }

        private static bool IsAlternativeRoad(int node, int endNode)
        {
            if (node == endNode)
            {
                return true;
            }

            if (visited.Contains(node))
            {
                return false;
            }

            visited.Add(node);

            foreach (var destination in graph[node])
            {
                if (IsAlternativeRoad(destination, endNode))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

namespace _04._Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                string line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            int totalSalaries = 0;

            for (int node = 0; node < n; node++)
            {
                totalSalaries += FindSalary(node);
            }

            Console.WriteLine(totalSalaries);
        }

        private static int FindSalary(int node)
        {
            if (graph[node].Count == 0)
            {
                return 1;
            }

            var salary = 0;

            foreach (var child in graph[node])
            {
                salary += FindSalary(child);
            }

            return salary;
        }
    }
}

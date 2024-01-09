namespace _02._Areas_in_Matrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;


        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine()!);
            int colCount = int.Parse(Console.ReadLine()!);
            matrix = new char[rowCount, colCount];
            visited = new bool[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                string rowStr = Console.ReadLine()!;

                for (int col = 0; col < colCount; col++)
                {
                    matrix[row, col] = rowStr[col];
                }
            }

            int areaCount = 0;
            var areas = new SortedDictionary<char, int>();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }
                    var letter = matrix[row, col];
                    FindArea(row, col, letter);

                    areaCount++;
                    if (!areas.ContainsKey(letter))
                    {
                        areas.Add(letter, 0);
                    }

                    areas[letter]++;
                }
            }

            Console.WriteLine($"Areas: {areaCount}");

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void FindArea(int row, int col, char letter)
        {
            if (row < 0 || row >= matrix.GetLength(0)
                || col < 0 || col >= matrix.GetLength(1)
                || visited[row, col]
                || matrix[row, col] != letter)
            {
                return;
            }

            visited[row, col] = true;

            FindArea(row, col + 1, letter);
            FindArea(row, col - 1, letter);
            FindArea(row - 1, col, letter);
            FindArea(row + 1, col, letter);
        }
    }
}

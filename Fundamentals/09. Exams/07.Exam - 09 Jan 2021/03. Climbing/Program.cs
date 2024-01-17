namespace _03._Climbing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static int[,] matrix;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine()!);
            int cols = int.Parse(Console.ReadLine()!);

            matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowNums = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = rowNums[c];
                }
            }

            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int c = 1; c < rows; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    dp[r, c] = matrix[r, c] + Math.Max(dp[r - 1, c], dp[r, c - 1]);
                }
            }

            var path = new List<int>();

            int row = rows - 1;
            int col = cols - 1;

            while (row > 0 && col > 0)
            {
                path.Add(matrix[row, col]);

                if (dp[row - 1, col] >= dp[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            while (row > 0)
            {
                path.Add(matrix[row, col]);
                row--;
            }
            while (col > 0)
            {
                path.Add(matrix[row, col]);
                col--;
            }

            path.Add(matrix[0, 0]);

            Console.WriteLine(dp[rows - 1, cols - 1]);
            Console.WriteLine(string.Join(" ", path));
        }
    }
}

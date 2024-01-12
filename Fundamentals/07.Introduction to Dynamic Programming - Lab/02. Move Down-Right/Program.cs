namespace _02._Move_Down_Right
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int[,] matrix;
        private static int[,] dp;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine()!);
            int cols = int.Parse(Console.ReadLine()!);

            matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colEls = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colEls[c];
                }
            }

            dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int i = 1; i < cols; i++)
            {
                dp[0, i] = dp[0, i - 1] + matrix[0, i];
            }

            for (int i = 1; i < rows; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + matrix[i, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    dp[r, c] = matrix[r, c] + Math.Max(dp[r - 1, c], dp[r, c - 1]);
                }
            }

            var path = FindPathWithHighestSum();

            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<string> FindPathWithHighestSum()
        {
            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;
            var path = new Stack<string>();

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                if (dp[row, col - 1] >= dp[row - 1, col])
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row--;
            }

            while (col > 0)
            {
                path.Push($"[{row}, {col}]");
                col--;
            }

            path.Push("[0, 0]");

            return path;
        }
    }
}

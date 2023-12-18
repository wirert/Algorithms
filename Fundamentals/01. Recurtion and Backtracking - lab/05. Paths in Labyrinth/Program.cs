namespace _05._Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static char[,] labyrinth;

        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine()!);
            int colCount = int.Parse(Console.ReadLine()!);

            labyrinth = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < colCount; j++)
                {
                    labyrinth[i, j] = row[j];
                }

                Console.WriteLine();
            }

            PrintPathsInLabyrinth(new Stack<string>(), 0, 0, string.Empty);
        }

        private static void PrintPathsInLabyrinth(Stack<string> path, int row, int col, string direction)
        {
            if (!IsValidCell(row, col))
            {
                return;
            }

            if (labyrinth[row, col] == '*' || labyrinth[row, col] == 'v')
            {
                return;
            }

            path.Push(direction);

            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", path.Reverse()).Trim());
                path.Pop();
                return;
            }

            labyrinth[row, col] = 'v';

            PrintPathsInLabyrinth(path, row, col + 1, "R");
            PrintPathsInLabyrinth(path, row + 1, col, "D");
            PrintPathsInLabyrinth(path, row, col - 1, "L");
            PrintPathsInLabyrinth(path, row - 1, col, "U");

            path.Pop();
            labyrinth[row, col] = '-';
        }

        private static bool IsValidCell(int row, int col)
        => row >= 0 && col >= 0 && row < labyrinth.GetLength(0) && col < labyrinth.GetLength(1);
    }
}

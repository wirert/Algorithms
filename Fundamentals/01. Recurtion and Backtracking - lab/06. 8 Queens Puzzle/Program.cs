namespace _06._8_Queens_Puzzle
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static bool[,] board = new bool[8, 8];

        private static HashSet<int> rows = new HashSet<int>();
        private static HashSet<int> cols = new HashSet<int>();
        private static HashSet<int> leftDiagonals = new HashSet<int>();
        private static HashSet<int> rightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            FindAndPrintQueensPositions(0);
        }

        private static void FindAndPrintQueensPositions(int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard();
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if(IsAttacked(row, col))
                {
                    continue;
                }

                board[row, col] = true;
                rows.Add(row);
                cols.Add(col);
                leftDiagonals.Add(row - col);
                rightDiagonals.Add(row + col);

                FindAndPrintQueensPositions(row + 1);

                board[row, col] = false;
                rows.Remove(row);
                cols.Remove(col);
                leftDiagonals.Remove(row - col);
                rightDiagonals.Remove(row + col);
            }
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    var element = board[row, col] == true ? '*' : '-';
                    Console.Write(element + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool IsAttacked(int row, int col)
            => rows.Contains(row) ||
            cols.Contains(col) ||
            leftDiagonals.Contains(row - col) ||
            rightDiagonals.Contains(row + col);
    }
}

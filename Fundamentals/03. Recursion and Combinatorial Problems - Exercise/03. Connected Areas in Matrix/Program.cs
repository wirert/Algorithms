namespace _03._Connected_Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static char[,] matrix;
        private static int size;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string colStr = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colStr[col];
                }
            }

            var areas = new List<ConnectedArea>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    size = 0;

                    FindAreaSize(row, col);

                    if (size > 0)
                    {
                        areas.Add(new ConnectedArea(row, col, size));
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");

            var orderdAreas = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Position)
                .ToList();

            for (int i = 0; i < areas.Count; i++)            
            {
                Console.WriteLine($"Area #{i + 1} at {orderdAreas[i].Position}, size: {orderdAreas[i].Size}");
            }           
        }

        private static void FindAreaSize(int row, int col)
        {
            if (!IsCell(row, col) || matrix[row, col] != '-')
            {
                return;
            }

            matrix[row, col] = 'v';
            size++;

            FindAreaSize(row, col + 1);
            FindAreaSize(row + 1, col);
            FindAreaSize(row, col - 1);
            FindAreaSize(row - 1, col);
        }

        private static bool IsCell(int row, int col)
         => row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
    }

    class ConnectedArea
    {
        public ConnectedArea(int row, int col, int size)
        {
            Position = new Tuple<int, int>(row, col);
            Size = size;
        }

        public Tuple<int, int>? Position { get; set; }

        public int Size { get; set; }
    }
}

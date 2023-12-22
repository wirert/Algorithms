namespace _07._N_Choose_K_Count
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n, k));
        }

        private static long Binom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return Binom(row -1, col - 1) + Binom(row - 1, col);
        }
    }
}

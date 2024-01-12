namespace _01._Binomial_Coefficients
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static long[,] cache;
       
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            int k = int.Parse(Console.ReadLine()!);

            cache = new long[n + 1, n + 1];

            long binomCoef = FindBinom(n, k);

            Console.WriteLine(binomCoef);
        }

        private static long FindBinom(int row, int col)
        {
            if(col == 0 || row == col)
            {
                return 1;
            }

            if (cache[row, col] > 0)
            {
                return cache[row, col];
            }

            var result = FindBinom(row - 1, col - 1) + FindBinom(row - 1, col);

            cache[row, col] = result;

            return result;
        }       
    }
}

namespace _04._Recursive_Factorial
{
    using System;
    using System.Numerics;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            Console.WriteLine(CalcFactorial(n));
        }

        private static BigInteger CalcFactorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * CalcFactorial(n - 1);
        }
    }
}

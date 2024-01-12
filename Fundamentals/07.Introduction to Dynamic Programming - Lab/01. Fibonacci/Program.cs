namespace _01._Fibonacci
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            if (n < 0) return;

            Console.WriteLine(Fibonacci(n));
        }

        private static long Fibonacci(int n)
        {
            if(n == 0) return 0;

            if(n == 1) return 1;

            if (cache.ContainsKey(n)) return cache[n];

            long result = Fibonacci(n -  1) + Fibonacci(n - 2);

            cache[n] = result;

            return result;
        }
    }
}

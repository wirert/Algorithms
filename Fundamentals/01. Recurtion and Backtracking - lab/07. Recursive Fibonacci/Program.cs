namespace _07._Recursive_Fibonacci
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static long[] calcs = new long[50];

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));
        }

        static long CalcFib(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            if (calcs[number] != 0)
            {
                return calcs[number];
            }

            long num1 = CalcFib(number - 1);
            long num2 = CalcFib(number - 2);

            calcs[number] = num1 + num2;

            return calcs[number];
        }
    }
}

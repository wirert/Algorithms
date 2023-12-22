namespace _02._Nested_Loops
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var combination = new int[n];

            PrintCombinations(combination, 0);
        }

        private static void PrintCombinations(int[] combination, int index)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            for (int i = 1; i <= combination.Length; i++)
            {
                combination[index] = i;

                PrintCombinations(combination, index + 1);
            }
        }
    }
}

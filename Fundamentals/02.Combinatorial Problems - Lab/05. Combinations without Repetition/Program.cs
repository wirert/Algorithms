namespace _05._Combinations_without_Repetition
{
    using System;

    internal class Program
    {
        private static string[] elements;
        private static string[] combination;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            combination = new string[k];

            FindCombinations(0, 0);
        }

        private static void FindCombinations(int index, int startIndex)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(string.Join(' ', combination));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++) 
            {
                combination[index] = elements[i];

                FindCombinations(index + 1, i + 1);
            }
        }
    }
}

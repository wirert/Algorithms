namespace _01._Permutations_without_Repetition
{
    using System;

    internal class Program
    {
        private static string[] elements;
        private static string[] permutation;
        private static bool[] isUsed;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ");
            permutation = new string[elements.Length];
            isUsed = new bool[elements.Length];

            PrintPermutations(0);
        }

        private static void PrintPermutations(int index)
        {
            if (index >= permutation.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!isUsed[i])
                {
                    isUsed[i] = true;
                    permutation[index] = elements[i];

                    PrintPermutations(index + 1);

                    isUsed[i] = false;
                }
            }
        }
    }
}

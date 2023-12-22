namespace _03._Variations_without_Repetition
{
    using System;

    internal class Program
    {
        private static string[] elements;
        private static bool[] isUsed;
        private static string[] variation;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ");
            int varCount = int.Parse(Console.ReadLine());

            variation = new string[varCount];
            isUsed = new bool[elements.Length];

            FindVariations(0);
        }

        private static void FindVariations(int index)
        {
            if (index >= variation.Length)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (isUsed[i])
                    continue;

                isUsed[i] = true;
                variation[index] = elements[i];

                FindVariations(index + 1);

                isUsed[i] = false;
            }
        }
    }
}

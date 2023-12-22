namespace _04._Variations_with_Repetition
{
    using System;

    internal class Program
    {
        private static string[] elements;
        private static string[] variation;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            variation = new string[k];

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
                variation[index] = elements[i];

                FindVariations(index + 1);
            }
        }
    }
}

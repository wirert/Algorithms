namespace _02._Permutations_with_Repetition
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ");

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            var swapped = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (swapped.Contains(elements[i]))
                    continue;

                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);

                swapped.Add(elements[i]);
            }
        }

        private static void Swap(int j, int i)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}

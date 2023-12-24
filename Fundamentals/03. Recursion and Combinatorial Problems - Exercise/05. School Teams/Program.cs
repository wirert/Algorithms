namespace _05._School_Teams
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private const int BOYS_COUNT = 2;
        private const int GIRLS_COUNT = 3;

        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine()!.Split(", ");
            string[] boys = Console.ReadLine()!.Split(", ");

            List<string[]> combsBoys = new List<string[]>();
            List<string[]> combsGirls = new List<string[]>();

        FindCombinations(0, 0, new string [BOYS_COUNT], boys, combsBoys);
            FindCombinations(0, 0, new string[GIRLS_COUNT], girls, combsGirls);

            foreach (var girlsComb in combsGirls)
            {
                foreach (var boysComb in combsBoys)
                {
                    Console.WriteLine($"{string.Join(", ", girlsComb)}, {string.Join(", ", boysComb)}");
                }
            }
        }

        private static void FindCombinations(int index, int startIndex, string[] combination, string[] elements, List<string[]> combinations)
        {
            if (index >= combination.Length)
            {                
                combinations.Add(combination.ToArray());

                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                combination[index] = elements[i];

                FindCombinations(index + 1, i + 1, combination, elements, combinations);
            }
        }
    }
}

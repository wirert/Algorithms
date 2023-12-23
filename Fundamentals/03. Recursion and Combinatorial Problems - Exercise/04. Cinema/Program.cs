namespace _04._Cinema
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static string[] people;
        private static string[] hall;
        private static bool[] isUsed;

        static void Main(string[] args)
        {
            var allPeople = Console.ReadLine().Split(", ").ToHashSet<string>();

            hall = new string[allPeople.Count];
            isUsed = new bool[allPeople.Count];

            string[] input = Console.ReadLine()!.Split(" - ");

            while (input[0] != "generate")
            {
                var name = input[0];
                var positionIndex = int.Parse(input[1]) - 1;

                hall[positionIndex] = name;
                allPeople.Remove(name);
                isUsed[positionIndex] = true;

                input = Console.ReadLine().Split(" - ");
            }

            people = allPeople.ToArray();

            GenerateSeats(0);
        }

        private static void GenerateSeats(int index)
        {
            if (index >= hall.Length)
            {
                PrintResult();
                return;
            }

            GenerateSeats(index + 1);

            for (int i = index + 1; i < people.Length; i++)
            {
                Swap(index, i);

                GenerateSeats(index + 1);

                Swap(index, i); 
            }
        }

        private static void PrintResult()
        {
            int count = 0;
            for (int i = 0; i < hall.Length; i++)
            {
                if (isUsed[i])
                {
                    continue;
                }

                hall[i] = people[count];
                count++;
            }

            Console.WriteLine(string.Join(" ", hall));
        }

        private static void Swap(int i, int j)
        {
            var temp = people[i];
            people[i] = people[j];
            people[j] = temp;
        }
    }
}

namespace _02._Dividing_Presents
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int totalSum = presents.Sum();
            int targetSum = totalSum / 2;

            Dictionary<int, int> possibleSums = FindAllSums(presents);

            int alanSum = possibleSums.Keys
                .Where(s => s <= targetSum)
                .OrderByDescending(s => s)
                .FirstOrDefault();

            int bobSum = totalSum - alanSum;

            Console.WriteLine($"Difference: {bobSum - alanSum}");
            Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");

            List<int> alanPresents = FindPresents(possibleSums, alanSum);

            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> FindPresents(Dictionary<int, int> possibleSums, int alanSum)
        {
            var result = new List<int>();

            while (alanSum > 0)
            {
                int curSum = possibleSums[alanSum];
                result.Add(curSum);
                alanSum -= curSum;
            }

            return result;
        }

        private static Dictionary<int, int> FindAllSums(int[] presents)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var present in presents)
            {
                var curSums = sums.Keys.ToArray();

                foreach (var sum in curSums)
                {
                    var newSum = present + sum;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, present);
                    }
                }
            }

            return sums;
        }
    }
}

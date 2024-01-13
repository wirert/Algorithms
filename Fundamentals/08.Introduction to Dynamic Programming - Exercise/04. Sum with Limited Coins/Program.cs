namespace _04._Sum_with_Limited_Coins
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine()!);

            int combinationCount = FindCombinationsCount(coins, targetSum);

            Console.WriteLine(combinationCount);
        }

        private static int FindCombinationsCount(int[] coins, int targetSum)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var coin in coins)
            {
                var curSums = sums.Keys.ToArray();

                foreach (var sum in curSums)
                {
                    int newSum = sum + coin;

                    if (newSum > targetSum) continue;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, 0);
                    }

                    sums[newSum]++;
                }
            }

            return sums[targetSum];
        }
    }
}

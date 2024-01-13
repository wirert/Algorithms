namespace _03._Sum_with_Unlimited_Coins
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
            var sums = new int[targetSum + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int sum = coin; sum <= targetSum; sum++)
                {
                    sums[sum] += sums[sum - coin];
                }
            }

            return sums[targetSum];
        }
    }
}

namespace _05._Subset_Sum__with_Repetition_
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };

            int targetSum = 17;

            bool[] possibleSums = CalcPossibleSums(nums, targetSum);

            if (!possibleSums[targetSum])
            {
                Console.WriteLine($"Can't calculate {targetSum} sum with given numbers!");
                return;
            }

            List<int> subset = FindSubset(nums, targetSum, possibleSums);

            Console.WriteLine(string.Join(", ", subset));
        }

        private static List<int> FindSubset(int[] nums, int targetSum, bool[] possibleSums)
        {
            var subset = new List<int>();

            while (targetSum > 0)
            {
                foreach (var num in nums)
                {
                    int newSum = targetSum - num;
                    if (newSum >= 0 && possibleSums[newSum])
                    {
                        subset.Add(num);
                        targetSum = newSum;
                    }
                }
            }

            return subset;
        }

        private static bool[] CalcPossibleSums(int[] nums, int targetSum)
        {
            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (!possibleSums[sum]) continue;

                foreach (var num in nums)
                {
                    int newSum = sum + num;

                    if (newSum <= targetSum)
                    {
                        possibleSums[newSum] = true;
                    }
                }
            }

            return possibleSums;
        }
    }
}

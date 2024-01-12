namespace _04._Subset_Sum__No_Repeats_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 1, 4, 2 };

            int targetSum = 6; 

            Dictionary<int, int> possibleSums = CalcPossibleSums(nums, targetSum);

            if (!possibleSums.ContainsKey(targetSum))
            {
                Console.WriteLine($"Can't calculate {targetSum} sum with given numbers!");
                return;
            }

            Stack<int> subset = FindSubset(possibleSums, targetSum);

            Console.WriteLine(string.Join( ", ", subset));
        }

        private static Stack<int> FindSubset(Dictionary<int, int> possibleSums, int targetSum)
        {
            var subset = new Stack<int>();

            while (targetSum > 0)
            {
                int num = possibleSums[targetSum];
                subset.Push(num);
                targetSum -= num;
            }

            return subset;
        }

        private static Dictionary<int, int> CalcPossibleSums(int[] nums, int targetSum)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (int num in nums)
            {
                var curSums = sums.Keys.ToArray();

                foreach (var sum in curSums)
                {
                    int newSum = num + sum;

                    if (newSum > targetSum)
                    {
                        continue;
                    }

                    if(!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, num);
                    }
                    
                }
            }

            return sums;
        }
    }
}

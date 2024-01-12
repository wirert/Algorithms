namespace _03._Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static int[,] lcs;

        static void Main(string[] args)
        {
            string firstStr = Console.ReadLine()!;
            string secondStr = Console.ReadLine()!;

            lcs = new int[firstStr.Length + 1, secondStr.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    int fIdx = row - 1;
                    int sIdx = col - 1;

                    if (firstStr[fIdx] == secondStr[sIdx])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                    }
                }
            }

            Stack<char> longestSubsequence = FindLongestSubsequence(firstStr, secondStr);

            Console.WriteLine(longestSubsequence.Count);
            Console.WriteLine(string.Join("", longestSubsequence));
        }

        private static Stack<char> FindLongestSubsequence(string firstStr, string secondStr)
        {
            int row = lcs.GetLength(0) - 1;
            int col = lcs.GetLength(1) - 1;
            var sequence = new Stack<char>();

            while (row > 0 && col > 0)
            {
                int fIdx = row - 1;
                int sIdx = col - 1;

                if (firstStr[fIdx] == secondStr[sIdx])
                {
                    sequence.Push(firstStr[fIdx]);
                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return sequence;
        }
    }
}

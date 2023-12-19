namespace _08.LongestCommonSubsequence
{
    using System;

    internal class Program
    {
        private static int[,] calcs = new int[1000, 1000];

        static void Main(string[] args)
        {
            for (int i = 0; i < calcs.GetLength(0); i++)
            {
                for (int j = 0; j < calcs.GetLength(1); j++)
                {
                    calcs[i, j] = -1;
                }
            }

            string firstStr = "AGGTAB"; // Console.ReadLine();
            string secondStr = "GXTXAYB"; // Console.ReadLine();

            int result = FindLongestCommonSubsequence(firstStr, secondStr, firstStr.Length - 1, secondStr.Length - 1);

            Console.WriteLine(result);
        }

        private static int FindLongestCommonSubsequence(string firstStr, string secondStr, int index1, int index2)
        {
            if (index1 < 0 || index2 < 0) 
            {
                return 0;
            }

            if (calcs[index1, index2] != -1)
            {
                return calcs[index1, index2];
            }

            if (firstStr[index1] == secondStr[index2])
            {
                calcs[index1, index2] = 1 + FindLongestCommonSubsequence(firstStr, secondStr, index1 - 1, index2 - 1);
                return calcs[index1, index2];
            }

            calcs[index1, index2] = Math.Max(FindLongestCommonSubsequence(firstStr, secondStr, index1, index2 - 1), FindLongestCommonSubsequence(firstStr, secondStr, index1 - 1, index2));

            return calcs[index1, index2];
        }
    }
}

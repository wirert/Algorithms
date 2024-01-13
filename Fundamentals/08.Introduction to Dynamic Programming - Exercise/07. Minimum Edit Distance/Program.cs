namespace _07._Minimum_Edit_Distance
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int replaceCost = int.Parse(Console.ReadLine()!);
            int insertCost = int.Parse(Console.ReadLine()!);
            int deleteCost = int.Parse(Console.ReadLine()!);

            var modifiableStr = Console.ReadLine()!;
            var templateStr = Console.ReadLine()!;

            var dp = new int[modifiableStr.Length + 1, templateStr.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = row * deleteCost;
            }

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = col * insertCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (modifiableStr[row - 1] == templateStr[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        var replace = dp[row - 1, col - 1] + replaceCost;
                        var delete = dp[row - 1, col] + deleteCost;
                        var insert = dp[row, col - 1] + insertCost;

                        dp[row, col] = Math.Min(Math.Min(replace, delete), insert);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[modifiableStr.Length, templateStr.Length]}");
        }
    }
}

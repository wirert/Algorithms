namespace _05._Word_Differences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int[,] dpo = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 1; i < dpo.GetLength(0); i++)
            {
                dpo[i, 0] = i;
            }

            for (int i = 1; i < dpo.GetLength(1); i++)
            {
                dpo[0, i] = i;
            }

            for (int row = 1; row < dpo.GetLength(0); row++)
            {
                for (int col = 1; col < dpo.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        dpo[row, col] = dpo[row - 1, col - 1];
                    }
                    else
                    {
                        dpo[row, col] = 1 + Math.Min(dpo[row, col - 1], dpo[row - 1, col]);
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {dpo[str1.Length, str2.Length]}");
        }
    }
}

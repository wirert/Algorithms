namespace _06._Connecting_Cables
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var cables1 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int cableCount = cables1.Length;

            var cables2 = cables1.OrderBy(x => x).ToArray();

            var dpo = new int[cableCount + 1, cableCount + 1];

            for (int row = 1; row <= cableCount; row++)
            {
                for (int col = 1; col <= cableCount; col++)
                {
                    if (cables1[row - 1] == cables2[col - 1])
                    {
                        dpo[row,col] = 1 + dpo[row - 1, col - 1];
                    }
                    else
                    {
                        dpo[row, col] = Math.Max(dpo[row, col - 1], dpo[row - 1, col]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {dpo[cableCount, cableCount]}");
        }
    }
}

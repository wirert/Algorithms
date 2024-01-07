﻿namespace _07._Sum_of_Coins
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(c => c));
                
            int target = int.Parse(Console.ReadLine());

            var countCoins = new Dictionary<int, int>();
            int totalCoins = 0;

            while (coins.Count > 0 && target > 0)
            {
                var coin = coins.Dequeue();

                var count = target / coin;

                if (count == 0)
                {
                    continue;
                }

                countCoins.Add(coin, count);
                totalCoins += count;

                target %= coin;
            }

            if (target > 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");

                foreach (var coin in countCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
        }
    }
}

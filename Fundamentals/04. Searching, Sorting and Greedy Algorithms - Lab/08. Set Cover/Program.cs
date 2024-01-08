namespace _08._Set_Cover
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var universeSet = Console.ReadLine()
                .Split(", ")
                .ToHashSet();

            int setCount = int.Parse(Console.ReadLine());
            var sets = new List<string[]>();

            for (int i = 0; i < setCount; i++)
            {
                sets.Add(Console.ReadLine()!.Split(", ").ToArray());
            }
            
            var takenSets = new List<string[]>();
                        
            while (universeSet.Count > 0)
            {
                var bestSet = sets
                .OrderByDescending(s => s.Count(e => universeSet.Contains(e)))
                .FirstOrDefault();

                if (bestSet == null)
                {
                    return;
                }

                universeSet.RemoveWhere(e => bestSet.Contains(e));
                takenSets.Add(bestSet);   
                sets.Remove(bestSet);
            }

            Console.WriteLine($"Sets to take ({takenSets.Count}):");

            foreach (var set in takenSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}

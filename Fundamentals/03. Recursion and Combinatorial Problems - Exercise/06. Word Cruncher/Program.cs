namespace _06._Word_Cruncher
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static string[] strings;
        private static Dictionary<int, HashSet<string>> strByIndex;
        private static Dictionary<string, int> strOccurence;
        private static LinkedList<string> match;

        static void Main(string[] args)
        {
            strings = Console.ReadLine()!.Split(", ");
            string wordToMatch = Console.ReadLine()!;

            strByIndex = new Dictionary<int, HashSet<string>>();
            strOccurence = new Dictionary<string, int>();
            match = new LinkedList<string>();

            strings = strings.Where(s => wordToMatch.Contains(s)).ToArray();

            foreach ( var str in strings )
            {     
                if (!strOccurence.ContainsKey(str))
                {
                    strOccurence.Add(str, 0);
                }

                strOccurence[str]++;

                int index = wordToMatch.IndexOf(str);

                while ( index != -1 )
                {
                    if (!strByIndex.ContainsKey(index))
                    {
                        strByIndex.Add(index, new HashSet<string>());
                    }

                    strByIndex[index].Add(str);                    

                    index = wordToMatch.IndexOf(str, index + 1);
                }
            }

            FindMatches(0, wordToMatch);
        }

        private static void FindMatches(int index, string wordToMatch)
        {
            if(index >= wordToMatch.Length || !strByIndex.ContainsKey(index))
            {
                if (index >= wordToMatch.Length)
                {
                    Console.WriteLine(string.Join(" ", match.ToArray()));
                }
                
                return;
            }

            foreach (var str in strByIndex[index])            
            {
                if (strOccurence[str] == 0)
                {
                    continue;
                }

                match.AddLast(str);
                strOccurence[str]--;

                FindMatches(index + str.Length, wordToMatch);

                match.RemoveLast();
                strOccurence[str]++;
            }
        }
    }
}

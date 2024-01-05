namespace _01._Binary_Search
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int[] arr;

        static void Main(string[] args)
        {
            arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());
            
            int index = FindIndex(n, 0, arr.Length - 1);

            Console.WriteLine(index);
        }

        private static int FindIndex(int n, int start, int end)
        {
            while (start <= end)
            {
                var middle = (start + end) / 2;

                if (n == arr[middle])
                {
                    return middle;
                }

                if (n < arr[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }
    }
}

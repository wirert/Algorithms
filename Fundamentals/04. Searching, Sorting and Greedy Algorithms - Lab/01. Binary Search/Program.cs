namespace _01._Binary_Search
{
    using System;
    using System.Linq;

    internal class Program
    {

        static void Main(string[] args)
        {
           var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());
            
            int index = FindIndex(n, arr);

            Console.WriteLine(index);
        }

        private static int FindIndex(int n, int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

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

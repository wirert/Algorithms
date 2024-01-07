namespace _04._Insertion_Sort
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

            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;

                while (j > 0 && arr[j] < arr[j - 1])
                {
                   Swap(arr, j, j - 1);
                    j--;
                }
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i]; 
            arr[i] = arr[j]; 
            arr[j] = temp;
        }
    }
}

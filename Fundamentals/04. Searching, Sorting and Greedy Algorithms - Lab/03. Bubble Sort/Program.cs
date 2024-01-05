namespace _03._Bubble_Sort
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

            for (int i = 0; i < arr.Length; i++)
            {
                var isSorted = true;

                for (int j = 1; j < arr.Length - i; j++) 
                {
                    if (arr[j] < arr[j - 1])
                    {
                        isSorted = false;
                        Swap(arr, j);
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(int[] arr, int j)
        {
            var temp = arr[j];
            arr[j] = arr[j - 1];
            arr[j - 1] = temp;
        }
    }
}

namespace _02._Selection_Sort
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
                int min = i;

                for (int curr = i + 1;  curr < arr.Length; curr++)
                {
                    if (arr[curr] < arr[min])
                    {
                        min = curr;
                    }
                }

                Swap(arr, i, min);
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}

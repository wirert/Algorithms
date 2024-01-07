namespace _05._Quicksort
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

            Quicksort(0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Quicksort(int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
            {
                return;
            }

            int pivotIdx = startIdx;
            int leftIdx = startIdx + 1;
            int rightIdx = endIdx;
            int pivot = arr[pivotIdx];

            while (leftIdx <= rightIdx)
            {
                if (arr[leftIdx] > pivot && arr[rightIdx] < pivot)
                {
                    Swap(leftIdx, rightIdx);
                }

                if (arr[leftIdx] <= pivot)
                {
                    leftIdx++;
                }

                if (arr[rightIdx] >= pivot)
                {
                    rightIdx--;
                }
            }

            Swap(pivotIdx, rightIdx);

            bool isLeftSubArrayLonger = rightIdx - 1 - startIdx > endIdx - rightIdx + 1;

            if (isLeftSubArrayLonger)
            {
                Quicksort(rightIdx + 1, endIdx);
                Quicksort(startIdx, rightIdx - 1);
            }
            else
            {
                Quicksort(startIdx, rightIdx - 1);
                Quicksort(rightIdx + 1, endIdx);
            }
        }

        private static void Swap(int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

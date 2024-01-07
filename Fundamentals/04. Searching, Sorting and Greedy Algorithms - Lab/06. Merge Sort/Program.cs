namespace _06._Merge_Sort
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            numbers = BetterMergeSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int[] BetterMergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            var copy = new int[arr.Length];
            Array.Copy(arr, copy, arr.Length);

            BetterMergeHelper(arr, copy, 0, arr.Length - 1);

            return arr;
        }

        private static void BetterMergeHelper(int[] arr, int[] copy, int leftIdx, int rightIdx)
        {
            if (leftIdx >= rightIdx)
            {
                return;
            }

            int middleIdx = (leftIdx + rightIdx) / 2;

            BetterMergeHelper(copy, arr, leftIdx, middleIdx);
            BetterMergeHelper(copy, arr, middleIdx + 1, rightIdx);

            MergeArrays(arr, copy, leftIdx, middleIdx, rightIdx);
        }

        private static void MergeArrays(int[] arr, int[] copy, int startIdx, int middleIdx, int endIdx)
        {
            int arrIdx = startIdx;
            int leftIdx = startIdx;
            int rightIdx = middleIdx + 1;

            while (leftIdx <= middleIdx && rightIdx <= endIdx)
            {
                if (copy[leftIdx] < copy[rightIdx])
                {
                    arr[arrIdx++] = copy[leftIdx++];
                }
                else
                {
                    arr[arrIdx++] = copy[rightIdx++];
                }
            }

            for (int i = leftIdx; i <= middleIdx; i++)
            {
                arr[arrIdx++] = copy[i];
            }

            for (int i = rightIdx; i <= endIdx; i++)
            {
                arr[arrIdx++] = copy[i];
            }
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            int middleIdx = arr.Length / 2;

            var leftArr = arr.Take(middleIdx).ToArray();
            var rightArr = arr.Skip(middleIdx).ToArray();

            return MergeArrays(MergeSort(leftArr), MergeSort(rightArr));
        }

        private static int[] MergeArrays(int[] firstArr, int[] secondArr)
        {
            int[] resultArr = new int[firstArr.Length + secondArr.Length];

            int index = 0;
            int firstIdx = 0;
            int secondIdx = 0;

            while (firstIdx < firstArr.Length && secondIdx < secondArr.Length)
            {
                if (firstArr[firstIdx] < secondArr[secondIdx])
                {
                    resultArr[index++] = firstArr[firstIdx++];
                }
                else
                {
                    resultArr[index++] = secondArr[secondIdx++];
                }
            }

            for (int i = firstIdx; i < firstArr.Length; i++)
            {
                resultArr[index++] = firstArr[i];
            }

            for (int i = secondIdx; i < secondArr.Length; i++)
            {
                resultArr[index++] = secondArr[i];
            }

            return resultArr;
        }
    }
}

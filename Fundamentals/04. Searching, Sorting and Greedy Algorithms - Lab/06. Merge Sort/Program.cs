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

            numbers = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
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

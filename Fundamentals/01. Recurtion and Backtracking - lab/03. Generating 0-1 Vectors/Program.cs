namespace _03._Generating_0_1_Vectors
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            int[] arr = new int[n];

            GenerataAndPrintVectors(arr, 0);
        }

        private static void GenerataAndPrintVectors(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GenerataAndPrintVectors(arr, index + 1);
            }
        }
    }
}

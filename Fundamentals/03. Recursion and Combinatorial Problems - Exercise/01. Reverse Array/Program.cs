namespace _01._Reverse_Array
{
    using System;

    internal class Program
    {
        private static string[] arr;

        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ');

            Reverse(0);
        }

        private static void Reverse(int index)
        {
            if (index >= arr.Length)
            {
                return;
            }

            Reverse(index + 1);

            Console.Write(arr[index] + " ");
        }
    }
}

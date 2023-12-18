var array = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();


Console.WriteLine(SumArr(array, 0));

static int SumArr(int[] array, int index)
{
    if (index == array.Length - 1)
    {
        return array[index];
    }

    return SumArr(array, index + 1) + array[index];
}

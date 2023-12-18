var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


Console.WriteLine(sumArr(array, 0));

static int sumArr(int[] array, int index)
{
    if (index == array.Length - 1)
    {
        return array[index];
    }

    return sumArr(array, index + 1) + array[index];
}

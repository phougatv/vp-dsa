namespace VP.DSA.Algorithms.Sort;
public class InsertionSort
{
    public Int32[] Sort(Int32[] array)
    {
        if (array.IsEmpty())
            return array;
        if (array.HasOnlyOneItem())
            return array;

        return ProtectedSort(array);
    }

    protected Int32[] ProtectedSort(Int32[] array)
    {
        var i = 1;
        Int32 j;
        while (i < array.Length)
        {
            j = i;
            while (j > 0 && (array[j] < array[j - 1]))
            {
                array.Swap(j, j - 1);
                j = j - 1;
            }

            i = i + 1;
        }

        return array;
    }
}

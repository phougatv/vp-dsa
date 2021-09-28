namespace VP.DSA.Algorithms.Sort;
public class SelectionSort
{
    public Int32[] Sort(Int32[] array)
    {
        if (array.IsEmpty())
            return array;
        if (array.HasOnlyOneItem())
            return array;

        return InternalSort(array);
    }

    protected Int32[] InternalSort(Int32[] array)
    {
        Int32 minIndex;
        var index = 0;
        while (index < array.Length)
        {
            minIndex = array.GetIndexOfMin(index);
            if (index != minIndex)
                array.Swap(index, minIndex);
            index = index + 1;
        }

        return array;
    }
}

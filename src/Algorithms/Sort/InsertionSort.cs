namespace VP.DSA.Algorithms.Sort;
public class InsertionSort
{
    public Int32[] Sort(Int32[] array)
    {
        if (array.IsEmpty())
            return array;
        if (array.HasOnlyOneItem())
            return array;

        return SortBySwappingItemsInOneGo(array);
    }

    protected Int32[] SortBySwappingItemsAfterEachComparision(Int32[] array)
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

    protected Int32[] SortBySwappingItemsInOneGo(Int32[] array)
    {
        var i = 1;
        Int32 j, item;
        while(i < array.Length)
        {
            item = array[i];
            j = i - 1;
            while(j >= 0 && (array[j] > item))
            {
                array[j + 1] = array[j];
                j = j - 1;
            }

            array[j + 1] = item;
            i = i + 1;
        }

        return array;
    }
}

namespace VP.DSA.Shared;
public static class Extension
{
    /// <summary>
    /// Swaps the elements of array at indices indexOne and indexTwo.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="indexOne">The index one.</param>
    /// <param name="indexTwo">The index two.</param>
    public static void Swap(this Int32[] array, Int32 indexOne, Int32 indexTwo)
    {
        if (array.IsEmpty() || array.HasOnlyOneItem())
            throw new ArgumentException($"{nameof(array)} must have 2 or more items.");
        if (indexOne.IsNegative() || indexOne > array.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(indexOne));
        if (indexTwo.IsNegative() || indexTwo > array.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(indexOne));

        array[indexOne] = array[indexOne] + array[indexTwo];
        array[indexTwo] = array[indexOne] - array[indexTwo];
        array[indexOne] = array[indexOne] - array[indexTwo];
    }

    /// <summary>
    /// Gets the index of the minimum/smallest item between <paramref name="lowerBound"/> and array's upper-bound.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="lowerBound">The starting index.</param>
    /// <returns></returns>
    public static Int32 GetIndexOfMin(this Int32[] array, Int32 lowerBound)
    {
        if (array.IsEmpty())
            throw new InvalidOperationException($"Array cannot be empty.");
        if (array.HasOnlyOneItem())
            return array[0];
        if (lowerBound.IsNegative())
            throw new InvalidOperationException($"lowerBound: {lowerBound}, value cannot be negative.");

        return array.GetIndexOfMin(lowerBound, array.Length - 1);
    }

    /// <summary>
    /// Gets the index of the minimum/smallest item between <paramref name="lowerBound"/> and <paramref name="upperBound"/>.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="lowerBound"></param>
    /// <param name="upperBound"></param>
    /// <returns></returns>
    public static Int32 GetIndexOfMin(this Int32[] array, Int32 lowerBound, Int32 upperBound)
    {
        if (lowerBound.IsNegative() || lowerBound > array.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(lowerBound));
        if (upperBound.IsNegative() || upperBound > array.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(upperBound));

        var minIndex = lowerBound;
        var minItem = array[lowerBound];
        while (lowerBound <= upperBound)
        {
            if (array[lowerBound] < minItem)
            {
                minItem = array[lowerBound];
                minIndex = lowerBound;
            }

            lowerBound = lowerBound + 1;
        }

        return minIndex;
    }

    #region ICollection<T> Extensions
    public static Boolean HasOnlyOneItem<T>(this ICollection<T> collection) => collection.Count == 1;
    public static Boolean IsEmpty<T>(this ICollection<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        return collection.Count == 0;
    }
    public static Boolean IsNull<T>(this ICollection<T> collection) where T : class => collection == null;
    #endregion ICollection<T> Extensions

    #region Int32 Extensions
    public static Boolean IsEven(this Int32 i32) => (i32 & 1) == 0;
    public static Boolean IsOdd(this Int32 i32) => (i32 & 1) == 1;
    public static Boolean IsNegative(this Int32 i32) => i32 < 0;
    public static Boolean IsPositive(this Int32 i32) => i32 > 0;
    public static Boolean IsZero(this Int32 i32) => i32 == 0;
    #endregion Int32 Extensions

    #region IEnumerable<T> Extensions
    public static Boolean IsNull<T>(this IEnumerable<T> source) => source == null;
    #endregion IEnumerable<T> Extensions
}

namespace VP.DSA.Algorithms;
public static class Extension
{
    /// <summary>
    /// Swaps the elements of array at indices i and j.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="i">The index i.</param>
    /// <param name="j">The index j.</param>
    public static void Swap(this Int32[] array, Int32 i, Int32 j)
    {
        array[i] = array[i] + array[j];
        array[j] = array[i] - array[j];
        array[i] = array[i] - array[j];
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
        if (lowerBound.IsNegative())
            throw new InvalidOperationException($"lowerBound: {lowerBound}, value cannot be negative.");
        if (upperBound.IsNegative())
            throw new InvalidOperationException($"upperBound: {upperBound}, value cannot be negative.");
        if (lowerBound >= array.Length)
            throw new InvalidOperationException($"lowerBound: {lowerBound}, value must be less than array's length.");
        if (upperBound >= array.Length)
            throw new InvalidOperationException($"upperBound: {upperBound}, value must be less than array's length.");

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

    #region Generic Exntesion Methods
    public static Boolean HasOnlyOneItem<T>(this T[] array) => array.Length == 1;
    public static Boolean IsEmpty<T>(this T[] array) => array.Length == 0;
    public static Boolean IsNull<T>(this T[] array) where T : class => array == null;
    #endregion Generic Exntesion Methods

    #region
    public static Boolean IsEven(this Int32 i32) => (i32 & 1) == 0;
    public static Boolean IsOdd(this Int32 i32) => (i32 & 1) == 1;
    public static Boolean IsNegative(this Int32 i32) => i32 < 0;
    public static Boolean IsPositive(this Int32 i32) => i32 > 0;
    public static Boolean IsZero(this Int32 i32) => i32 == 0;
    #endregion
}

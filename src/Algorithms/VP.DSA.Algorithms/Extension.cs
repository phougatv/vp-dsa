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

    #region Generic Exntesion Methods
    public static Boolean HasOnlyOneItem<T>(this T[] array) => array.Length == 1;
    public static Boolean IsEmpty<T>(this T[] array) => array.Length == 0;
    public static Boolean IsNull<T>(this T[] array) where T : class => array.Length == 0;
    #endregion Generic Exntesion Methods
}

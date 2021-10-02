namespace VP.DSA.DataStructures;

using System.Collections;

public class List<T> : IList<T>
{
    public T this[Int32 index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Int32 Count => throw new NotImplementedException();

    public Boolean IsReadOnly => throw new NotImplementedException();

    public void Add(T item) => throw new NotImplementedException();
    public void Clear() => throw new NotImplementedException();
    public Boolean Contains(T item) => throw new NotImplementedException();
    public void CopyTo(T[] array, Int32 arrayIndex) => throw new NotImplementedException();
    public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();
    public Int32 IndexOf(T item) => throw new NotImplementedException();
    public void Insert(Int32 index, T item) => throw new NotImplementedException();
    public Boolean Remove(T item) => throw new NotImplementedException();
    public void RemoveAt(Int32 index) => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}

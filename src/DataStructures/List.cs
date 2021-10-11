namespace VP.DSA.DataStructures;

using System.Collections;
using VP.DSA.Shared;

public class List<T> : IList<T>
{
    #region Private Variables
    private const Int32 MaxArrayLength = 0x7FEFFFFF;
    private const Int32 DefaultCapacity = 4;
    private static readonly T[] _emptyArray = Array.Empty<T>();
    private T[] _array;
    private Int32 _count;
    #endregion Private Variables

    #region Protected Properties
    protected Boolean IsCapacityMatched => _array.Length == _count;
    #endregion Protected Properties

    #region Public Properties
    public T this[Int32 index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Int32 Capacity
    {
        get => _array.Length;
        set
        {
            if (value.IsNegative())
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            if (value != _count)
            {
                if (value.IsPositive())
                {
                    var newArray = new T[value];
                    if (!IsEmpty)
                        Array.Copy(_array, 0, newArray, 0, _count);
                    _array = newArray;
                }
                else
                {
                    _array = _emptyArray;
                }
            }
        }
    }

    public Int32 Count => _count;

    public Boolean IsEmpty => _count.IsZero();

    public Boolean IsReadOnly => throw new NotImplementedException();
    #endregion Public Properties

    public List()
    {
        _array = _emptyArray;
        _count = 0;
    }

    public List(Int32 capacity)
    {
        if (capacity.IsNegative())
            throw new ArgumentOutOfRangeException(nameof(capacity));
        _array = capacity.IsZero() ? _emptyArray : new T[capacity];
        _count = 0;
    }

    public List(IEnumerable<T> collection)
    {
        if (collection.IsNull())
            throw new ArgumentNullException(nameof(collection));

        if (collection is ICollection<T> coll)
        {
            _count = coll.Count;
            if (coll.Count.IsZero())
            {
                _array = new T[DefaultCapacity];
            }
            else
            {
                _array = new T[_count];
                coll.CopyTo(_array, 0);
            }
        }
        else
        {
            _array = _emptyArray;
            using var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
                Add(enumerator.Current);
        }
    }

    /// <summary> Adds the item to the end of the list. </summary>
    /// <param name="item">The item.</param>
    public void Add(T item)
    {
        if (_count == 0)
            _array = new T[DefaultCapacity];
        if (IsCapacityMatched)
            EnsureCapacity(_count + 1);
        _array[_count] = item;
        _count = _count + 1;
    }

    /// <summary> Clears the array. </summary>
    public void Clear()
    {
        if (_array == null)
            return;
        Array.Clear(_array);
    }

    /// <summary> Checks if the item exists in the list. </summary>
    /// <param name="item">The item.</param>
    /// <returns></returns>
    public Boolean Contains(T item)
    {
        Int32 index = IndexOf(item);
        return !index.IsNegative();
    }
    public void CopyTo(T[] array, Int32 arrayIndex) => throw new NotImplementedException();

    /// <summary> Gets the index of the item. </summary>
    /// <param name="item">The item.</param>
    /// <returns></returns>
    public Int32 IndexOf(T item)
    {
        if (item == null)
        {
            for (Int32 i = 0; i < _count; i++)
            {
                if (_array[i] == null)
                    return i;
            }

            return -1;
        }

        var comparer = EqualityComparer<T>.Default;
        for (Int32 i = 0; i < _count; i++)
        {
            if (comparer.Equals(item, _array[i]))
                return i;
        }

        return -1;
    }

    /// <summary> Inserts an item at the specified index. </summary>
    /// <param name="index">The index.</param>
    /// <param name="item">The item.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void Insert(Int32 index, T item) => throw new NotImplementedException();

    /// <summary> Removes the first occurrence of the item from the list. </summary>
    /// <param name="item">The item.</param>
    /// <returns></returns>
    public Boolean Remove(T item)
    {
        Int32 index = IndexOf(item);
        if (index.IsNegative()) return false;

        RemoveAt(index);
        return true;
    }

    /// <summary> Removes the element at the specified index, if the index is valid. </summary>
    /// <param name="index">The index.</param>
    /// <exception cref="ArgumentOutOfRangeException">When index is greater than or equal to count.</exception>
    public void RemoveAt(Int32 index)
    {
        if ((UInt32)index >= (UInt32)_count)
            throw new ArgumentOutOfRangeException(nameof(index));

        Int32 sourceIndex = index + 1;
        Array.Copy(_array, sourceIndex, _array, index, _count - sourceIndex);
        _count = _count - 1;
#pragma warning disable CS8601 // Possible null reference assignment.
        _array[_count] = default;
#pragma warning restore CS8601 // Possible null reference assignment.
    }
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    #region Protected Methods
    protected void EnsureCapacity(Int32 requiredCapacity)
    {
        if (Capacity > requiredCapacity)
            return;

        // Uses bitwise shift operator to double the Capacity
        Int32 newCapacity = Capacity == 0 ? DefaultCapacity : Capacity << 1;
        // Allows the list to grow to maximum capacity, before encountering overlflow.
        // Thanks to (UInt32) cast, this check works even when Capacity(_array.Length) overlfowed.
        if ((UInt32)newCapacity > MaxArrayLength)
            newCapacity = MaxArrayLength;
        if (newCapacity < requiredCapacity)
            newCapacity = requiredCapacity;
        Capacity = newCapacity;
    }
    #endregion Protected Methods

    #region Enumerator
    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        #region Private Fields
        private Int32 _index;
        private List<T> _vList;
        private T _current;
        #endregion Private Fields

        #region Ctor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Enumerator(List<T> vList)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _index = 0;
            _vList = vList ?? throw new ArgumentNullException(nameof(vList));
#pragma warning disable CS8601 // Possible null reference assignment.
            _current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        #endregion Ctor

        public Object Current
        {
            get
            {
                if ((UInt32)_index > (UInt32)_vList._count)
                    throw new ArgumentOutOfRangeException(nameof(_index));
#pragma warning disable CS8603 // Possible null reference return.
                return _current;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        T IEnumerator<T>.Current => _current;

        public void Dispose()
        {
            _index = 0;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _vList = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8601 // Possible null reference assignment.
            _current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        public Boolean MoveNext()
        {
            if ((UInt32)_index < (UInt32)_vList._count)
            {
                _current = _vList._array[_index];
                _index = _index + 1;
                return true;
            }

            _index = _vList._count + 1;
#pragma warning disable CS8601 // Possible null reference assignment.
            _current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
            return false;
        }

        public void Reset()
        {
            _index = 0;
#pragma warning disable CS8601 // Possible null reference assignment.
            _current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }
    #endregion Enumerator
}

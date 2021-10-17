namespace VP.DSA.DataStructures;

using System.Collections;
using VP.DSA.Shared;

public class List<T> : IList<T>
{
    #region Private Variables
    private const Int32 MaxArrayLength = 0x7FEFFFFF;    // As per C# this is the maximum number of elements an array can have.
    private const Int32 DefaultCapacity = 4;
    private static readonly T[] _emptyArray = Array.Empty<T>();
    private T[] _array;
    #endregion Private Variables

    #region Protected Properties
    protected Boolean IsCapacityMatched => _array.Length == Count;
    #endregion Protected Properties

    #region Public Properties
    public T this[Int32 index]
    {
        get
        {
            if ((UInt32)index >= (UInt32)Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            return _array[index];
        }
        set
        {
            if ((UInt32)index >= (UInt32)Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _array[index] = value;
        }
    }

    public Int32 Capacity
    {
        get => _array.Length;
        set
        {
            if (value.IsNegative())
                throw new InvalidOperationException($"{nameof(Capacity)} cannot be -ve.");
            SetCapacity(value);
            if (value < Count)
                Count = value;
        }
    }

    public Int32 Count { get; private set; }

    public Boolean IsEmpty => Count.IsZero();

    public Boolean IsReadOnly => throw new NotImplementedException();
    #endregion Public Properties

    public List()
    {
        _array = _emptyArray;
        Count = 0;
    }

    public List(Int32 capacity)
    {
        if (capacity.IsNegative())
            throw new InvalidOperationException($"{nameof(capacity)} cannot be -ve.");
        _array = capacity.IsZero() ? _emptyArray : new T[capacity];
        Count = Capacity;
    }

    public List(IEnumerable<T> collection)
    {
        if (collection.IsNull())
            throw new ArgumentNullException(nameof(collection));

        if (collection is ICollection<T> coll)
        {
            Count = coll.Count;
            if (coll.Count.IsZero())
            {
                _array = new T[DefaultCapacity];
            }
            else
            {
                _array = new T[Count];
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

    #region Public Methods
    /// <summary> Adds the item to the end of the list. </summary>
    /// <param name="item">The item.</param>
    public void Add(T item)
    {
        if (Count == 0)
            _array = new T[DefaultCapacity];
        if (IsCapacityMatched)
            EnsureCapacity(Count + 1);
        _array[Count] = item;
        Count = Count + 1;
    }

    /// <summary>
    /// Clears the array by removing all the elements.
    /// Sets the elements of the array to default values and Count to 0.
    /// </summary>
    public void Clear()
    {
        if (Count > 0)
        {
            Array.Clear(_array);
            ResetCount();
        }
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

    /// <summary> Gets the index of the item if it exists, -1 otherwise. </summary>
    /// <param name="item">The item.</param>
    /// <returns></returns>
    public Int32 IndexOf(T item)
    {
        if (item == null)
        {
            for (Int32 i = 0; i < Count; i++)
            {
                if (_array[i] == null)
                    return i;
            }

            return -1;
        }

        var comparer = EqualityComparer<T>.Default;
        for (Int32 i = 0; i < Count; i++)
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
    public void Insert(Int32 index, T item)
    {
        if ((UInt32)index >= (UInt32)Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        if (IsCapacityMatched)
            EnsureCapacity(Count + 1);

        Array.Copy(_array, index, _array, index + 1, Count - index);
        _array[index] = item;
        Count = Count + 1;
    }

    /// <summary> Removes the first occurrence of the item from the list. </summary>
    /// <param name="item">The item.</param>
    /// <returns></returns>
    public Boolean Remove(T item)
    {
        Int32 index = IndexOf(item);
        if (index.IsNegative())
            return false;

        RemoveAt(index);
        return true;
    }

    /// <summary> Removes the element at the specified index, if the index is valid. </summary>
    /// <param name="index">The index.</param>
    /// <exception cref="InvalidOperationException">When index is greater than or equal to count.</exception>
    public void RemoveAt(Int32 index)
    {
        if ((UInt32)index >= (UInt32)Count)
            throw new InvalidOperationException($"{nameof(index)} cannot be greater or equal to Count.");

        Int32 sourceIndex = index + 1;
        Array.Copy(_array, sourceIndex, _array, index, Count - sourceIndex);
        Count = Count - 1;
#pragma warning disable CS8601 // Possible null reference assignment.
        _array[Count] = default;
#pragma warning restore CS8601 // Possible null reference assignment.
    }
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);
    #endregion Public Methods

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
        SetCapacity(newCapacity);
    }

    protected void SetCapacity(Int32 capacity)
    {
        if ((UInt32)capacity == (UInt32)Count)
            return;
        if (capacity.IsZero())
        {
            _array = _emptyArray;
            return;
        }

        var newArray = new T[capacity];
        Int32 length = capacity < Count ? capacity : Count;
        if (!IsEmpty)
            Array.Copy(_array, 0, newArray, 0, length);
        _array = newArray;
    }
    #endregion Protected Methods

    #region Private Methods
    private void ResetCount() => Count = 0;
    #endregion Private Methods

    #region Enumerator
    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        #region Private Fields
        private Int32 _index;
        private List<T> _list;
        private T _current;
        #endregion Private Fields

        #region Ctor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Enumerator(List<T> vList)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _index = 0;
            _list = vList ?? throw new ArgumentNullException(nameof(vList));
#pragma warning disable CS8601 // Possible null reference assignment.
            _current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        #endregion Ctor

        public Object Current
        {
            get
            {
                if ((UInt32)_index > (UInt32)_list.Count)
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
            _list = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8601 // Possible null reference assignment.
            _current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        public Boolean MoveNext()
        {
            if ((UInt32)_index < (UInt32)_list.Count)
            {
                _current = _list._array[_index];
                _index = _index + 1;
                return true;
            }

            _index = _list.Count + 1;
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

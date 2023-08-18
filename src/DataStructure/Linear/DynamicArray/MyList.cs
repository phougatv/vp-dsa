namespace VP.DataStructure.Linear.DynamicArray;

using System.Collections;
using System.Collections.Generic;

public class MyList : IMyList
{
	#region Private Constants & Static Variables
	private const Int32 DefaultCapacity = 4;

	private static readonly Int32 _maxCapacity = Array.MaxLength;
	private static readonly Int32[] _emptyItems = Array.Empty<Int32>();
	#endregion Private Constants

	#region Private Variables
	private Int32[] _items;
	#endregion Private Variables

	#region Public Properties
	public Int32 this[Int32 index]
	{
		get
		{
			if ((UInt32)index >= (UInt32)Count) throw new ArgumentOutOfRangeException(nameof(index));
			return _items[index];
		}
		set
		{
			if ((UInt32)index >= (UInt32)Count) throw new ArgumentOutOfRangeException(nameof(index));
			_items[index] = value;
		}
	}

	public Int32 Capacity
	{
		get => _items.Length;
		set
		{
			if (value < Count) throw new ArgumentOutOfRangeException(nameof(value));
			if (value == Capacity) return;
			if (value > 0) ResizeInternalArray(value);
			else _items = _emptyItems;
		}
	}

	/// <summary>
	/// Gets number of items contained in the <see cref="MyList"/>
	/// </summary>
	public Int32 Count { get; private set; }
	#endregion Public Properties

	#region Public Constructors
	public MyList()
		: this(0)
	{

	}

	public MyList(Int32 capacity)
	{
		if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
		Count = 0;
		_items = capacity == 0 ? _emptyItems : (new Int32[capacity]);
	}
	#endregion Public Constructors

	#region Public Methods
	public void Add(Int32 item)
	{
		GrowCapacityIfNeeded(Count + 1);
		_items[Count++] = item;
	}
	public void Clear()
	{
		var count = Count;
		Count = 0;
		if (count == 0) return;
		Array.Clear(_items, 0, count);
	}

	public Boolean Contains(Int32 item) => Count > 0 && IndexOf(item) > -1;

	public Int32 IndexOf(Int32 item)
	{
		var i = -1;
		while (Count > 0 && ++i < Count)
		{
			if (_items[i] == item) return i;
		}

		return -1;
	}
	public Int32 LastIndexOf(Int32 item)
	{
		var i = Count;
		while (Count > 0 && --i >= 0)
		{
			if (_items[i] == item) return i;
		}

		return -1;
	}
	public Boolean Remove(Int32 item)
	{
		var index = IndexOf(item);
		if (index == -1) return false;
		RemoveAt(index);
		return true;
	}
	public void RemoveAt(Int32 index)
	{
		if ((UInt32)index >= (UInt32)Count) throw new ArgumentOutOfRangeException(nameof(index));
		if (index < Count - 1) Array.Copy(_items, index + 1, _items, index, Count - index - 1);
		_items[--Count] = default;
	}
	public void Sort() => Array.Sort(_items, 0, Count);
	public void TrimExcess()
	{
		var threshold = (Int32)(Capacity * 0.9);
		if (Count < threshold) Capacity = Count;
	}
	public IEnumerator<Int32> GetEnumerator()
	{
		var i = -1;
		while (Count > 0 && ++i < Count)
		{
			yield return _items[i];
		}
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	#endregion Public Methods

	#region Private Methods
	private void GrowCapacityIfNeeded(Int32 minExpectedCapacity)
	{
		if (minExpectedCapacity <= Capacity) return;

		var newCapacity = Capacity == 0 ? DefaultCapacity : Capacity * 2;
		if ((UInt32)newCapacity > (UInt32)_maxCapacity) newCapacity = _maxCapacity;
		if ((UInt32)newCapacity < (UInt32)minExpectedCapacity) newCapacity = minExpectedCapacity;
		Capacity = newCapacity;
	}
	private void ResizeInternalArray(Int32 capacity)
	{
		var newItems = new Int32[capacity];
		Array.Copy(_items, newItems, Count);
		_items = newItems;
	}
	#endregion Private Methods
}

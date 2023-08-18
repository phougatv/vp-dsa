namespace VP.DataStructures.Linear.DynamicArray;
public interface IMyList : IEnumerable<Int32>
{
	/// <summary>
	/// Gets or sets the total number of items the internal data structure can hold without resizing.
	/// </summary>
	Int32 Capacity { get; set; }

	/// <summary>
	/// Gets the total number of items contained in the <see cref="IMyList"/>
	/// </summary>
	Int32 Count { get; }

	/// <summary>
	/// Adds an item to the end of the <see cref="IMyList"/>
	/// </summary>
	/// <param name="item"></param>
	void Add(Int32 item);

	/// <summary>
	/// Removes all elements from the <see cref="IMyList"/>
	/// </summary>
	void Clear();

	/// <summary>
	/// Determines whether an item is in the <see cref="IMyList"/>
	/// </summary>
	/// <param name="item">The item</param>
	/// <returns><see cref="true"/> if the item is in the list; <see cref="false"/> otherwise.</returns>
	Boolean Contains(Int32 item);

	/// <summary>
	/// Gets the zero-based index of the first occurrence of the <paramref name="item"/> in the list.
	/// </summary>
	/// <param name="item">The item</param>
	/// <returns>Returns zero-based index of the first occurrence of the <paramref name="item"/> in the list; -1 if not found.</returns>
	Int32 IndexOf(Int32 item);

	/// <summary>
	/// Gets the zero-based index of the last occurrence of the <paramref name="item"/> in the list.
	/// </summary>
	/// <param name="item">The item</param>
	/// <returns>The zero-based index of the last occurrence of the <paramref name="item"/>.</returns>
	Int32 LastIndexOf(Int32 item);

	/// <summary>
	/// Removes the first occurrence of the <paramref name="item"/>.
	/// </summary>
	/// <param name="item">The item</param>
	/// <returns><see cref="true"/> if the item is successfully removed; <see cref="false"/> otherwise.</returns>
	Boolean Remove(Int32 item);

	/// <summary>
	/// Removes the item at the specified index in the <see cref="IMyList"/>
	/// </summary>
	/// <param name="index">The index</param>
	void RemoveAt(Int32 index);

	/// <summary>
	/// Sorts the items in the entire list.
	/// It uses Array.Sort internally.
	/// </summary>
	void Sort();

	/// <summary>
	/// Sets the capacity to the count of the list, if the unused memory is 10% or more.
	/// </summary>
	void TrimExcess();
}

namespace VP.DSA.Algorithms.UnitTests.Sort;

using System;
using VP.DSA.Algorithms.Sort;
using Xunit;

public class SelectionSortTest
{
    [Fact]
    public void Sort_WhenArrayIsEmpty_ReturnsTheArray()
    {
        // Arrange
        var selectionSort = new SelectionSort();
        var array = Array.Empty<Int32>();
        var expected = new Int32[0];

        // Act
        var actual = selectionSort.Sort(array);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Sort_WhenArrayHasOnlyOneItem_ReturnsTheArray()
    {
        // Arrange
        var selectionSort = new SelectionSort();
        var array_1 = new Int32[] { -1 };
        var array_2 = new Int32[] { 0 };
        var array_3 = new Int32[] { 1 };
        var expected_1 = new Int32[] { -1 };
        var expected_2 = new Int32[] { 0 };
        var expected_3 = new Int32[] { 1 };

        // Act
        var actual_1 = selectionSort.Sort(array_1);
        var actual_2 = selectionSort.Sort(array_2);
        var actual_3 = selectionSort.Sort(array_3);

        // Assert
        Assert.Equal(expected_1, actual_1);
        Assert.Equal(expected_2, actual_2);
        Assert.Equal(expected_3, actual_3);
    }

    [Fact]
    public void Sort_WhenArrayIsUnsortedAndValid_ReturnsSortedArray()
    {
        // Arrange
        var selectionSort = new SelectionSort();
        var array_1 = new Int32[] { 10, 2, 9, 5, 4, 8, 3 };
        var array_2 = new Int32[] { 7, 3, 8, 0, -1, 0 };
        var array_3 = new Int32[] { 5, 4, 3, 2, 1, 0 };
        var array_4 = new Int32[] { 1, 2, 3, 4, 5, 6 };
        var expected_1 = new Int32[] { 2, 3, 4, 5, 8, 9, 10 };
        var expected_2 = new Int32[] { -1, 0, 0, 3, 7, 8 };
        var expected_3 = new Int32[] { 0, 1, 2, 3, 4, 5 };
        var expected_4 = new Int32[] { 1, 2, 3, 4, 5, 6 };

        // Act
        var actual_1 = selectionSort.Sort(array_1);
        var actual_2 = selectionSort.Sort(array_2);
        var actual_3 = selectionSort.Sort(array_3);
        var actual_4 = selectionSort.Sort(array_4);

        // Assert
        Assert.Equal(expected_1, actual_1);
        Assert.Equal(expected_2, actual_2);
        Assert.Equal(expected_3, actual_3);
        Assert.Equal(expected_4, actual_4);
    }
}

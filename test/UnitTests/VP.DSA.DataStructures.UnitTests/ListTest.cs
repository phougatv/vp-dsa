namespace VP.DSA.DataStructures.UnitTests;

using System;
using Xunit;

public class ListTest
{
    [Fact]
    public void Add_WhenListIsValid_AddsTheItemAtTheEndOfTheListAndIncreasesTheCountByOne()
    {
        // Arrange
        var list_1 = new List<Int32> { 10, 20, 30 };
        var list_2 = new List<Int32>();
        var list_3 = new List<Int32>(new Int32[] { 10, 20, 30, 40 });
        var expectedList_1 = new List<Int32> { 10, 20, 30, 40 };
        var expectedList_2 = new List<Int32> { 40 };
        var expectedList_3 = new List<Int32> { 10, 20, 30, 40, 50 };

        // Act
        list_1.Add(40);
        list_2.Add(40);
        list_3.Add(50);

        // Assert
        Assert.False(list_1.IsEmpty);
        Assert.Equal(expectedList_1.Count, list_1.Count);
        Assert.Equal(expectedList_1[^1], list_1[^1]);   // compares the last element.
        Assert.Equal(expectedList_1, list_1);
        Assert.Equal(expectedList_1.Capacity, list_1.Capacity);

        Assert.False(list_2.IsEmpty);
        Assert.Equal(expectedList_2.Count, list_2.Count);
        Assert.Equal(expectedList_2[^1], list_2[^1]);   // compares the last element.
        Assert.Equal(expectedList_2, list_2);
        Assert.Equal(expectedList_1.Capacity, list_1.Capacity);

        Assert.False(list_3.IsEmpty);
        Assert.Equal(expectedList_3.Count, list_3.Count);
        Assert.Equal(expectedList_3[^1], list_3[^1]);   // compares the last element.
        Assert.Equal(expectedList_3, list_3);
        Assert.Equal(expectedList_1.Capacity, list_1.Capacity);
    }

    [Fact]
    public void Capacity_WhenSetNegative_ThrowsInvalidOperationException()
    {
        // Arrange
        var list = new List<Int32> { 10, 20, 30 };

        // Act
        Action act = () => list.Capacity = -1;

        // Assert
        var actualException = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal("Capacity cannot be -ve.", actualException.Message);
    }

    [Fact]
    public void Capacity_WhenSetZero_SetsInternalArrayEmpty()
    {
        // Arrange
        var list = new List<Int32> { 10, 20, 30 };

        // Act
        list.Capacity = 0;

        // Assert
        Assert.Equal(0, list.Capacity);
        Assert.Empty(list);
        Assert.True(list.IsEmpty);
    }

    [Fact]
    public void Capacity_WhenSetToPositiveNumber_SetInternalArrayToNewArrayWithNewCapacity()
    {
        // Arrange
        var list_1 = new List<Int32> { 10, 20, 30 };
        var list_2 = new List<Int32> { 10, 20, 30 };
        var expectedList_1 = new List<Int32> { 10, 20 };
        var expectedList_2 = new List<Int32> { 10, 20, 30 };

        // Act
        list_1.Capacity = 2;
        list_2.Capacity = 8;

        // Assert
        Assert.Equal(2, list_1.Capacity);
        Assert.Equal(2, list_1.Count);
        Assert.Equal(expectedList_1, list_1);
        Assert.False(list_1.IsEmpty);

        Assert.Equal(8, list_2.Capacity);
        Assert.Equal(3, list_2.Count);
        Assert.Equal(expectedList_2, list_2);
        Assert.False(list_2.IsEmpty);
    }

    [Fact]
    public void Ctor_WhenCapacityIsNegative_ThrowsInvalidOperationException()
    {
        // Arrange
        List<Int32> list;

        // Act
        Action act = () => list = new List<Int32>(-1);

        // Assert
        var actualException = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal("capacity cannot be -ve.", actualException.Message);
    }

    [Fact]
    public void Ctor_WhenCollectionIsNull_ThrowsArgumentNullException()
    {
        // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Int32[] array = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        List<Int32> list;

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        Action act = () => list = new List<Int32>(array);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        var actualException = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("collection", actualException.ParamName);
        Assert.Equal("Value cannot be null. (Parameter 'collection')", actualException.Message);
    }

    [Fact]
    public void Clear_WhenCountIsGreaterThanZero_ClearsTheInternalArrayAndSetsTheCountToZero()
    {
        // Arrange
        var list_1 = new List<Int32> { 10, 20, 30 };
        var list_2 = new List<Int32> { 10, 20, 30, 40, 50 };

        // Act
        list_1.Clear();
        list_2.Clear();

        // Assert
        Assert.True(list_1.IsEmpty);
        Assert.Empty(list_1);
        Assert.Equal(4, list_1.Capacity);

        Assert.True(list_2.IsEmpty);
        Assert.Empty(list_2);
        Assert.Equal(8, list_2.Capacity);
    }

    [Fact]
    public void Contains_WhenItemExists_ReturnsTrue()
    {
        // Arrange
        var list_1 = new List<Int32> { 10, 20, 30, 40, 50 };
        Int32 item_1 = 40;

        // Act
        Boolean exists = list_1.Contains(item_1);

        // Assert
        Assert.True(exists);
        Assert.False(list_1.IsEmpty);
        Assert.Equal(8, list_1.Capacity);
        Assert.Equal(5, list_1.Count);
    }

    [Fact]
    public void Contains_WhenItemDoesNotExists_ReturnsFalse()
    {
        // Arrange
        var list_1 = new List<Int32> { 10, 20, 30, 40, 50 };
        var list_2 = new List<Int32>();
        Int32 item_1 = 60;
        Int32 item_2 = 10;

        // Act
        Boolean exists_1 = list_1.Contains(item_1);
        Boolean exists_2 = list_2.Contains(item_2);

        // Assert
        Assert.False(exists_1);
        Assert.False(list_1.IsEmpty);
        Assert.Equal(8, list_1.Capacity);
        Assert.Equal(5, list_1.Count);

        Assert.False(exists_2);
        Assert.True(list_2.IsEmpty);
        Assert.Equal(0, list_2.Capacity);
    }

    [Fact]
    public void IndexOf_WhenItemExists_ReturnsTheIndexOfItem()
    {
        // Arrange
        var list = new List<Int32> { 10, 20, 30, 40, 50 };
        Int32 item_1 = 40;
        Int32 item_2 = 10;
        Int32 expectedIndex_1 = 3;
        Int32 expectedIndex_2 = 0;

        // Act
        Int32 actualIndex_1 = list.IndexOf(item_1);
        Int32 actualIndex_2 = list.IndexOf(item_2);

        // Assert
        Assert.Equal(expectedIndex_1, actualIndex_1);
        Assert.Equal(expectedIndex_2, actualIndex_2);
        Assert.False(list.IsEmpty);
        Assert.Equal(8, list.Capacity);
        Assert.Equal(5, list.Count);
    }

    [Fact]
    public void IndexOf_WhenItemDoesNotExists_ReturnsMinusOne()
    {
        // Arrange
        var list_1 = new List<Int32> { 10, 20, 30, 40, 50 };
        var list_2 = new List<Int32>();
        Int32 item_1 = 40;
        Int32 item_2 = 10;
        Int32 expectedIndex_1 = 3;
        Int32 expectedIndex_2 = -1;

        // Act
        Int32 actualIndex_1 = list_1.IndexOf(item_1);
        Int32 actualIndex_2 = list_2.IndexOf(item_2);

        // Assert
        Assert.Equal(expectedIndex_1, actualIndex_1);
        Assert.False(list_1.IsEmpty);
        Assert.Equal(8, list_1.Capacity);
        Assert.Equal(5, list_1.Count);

        Assert.Equal(expectedIndex_2, actualIndex_2);
        Assert.True(list_2.IsEmpty);
        Assert.Equal(0, list_2.Capacity);
    }

    [Fact]
    public void RemoveAt_WhenIndexIsValid_RemovesAnElementFromTheList()
    {
        // Arrange
        Int32 index_1 = 0;
        var vList_1 = new List<Int32> { 10, 20, 30, 40, 50, 60 };
        var expectedVpList_1 = new List<Int32> { 20, 30, 40, 50, 60 };

        // Act
        vList_1.RemoveAt(index_1);

        // Assert
        Assert.Equal(expectedVpList_1.Count, vList_1.Count);
        Assert.Equal(expectedVpList_1, vList_1);   // Need to implement Enumerator on VList
    }
}
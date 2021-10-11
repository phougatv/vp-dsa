namespace VP.DSA.DataStructures.UnitTests;

using System;
using Xunit;

public class ListTest
{
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
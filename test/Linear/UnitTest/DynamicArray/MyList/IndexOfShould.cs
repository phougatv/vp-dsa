namespace VP.DataStructures.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructures.Linear.DynamicArray;

public class IndexOfShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.IndexOf(1);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void ReturnMinus1_WhenTheListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act
		var actualIndex = list.IndexOf(1);

		//Assert
		actualIndex.Should().Be(-1);
	}

	[Theory]
	[InlineData(1)]
	[InlineData(100)]
	[InlineData(Int32.MaxValue)]
	[InlineData(Int32.MinValue)]
	public void ReturnMinus1_WhenTheListIsNotEmpty_AndSpecifiedItemDoesNotExist(Int32 item)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40 };

		//Act
		var actualIndex = list.IndexOf(item);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().Be(list.Count).And.Be(4);
		actualIndex.Should().Be(-1);
	}

	[Theory]
	[InlineData(0, 10)]
	[InlineData(1, 20)]
	[InlineData(2, 30)]
	[InlineData(3, 40)]
	public void ReturnIndexOfTheSpecifiedItem_WhenTheListIsNotEmpty_AndItemExists(
		Int32 expectedIndex,
		Int32 item)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40 };

		//Act
		var actualIndex = list.IndexOf(item);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().Be(list.Count).And.Be(4);
		actualIndex.Should().Be(expectedIndex);
	}
}

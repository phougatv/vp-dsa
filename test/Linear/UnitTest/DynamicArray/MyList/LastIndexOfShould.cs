namespace VP.Dsa.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.Dsa.Linear.DynamicArray;

public class LastIndexOfShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.LastIndexOf(1);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void ReturnMinus1_WhenTheListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act
		var actualIndex = list.LastIndexOf(1);

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
		var actualIndex = list.LastIndexOf(item);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().Be(list.Count).And.Be(4);
		actualIndex.Should().Be(-1);
	}

	[Theory]
	[InlineData(4, 10)]
	[InlineData(5, 20)]
	[InlineData(6, 30)]
	[InlineData(7, 40)]
	public void ReturnTheLastIndexOfTheSpecifiedItem_WhenTheListIsNotEmpty_AndItemExists(
		Int32 expectedIndex,
		Int32 item)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40, 10, 20, 30, 40 };

		//Act
		var actualIndex = list.LastIndexOf(item);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().Be(list.Count).And.Be(8);
		actualIndex.Should().Be(expectedIndex);
	}
}

namespace VP.DataStructures.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructures.Linear.DynamicArray;

public class ContainsShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.Contains(1);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void ReturnFalse_WhenListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act
		var actual = list.Contains(1);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().Be(list.Count).And.Be(0);
		actual.Should().BeFalse();
	}

	[Theory]
	[InlineData(1)]
	[InlineData(100)]
	[InlineData(Int32.MaxValue)]
	[InlineData(Int32.MinValue)]
	public void ReturnFalse_WhenListIsNotEmptyAndTheItemDoesNotExists(Int32 item)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40, 50 };

		//Act
		var actual = list.Contains(item);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(8);
		list.Count.Should().Be(5);
		actual.Should().BeFalse();
	}

	[Theory]
	[InlineData(10)]
	[InlineData(20)]
	[InlineData(30)]
	[InlineData(40)]
	public void ReturnTrue_WhenListIsNotEmptyAndTheItemExists(Int32 item)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40, 50 };

		//Act
		var actual = list.Contains(item);

		//Assert
		list.Should().NotBeNull();
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(8);
		list.Count.Should().Be(5);
		actual.Should().BeTrue();
	}
}

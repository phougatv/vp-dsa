namespace VP.Test.DataStructure.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructure.Linear.DynamicArray;

public class AddShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.Add(1);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void Successfully_AddsTheItemToTheStartOfTheList_WhenListIsEmpty_AndCapacityIsEqualToCount()
	{
		//Arrange
		var list = new MyList();

		//Assert Capacity and Count
		list.Capacity.Should().Be(list.Count).And.Be(0);

		//Act
		list.Add(100);

		//Assert
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(4);
		list.Count.Should().Be(1);
		list[0].Should().Be(100);
	}

	[Fact]
	public void Successfully_AddsTheItemToTheStartOfTheList_WhenListIsEmpty_AndCapacityIsGreaterThanCount()
	{
		//Arrange
		var list = new MyList(2);

		//Assert Capacity and Count
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(2);
		list.Count.Should().Be(0);

		//Act
		list.Add(100);

		//Assert
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(2);
		list.Count.Should().Be(1);
		list[0].Should().Be(100);
	}

	[Fact]
	public void Successfully_AddsTheItemToTheEndOfTheList_WhenListIsNotEmpty_AndCapacityIsEqualToCount()
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40 };

		//Assert Capacity and Count
		list.Capacity.Should().Be(list.Count).And.Be(4);

		//Act
		list.Add(200);

		//Assert
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(8);
		list.Count.Should().Be(5);
		list[^1].Should().Be(200);
	}

	[Fact]
	public void Successfully_AddsTheItemToTheEndOfTheList_WhenListIsNotEmpty_AndCapacityIsGreaterThanCount()
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40, 50 };

		//Assert Capacity and Count
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(8);
		list.Count.Should().Be(5);

		//Act
		list.Add(60);

		//Assert
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(8);
		list.Count.Should().Be(6);
		list[^1].Should().Be(60);
	}
}

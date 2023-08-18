namespace VP.Dsa.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.Dsa.Linear.DynamicArray;

public class CapacityShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();
		
		//Act
		var act_set = () => list.Capacity = 0;
		var act_get = () => list.Capacity;

		//Assert
		act_set.Should().NotThrow<NotImplementedException>();
		act_get.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void BeZero_WhenInitializedUsingParameterlessConstructor_AndListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act & Assert
		list.Capacity.Should().Be(0);
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
	}

	[Fact]
	public void BeTheSpecifiedCapacity_WhenInitializedUsingCapacityConstructor_AndListIsEmpty()
	{
		//Arrange
		var list = new MyList(8);

		//Act & Assert
		list.Capacity.Should().Be(8);
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
	}

	[Fact]
	public void BeFourAsTheDefaultCapacity_WhenTheFirstItemIsAddedToTheEmptyList()
	{
		//Arrange
		var list = new MyList();

		//Assert before and after add
		list.Capacity.Should().Be(0);
		list.Add(10);
		list.Capacity.Should().Be(4);
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(1).And
			.BeEquivalentTo(new Int32[] { 10 }, config => config.WithStrictOrdering());
	}

	[Fact]
	public void DoubleTheDefaultCapacity_WhenCurrentCapacityIsFull_AndNewItemIsBeingAdded()
	{
		//Arrange
		var list = new MyList();

		//Assert before and after add
		list.Capacity.Should().Be(0);
		list.Add(10);
		list.Capacity.Should().Be(4);

		//Add 3 items and then assert
		list.Add(20);
		list.Add(30);
		list.Add(40);
		list.Capacity.Should().Be(4);

		//Add 4th item and then assert
		list.Add(50);
		list.Capacity.Should().Be(8);
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(5).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50 }, config => config.WithStrictOrdering());
	}

	[Fact]
	public void DoubleTheSpecifiedCapacity_WhenCurrentCapacityIsFull_AndNewItemIsBeingAdded()
	{
		//Arrange
		var list = new MyList(3);

		//Assert before and after add
		list.Capacity.Should().Be(3);
		list.Add(10);
		list.Capacity.Should().Be(3);

		//Add 3 items and then assert
		list.Add(20);
		list.Add(30);
		list.Capacity.Should().Be(3);

		//Add 4th item and then assert
		list.Add(40);
		list.Capacity.Should().Be(6);
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(4).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40 }, config => config.WithStrictOrdering());
	}
}

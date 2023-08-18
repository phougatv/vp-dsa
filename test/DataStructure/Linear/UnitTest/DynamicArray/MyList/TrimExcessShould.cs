namespace VP.Test.DataStructure.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructure.Linear.DynamicArray;

public class TrimExcessShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.TrimExcess();

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void NotTrimTheInternalArray_WhenListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act
		list.TrimExcess();

		//Assert
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
		list.Capacity.Should()
			.Be(list.Count).And
			.Be(0);
	}

	[Fact]
	public void NotTrimTheInternalArray_WhenUnusedCapacityIsLessThanOrEqualTo10PercentOfTotalCapacity()
	{
		//Arrange
		var list = new MyList(10) { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

		//Assert before Act
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(9).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }, config => config.WithStrictOrdering());
		list.Capacity.Should()
			.BeGreaterThan(list.Count).And
			.Be(10);

		//Act
		list.TrimExcess();

		//Assert
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(9).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }, config => config.WithStrictOrdering());
		list.Capacity.Should()
			.BeGreaterThan(list.Count).And
			.Be(10);
	}

	[Fact]
	public void TrimTheInternalArray_WhenUnusedCapacityIsGreaterThan10PercentOfTotalCapacity()
	{
		//Arrange
		var listWith70PercentCapacity = new MyList(10) { 10, 20, 30, 40, 50, 60, 70 };
		var listWith80PercentCapacity = new MyList(10) { 10, 20, 30, 40, 50, 60, 70, 80 };

		//Assert before Act
		listWith70PercentCapacity.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(7).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50, 60, 70 }, config => config.WithStrictOrdering());
		listWith70PercentCapacity.Capacity.Should()
			.BeGreaterThan(listWith70PercentCapacity.Count).And
			.Be(10);

		listWith80PercentCapacity.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(8).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50, 60, 70, 80 }, config => config.WithStrictOrdering());
		listWith80PercentCapacity.Capacity.Should()
			.BeGreaterThan(listWith80PercentCapacity.Count).And
			.Be(10);

		//Act
		listWith70PercentCapacity.TrimExcess();
		listWith80PercentCapacity.TrimExcess();

		//Assert
		listWith70PercentCapacity.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(7).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50, 60, 70 }, config => config.WithStrictOrdering()); 
		listWith70PercentCapacity.Capacity.Should()
			.Be(listWith70PercentCapacity.Count).And
			.Be(7);

		listWith80PercentCapacity.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(8).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50, 60, 70, 80 }, config => config.WithStrictOrdering());
		listWith80PercentCapacity.Capacity.Should()
			.Be(listWith80PercentCapacity.Count).And
			.Be(8);
	}
}

namespace VP.Test.DataStructure.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructure.Linear.DynamicArray;

public class CountShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act_get = () => list.Count;

		//Assert
		act_get.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void BeZero_WhenListIsInitializedUsingParameterlessConstructor_AndTheListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act & Assert
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0).And
			.BeEquivalentTo(Array.Empty<Int32>(), config => config.WithStrictOrdering());
		list.Count.Should().Be(0);
		list.Capacity.Should().Be(0);
	}

	[Fact]
	public void BeZero_WhenListIsInitializedUsingCapacityConstructor_AndTheListIsEmpty()
	{
		//Arrange
		var list = new MyList(8);

		//Act & Assert
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0).And
			.BeEquivalentTo(Array.Empty<Int32>(), config => config.WithStrictOrdering());
		list.Count.Should().Be(0);
		list.Capacity.Should().Be(8);
	}

	[Fact]
	public void BeZero_WhenAllTheItemsInTheListAreRemoved()
	{
		//Arrange
		var listWith5Items = new MyList { 10, 20, 30, 40, 50 };
		var listWith1Item = new MyList { 10 };

		//First assert the count of the list
		listWith1Item.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(1).And
			.BeEquivalentTo(new Int32[] { 10 }, config => config.WithStrictOrdering());
		listWith1Item.Capacity.Should().Be(4);
		listWith5Items.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(5).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40, 50 }, config => config.WithStrictOrdering());
		listWith5Items.Capacity.Should().Be(8);

		//Act
		listWith1Item.Remove(10);
		listWith5Items.Remove(10);
		listWith5Items.Remove(20);
		listWith5Items.Remove(30);
		listWith5Items.Remove(40);
		listWith5Items.Remove(50);

		//Final assert
		listWith1Item.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0).And
			.BeEquivalentTo(Array.Empty<Int32>(), config => config.WithStrictOrdering());
		listWith1Item.Capacity.Should().Be(4);
		listWith5Items.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0).And
			.BeEquivalentTo(Array.Empty<Int32>(), config => config.WithStrictOrdering());
		listWith5Items.Capacity.Should().Be(8);
	}

	[Theory]
	[InlineData(5, 5, 8, "10,20,30,40,50")]
	[InlineData(4, 4, 4, "10,20,30,40")]
	[InlineData(3, 3, 4, "10,20,30")]
	[InlineData(2, 2, 4, "10,20")]
	[InlineData(1, 1, 4, "10")]
	public void BeEqualToTheNumberOfItemsThatExistsInTheList_WhenItemsAreAddedToTheList(
		Int32 numberOfItemsToBeAdded,
		Int32 expectedCount,
		Int32 expectedCapacity,
		String expectedStrings)
	{
		//Arrange
		var expectedItems = Array.ConvertAll(expectedStrings.Split(','), Int32.Parse);
		var list = new MyList();

		//Act
		for (var i = 0; i < numberOfItemsToBeAdded; i++)
		{
			list.Add((i + 1) * 10);
		}

		//Assert
		list.Should()
			.NotBeNull().And
			.HaveCount(expectedCount).And
			.BeEquivalentTo(expectedItems, config => config.WithStrictOrdering());
		list.Count.Should()
			.Be(expectedCount);
		list.Capacity.Should()
			.Be(expectedCapacity);
	}

	[Theory]
	[InlineData(0, 5, "10,20,30,40,50")]
	[InlineData(1, 4, "20,30,40,50")]
	[InlineData(2, 3, "30,40,50")]
	[InlineData(3, 2, "40,50")]
	[InlineData(4, 1, "50")]
	public void BeEqualToTheNumberOfItemsThatExistsInTheList_WhenItemsAreRemovedFromTheList(
		Int32 numberOfItemsToBeRemoved,
		Int32 expectedCount,
		String expectedStrings)
	{
		//Arrange
		var expectedItems = Array.ConvertAll(expectedStrings.Split(','), Int32.Parse);
		var list = new MyList { 10, 20, 30, 40, 50 };

		//Act
		for (var i = 0; i < numberOfItemsToBeRemoved; numberOfItemsToBeRemoved--)
		{
			list.RemoveAt(i);
		}

		//Assert
		list.Should()
			.NotBeNull().And
			.HaveCount(expectedCount).And
			.BeEquivalentTo(expectedItems, config => config.WithStrictOrdering());
		list.Count.Should()
			.Be(expectedCount);
		list.Capacity.Should()
			.Be(8);
	}
}

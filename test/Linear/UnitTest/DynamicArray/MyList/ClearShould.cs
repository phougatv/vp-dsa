namespace VP.DataStructures.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructures.Linear.DynamicArray;

public class ClearShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.Clear();

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void SuccessfullySetsTheCountToZero_AndClearsTheList_WhenListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act
		list.Clear();

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
	public void SuccessfullySetsTheCountToZero_AndClearsTheList_WhenListIsNotEmpty()
	{
		//Arrange
		var list_1 = new MyList { 10, 20, 30, 40 };
		var list_2 = new MyList(8) { 10, 20, 30, 40 };

		//Assert before Act
		list_1.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(4).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40 }, config => config.WithStrictOrdering());
		list_1.Capacity.Should()
			.Be(list_1.Count).And
			.Be(4);
		list_2.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(4).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40 }, config => config.WithStrictOrdering());
		list_2.Capacity.Should()
			.BeGreaterThan(list_2.Count).And
			.Be(8);

		//Act
		list_1.Clear();
		list_2.Clear();

		//Assert
		list_1.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
		list_1.Capacity.Should()
			.BeGreaterThan(list_1.Count).And
			.Be(4);
		list_2.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
		list_2.Capacity.Should()
			.BeGreaterThan(list_2.Count).And
			.Be(8);
	}
}

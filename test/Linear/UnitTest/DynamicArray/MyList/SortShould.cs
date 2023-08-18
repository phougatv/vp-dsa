namespace VP.DataStructures.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructures.Linear.DynamicArray;

public class SortShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.Sort();

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void DoNothing_WhenListIsEmpty()
	{
		//Arrange
		var list = new MyList();

		//Act
		list.Sort();

		//Assert
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
		list.Capacity.Should().Be(list.Count).And.Be(0);
	}

	[Fact]
	public void DoNothing_WhenListHasSingelItem()
	{
		//Arrange
		var list = new MyList { 10 };

		//Act
		list.Sort();

		//Assert
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(1).And
			.BeEquivalentTo(new Int32[] { 10 }, config => config.WithStrictOrdering());
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(4);
		list[0].Should().Be(10);
	}

	[Fact]
	public void SuccessfullySort_WhenListHasMultipleItems()
	{
		//Arrange
		var list_1 = new MyList { 20, 40, 30, 10 };
		var list_2 = new MyList { -10, Int32.MinValue, Int32.MaxValue, 100, 60 };

		//Act
		list_1.Sort();
		list_2.Sort();

		//Assert
		list_1.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(4).And
			.BeEquivalentTo(new Int32[] { 10, 20, 30, 40 }, config => config.WithStrictOrdering());
		list_1.Capacity.Should()
			.Be(list_1.Count).And
			.Be(4);

		list_2.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(5).And
			.BeEquivalentTo(new Int32[] { Int32.MinValue, -10, 60, 100, Int32.MaxValue }, config => config.WithStrictOrdering());
		list_2.Capacity.Should()
			.BeGreaterThan(list_2.Count).And
			.Be(8);
	}
}

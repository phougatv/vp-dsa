namespace VP.Test.DataStructure.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructure.Linear.DynamicArray;

public class RemoveShould
{
	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.Remove(1);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Theory]
	[InlineData(1)]
	[InlineData(100)]
	[InlineData(Int32.MaxValue)]
	[InlineData(Int32.MinValue)]
	public void ReturnFalse_WhenListIsEmpty(Int32 item)
	{
		//Arrange
		var list = new MyList();

		//Act
		var actual = list.Remove(item);

		//Assert
		actual.Should().BeFalse();
	}

	[Theory]
	[InlineData(1, new Int32[] { 10, 20, 30, 40 })]
	[InlineData(100, new Int32[] { 10, 20, 30, 40 })]
	[InlineData(Int32.MaxValue, new Int32[] { 10, 20, 30, 40 })]
	[InlineData(Int32.MinValue, new Int32[] { 10, 20, 30, 40 })]
	public void ReturnFalse_WhenListIsNotEmpty_AndSpecifiedItemDoesNotExists(
		Int32 item,
		Int32[] expectedList)
	{
		//Arrange
		var actualList = new MyList { 10, 20, 30, 40 };

		//Act
		var actual = actualList.Remove(item);

		//Assert
		actualList.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		actualList.Capacity.Should().Be(expectedList.Length).And.Be(4);
		actual.Should().BeFalse();
	}

	[Theory]
	[InlineData(10, new[] { 20, 30, 40 })]
	[InlineData(20, new[] { 10, 30, 40 })]
	[InlineData(30, new[] { 10, 20, 40 })]
	[InlineData(40, new[] { 10, 20, 30 })]
	public void ReturnTrue_AfterSuccessfullyRemovingTheItem_WhenItemHasSingleOccurenceInTheList(
		Int32 item,
		Int32[] expectedList)
	{
		//Arrange
		var actualList = new MyList { 10, 20, 30, 40 };

		//Act
		var actual = actualList.Remove(item);

		//Assert
		actualList.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		actualList.Capacity.Should().Be(4);
		actual.Should().BeTrue();
	}

	[Fact]
	public void ReturnTrue_AfterSuccessfullyRemovingTheFirstOccurenceOfTheItem_WhenItemHasMultipleOccurencesInTheList()
	{
		//Arrange
		var expectedList = new Int32[] { 10, 20, 30, 40 };
		var list_1 = new MyList { 10, 20, 30, 40, 40 };
		var list_2 = new MyList { 10, 20, 30, 30, 40 };
		var list_3 = new MyList { 10, 20, 20, 30, 40 };
		var list_4 = new MyList { 10, 10, 20, 30, 40 };

		//Act
		var actual_1 = list_1.Remove(40);
		var actual_2 = list_2.Remove(30);
		var actual_3 = list_3.Remove(20);
		var actual_4 = list_4.Remove(10);

		//Assert
		list_1.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		list_1.Capacity.Should().Be(8);
		actual_1.Should().BeTrue();

		list_2.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		list_2.Capacity.Should().Be(8);
		actual_2.Should().BeTrue();

		list_3.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		list_3.Capacity.Should().Be(8);
		actual_3.Should().BeTrue();

		list_4.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		list_4.Capacity.Should().Be(8);
		actual_4.Should().BeTrue();
	}
}
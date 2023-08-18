namespace VP.DataStructure.Test.Linear.UnitTest.DynamicArray.MyList;

using VP.DataStructure.Linear.DynamicArray;

public class RemoveAtShould
{
	#region Private Constants
	private const String ArgumentOutOfRangeException = "Specified argument was out of the range of valid values. (Parameter 'index')";
	#endregion

	[Fact]
	public void NotThrowNotImplementedException()
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.RemoveAt(1);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(Int32.MinValue)]
	public void ThrowArgumentOutOfRangeException_WhenIndexIsNegative(Int32 index)
	{
		//Arrange
		var list_1 = new MyList();
		var list_2 = new MyList { 10, 20, 30 };

		//Act
		var act_1 = () => list_1.RemoveAt(index);
		var act_2 = () => list_2.RemoveAt(index);

		//Assert
		act_1.Should()
			.Throw<ArgumentOutOfRangeException>()
			.WithMessage(ArgumentOutOfRangeException)
			.WithParameterName(nameof(index));
		act_2.Should()
			.Throw<ArgumentOutOfRangeException>()
			.WithMessage(ArgumentOutOfRangeException)
			.WithParameterName(nameof(index));
	}

	[Theory]
	[InlineData(0)]
	[InlineData(10)]
	[InlineData(Int32.MaxValue)]
	public void ThrowArgumentOutOfRangeException_WhenTheListIsEmpty(Int32 index)
	{
		//Arrange
		var list = new MyList();

		//Act
		var act = () => list.RemoveAt(index);

		//Assert
		act.Should().
			Throw<ArgumentOutOfRangeException>()
			.WithMessage(ArgumentOutOfRangeException)
			.WithParameterName(nameof(index));
		list.Should()
			.NotBeNull().And
			.BeEmpty().And
			.HaveCount(0);
		list.Capacity.Should().Be(list.Count).And.Be(0);
	}

	[Theory]
	[InlineData(4, new[] { 10, 20, 30, 40 })]
	[InlineData(100, new[] { 10, 20, 30, 40 })]
	[InlineData(Int32.MaxValue, new[] { 10, 20, 30, 40 })]
	public void ThrowArgumentOutOfRangeException_WhenTheListIsNotEmpty_AndSpecifiedIndexIsGreaterThanEqualToCount(
		Int32 index,
		Int32[] expectedList)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40 };

		//Act
		var act = () => list.RemoveAt(index);

		//Assert
		act.Should().
			Throw<ArgumentOutOfRangeException>()
			.WithMessage(ArgumentOutOfRangeException)
			.WithParameterName(nameof(index));
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		list.Capacity.Should().Be(list.Count).And.Be(4);
	}

	[Theory]
	[InlineData(0, new[] { 20, 30, 40 })]
	[InlineData(1, new[] { 10, 30, 40 })]
	[InlineData(2, new[] { 10, 20, 40 })]
	[InlineData(3, new[] { 10, 20, 30 })]
	public void SuccessfullyRemovesTheItem_WhenTheListIsNotEmpty_AndSpecifiedIndexIsInBounds(
		Int32 index,
		Int32[] expectedList)
	{
		//Arrange
		var list = new MyList { 10, 20, 30, 40 };

		//Act
		list.RemoveAt(index);

		//Assert
		list.Should()
			.NotBeNullOrEmpty().And
			.HaveCount(expectedList.Length).And
			.BeEquivalentTo(expectedList, config => config.WithStrictOrdering());
		list.Capacity.Should().BeGreaterThan(list.Count).And.Be(4);
	}
}

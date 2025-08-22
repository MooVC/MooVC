namespace MooVC.ArrayExtensionsTests;

public sealed class WhenPrependIsCalled
{
    [Fact]
    public void GivenANullValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Prepend(default);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenNoValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Prepend();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenNoValueWhenTheSourceIsEmptyThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = [];

        // Act
        int[] result = original.Prepend();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenNoValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheOriginalElementsWithin()
    {
        // Arrange
        int[]? original = [1, 2, 3, 4, 5];

        // Act
        int[] result = original.Prepend();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ShouldBe(original);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[]? original = default;
        int expected = 5;

        // Act
        int[] result = original.Prepend(expected);

        // Assert
        result.ShouldHaveSingleItem().ShouldBe(expected);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[] original = [];
        int expected = 1;

        // Act
        int[] result = original.Prepend(expected);

        // Assert
        result.ShouldHaveSingleItem().ShouldBe(expected);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementAtTheStart()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] expected = [4, 1, 2, 3];
        int value = 4;

        // Act
        int[] actual = original.Prepend(value);

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementAtTheStart()
    {
        // Arrange
        int[] original = [1, 1, 1];
        int[] expected = [1, 1, 1, 1];
        int value = 1;

        // Act
        int[] actual = original.Prepend(value);

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenMutipleValuesWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[]? original = default;
        int[] expected = [5, 6, 7];

        // Act
        int[] result = original.Prepend(expected);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultipleValuesWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[] original = [];
        int[] expected = [3, 5, 7];

        // Act
        int[] result = original.Prepend(expected);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultipleValuesWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementsAtTheStart()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] others = [4, 5, 6];
        int[] expected = [4, 5, 6, 1, 2, 3];

        // Act
        int[] actual = original.Prepend(others);

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultipleValuesWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementsAtTheStart()
    {
        // Arrange
        int[] original = [1, 2, 1];
        int[] others = [1, 2, 1];
        int[] expected = [1, 2, 1, 1, 2, 1];

        // Act
        int[] actual = original.Prepend(others);

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenTheSameValuesAsTheSourceWhenTheSourceHasMultipleElementsThenAnArrayIsReturnedWithTheSourceDuplicated()
    {
        // Arrange
        int[] original = [2, 1, 2];
        int[] expected = [2, 1, 2, 2, 1, 2];

        // Act
        int[] actual = original.Prepend(original);

        // Assert
        actual.ShouldBe(expected);
    }
}
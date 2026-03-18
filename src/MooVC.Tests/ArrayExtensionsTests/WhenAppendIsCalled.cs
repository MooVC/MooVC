namespace MooVC.ArrayExtensionsTests;

public sealed class WhenAppendIsCalled
{
    [Test]
    public void GivenANullValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Append(default);

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenNoValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Append();

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenNoValueWhenTheSourceIsEmptyThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = [];

        // Act
        int[] result = original.Append();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenNoValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheOriginalElementsWithin()
    {
        // Arrange
        int[]? original = [1, 2, 3, 4, 5];

        // Act
        int[] result = original.Append();

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ShouldBe(original);
    }

    [Test]
    public void GivenASingleValueWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[]? original = default;
        int expected = 5;

        // Act
        int[] result = original.Append(expected);

        // Assert
        result.ShouldHaveSingleItem().ShouldBe(expected);
    }

    [Test]
    public void GivenASingleValueWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[] original = [];
        int expected = 1;

        // Act
        int[] result = original.Append(expected);

        // Assert
        result.ShouldHaveSingleItem().ShouldBe(expected);
    }

    [Test]
    public void GivenASingleValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] expected = [1, 2, 3, 4];
        int value = 4;

        // Act
        int[] actual = original.Append(value);

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    public void GivenASingleValueWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementAtTheEnd()
    {
        // Arrange
        int[] original = [1, 1, 1];
        int[] expected = [1, 1, 1, 1];
        int value = 1;

        // Act
        int[] actual = original.Append(value);

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    public void GivenMutipleValuesWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[]? original = default;
        int[] expected = [5, 6, 7];

        // Act
        int[] result = original.Append(expected);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenMultipleValuesWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[] original = [];
        int[] expected = [3, 5, 7];

        // Act
        int[] result = original.Append(expected);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenMultipleValuesWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementsAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] others = [4, 5, 6];
        int[] expected = [1, 2, 3, 4, 5, 6];

        // Act
        int[] actual = original.Append(others);

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    public void GivenMultipleValuesWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementsAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 1];
        int[] others = [1, 2, 1];
        int[] expected = [1, 2, 1, 1, 2, 1];

        // Act
        int[] actual = original.Append(others);

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    public void GivenTheSameValuesAsTheSourceWhenTheSourceHasMultipleElementsThenAnArrayIsReturnedWithTheSourceDuplicated()
    {
        // Arrange
        int[] original = [2, 1, 2];
        int[] expected = [2, 1, 2, 2, 1, 2];

        // Act
        int[] actual = original.Append(original);

        // Assert
        actual.ShouldBe(expected);
    }
}
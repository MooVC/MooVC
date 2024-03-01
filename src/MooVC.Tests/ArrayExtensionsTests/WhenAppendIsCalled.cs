namespace MooVC.ArrayExtensionsTests;

public sealed class WhenAppendIsCalled
{
    [Fact]
    public void GivenANullValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Append(default);

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void GivenNoValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Append();

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void GivenNoValueWhenTheSourceIsEmptyThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = [];

        // Act
        int[] result = original.Append();

        // Assert
        _ = result.Should().NotBeSameAs(original);
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void GivenNoValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheOriginalElementsWithin()
    {
        // Arrange
        int[]? original = [1, 2, 3, 4, 5];

        // Act
        int[] result = original.Append();

        // Assert
        _ = result.Should().NotBeSameAs(original);
        _ = result.Should().BeEquivalentTo(original);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[]? original = default;
        int expected = 5;

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = result.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[] original = [];
        int expected = 1;

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = result.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] expected = [1, 2, 3, 4];
        int value = 4;

        // Act
        int[] actual = original.Append(value);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenASingleValueWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementAtTheEnd()
    {
        // Arrange
        int[] original = [1, 1, 1];
        int[] expected = [1, 1, 1, 1];
        int value = 1;

        // Act
        int[] actual = original.Append(value);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenMutipleValuesWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[]? original = default;
        int[] expected = [5, 6, 7];

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenMultipleValuesWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[] original = [];
        int[] expected = [3, 5, 7];

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenMultipleValuesWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementsAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] others = [4, 5, 6];
        int[] expected = [1, 2, 3, 4, 5, 6];

        // Act
        int[] actual = original.Append(others);

        // Assert
        _ = actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenMultipleValuesWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementsAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 1];
        int[] others = [1, 2, 1];
        int[] expected = [1, 2, 1, 1, 2, 1];

        // Act
        int[] actual = original.Append(others);

        // Assert
        _ = actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenTheSameValuesAsTheSourceWhenTheSourceHasMultipleElementsThenAnArrayIsReturnedWithTheSourceDuplicated()
    {
        // Arrange
        int[] original = [2, 1, 2];
        int[] expected = [2, 1, 2, 2, 1, 2];

        // Act
        int[] actual = original.Append(original);

        // Assert
        _ = actual.Should().BeEquivalentTo(expected);
    }
}
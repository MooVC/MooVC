namespace MooVC.ArrayExtensionsTests;

public sealed class WhenAppendIsCalled
{
    [Test]
    public async Task GivenANullValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Append(default);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenNoValueWhenTheSourceIsNullThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = default;

        // Act
        int[] result = original.Append();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenNoValueWhenTheSourceIsEmptyThenAnEmptyArrayIsReturned()
    {
        // Arrange
        int[]? original = [];

        // Act
        int[] result = original.Append();

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenNoValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheOriginalElementsWithin()
    {
        // Arrange
        int[]? original = [1, 2, 3, 4, 5];

        // Act
        int[] result = original.Append();

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result).IsEquivalentTo(original);
    }

    [Test]
    public async Task GivenASingleValueWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[]? original = default;
        int expected = 5;

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = await Assert.That(result.Single()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenASingleValueWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[] original = [];
        int expected = 1;

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = await Assert.That(result.Single()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenASingleValueWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] expected = [1, 2, 3, 4];
        int value = 4;

        // Act
        int[] actual = original.Append(value);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenASingleValueWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementAtTheEnd()
    {
        // Arrange
        int[] original = [1, 1, 1];
        int[] expected = [1, 1, 1, 1];
        int value = 1;

        // Act
        int[] actual = original.Append(value);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenMutipleValuesWhenTheSourceIsNullThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[]? original = default;
        int[] expected = [5, 6, 7];

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenMultipleValuesWhenTheSourceIsEmptyThenAnArrayIsReturnedWithTheElementsWithin()
    {
        // Arrange
        int[] original = [];
        int[] expected = [3, 5, 7];

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenMultipleValuesWhenTheSourceIsPopulatedThenAnArrayIsReturnedWithTheElementsAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 3];
        int[] others = [4, 5, 6];
        int[] expected = [1, 2, 3, 4, 5, 6];

        // Act
        int[] actual = original.Append(others);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenMultipleValuesWhenTheSourceHasMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementsAtTheEnd()
    {
        // Arrange
        int[] original = [1, 2, 1];
        int[] others = [1, 2, 1];
        int[] expected = [1, 2, 1, 1, 2, 1];

        // Act
        int[] actual = original.Append(others);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenTheSameValuesAsTheSourceWhenTheSourceHasMultipleElementsThenAnArrayIsReturnedWithTheSourceDuplicated()
    {
        // Arrange
        int[] original = [2, 1, 2];
        int[] expected = [2, 1, 2, 2, 1, 2];

        // Act
        int[] actual = original.Append(original);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }
}
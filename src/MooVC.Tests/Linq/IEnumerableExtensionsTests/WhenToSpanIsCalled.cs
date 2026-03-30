namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    [Test]
    public async Task GivenANullEnumerableThenAnEmptySpanIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumerable = default;

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenAnArrayThenASpanContainingTheElementsOfTheArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3];

        // Act
        int[] actual = [.. enumerable.ToSpan()];

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo([1, 2, 3]);
    }

    [Test]
    public async Task GivenAnEmptyEnumerableThenAnEmptySpanIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [];

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenAnEnumerableThenASpanContainingTheElementsOfTheEnumerableIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = new List<int> { 3, 2, 1 };

        // Act
        int[] actual = [.. enumerable.ToSpan()];

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo([3, 2, 1]);
    }

    [Test]
    public async Task GivenAnEnumerableThenTheSpanLengthShouldMatchEnumerableCount()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3, 4];

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.Length).IsEqualTo(enumerable.Count());
    }

    [Test]
    public async Task GivenAListWhenTheListMutatesAfterToSpanIsCalledThenTheSpanValuesRemainUnchanged()
    {
        // Arrange
        List<int> source = [1, 2, 3];

        // Act
        ReadOnlySpan<int> span = source.ToSpan();
        source[0] = 99;
        int[] actual = [.. span];

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo([1, 2, 3]);
    }
}
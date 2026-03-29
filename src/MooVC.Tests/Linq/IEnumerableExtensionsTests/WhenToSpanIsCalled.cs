namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    public static IEnumerable<IEnumerable<int>?> EmptyEnumerableTestData()
    {
        yield return default;
        yield return [];
    }

    public static IEnumerable<IEnumerable<int>> EnumerableTestData()
    {
        yield return [];
        yield return [1, 2, 3];
        yield return [2];
        yield return [3, 2, 1];
    }

    [Test]
    [MethodDataSource(nameof(EmptyEnumerableTestData))]
    public async Task GivenAnEmptyEnumerableThenAnEmptySpanIsReturned(IEnumerable<int>? enumerable)
    {
        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.IsEmpty).IsTrue();
    }

    [Test]
    [MethodDataSource(nameof(EnumerableTestData))]
    public async Task GivenAnEnumerableThenASpanContainingTheElementsOfTheEnumerableIsReturned(IEnumerable<int> expected)
    {
        // Act
        int[] actual = [.. expected.ToSpan()];

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo([.. expected]);
    }

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
    public async Task GivenAnEnumerableThenTheSpanLengthShouldMatchEnumerableCount()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3, 4];

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.Length).IsEqualTo(enumerable.Count());
    }
}
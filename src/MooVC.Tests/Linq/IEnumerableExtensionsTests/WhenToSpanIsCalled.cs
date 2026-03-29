namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    public static IEnumerable<object?[]> EmptyEnumerableTestData()
    {
        yield return [default(int[])];
        yield return [Array.Empty<int>()];
    }

    public static IEnumerable<object?[]> EnumerableTestData()
    {
        yield return [Array.Empty<int>()];
        yield return [new[] { 1, 2, 3 }];
        yield return [new[] { 2 }];
        yield return [new[] { 3, 2, 1 }];
    }

    [Test]
    [MethodDataSource(nameof(EmptyEnumerableTestData))]
    public async Task GivenAnEmptyEnumerableThenAnEmptySpanIsReturned(int[]? source)
    {
        // Arrange
        IEnumerable<int>? enumerable = source;

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.IsEmpty).IsTrue();
    }

    [Test]
    [MethodDataSource(nameof(EnumerableTestData))]
    public async Task GivenAnEnumerableThenASpanContainingTheElementsOfTheEnumerableIsReturned(int[] source)
    {
        // Arrange
        IEnumerable<int> enumerable = source;

        // Act
        int[] actual = [.. enumerable.ToSpan()];

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo([.. enumerable]);
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
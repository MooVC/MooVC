namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    public static IEnumerable<object?[]> EmptyEnumerableTestData()
    {
        yield return [default(IEnumerable<int>)];
        yield return [(object)Array.Empty<int>()];
    }

    public static IEnumerable<object?[]> EnumerableTestData()
    {
        yield return [(object)Array.Empty<int>()];
        yield return [(object)new[] { 1, 2, 3 }];
        yield return [(object)new[] { 2 }];
        yield return [(object)new[] { 3, 2, 1 }];
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
namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    [Test]
    [Arguments(default)]
    [Arguments(new int[0])]
    public async Task GivenAnEmptyEnumerableThenAnEmptySpanIsReturned(IEnumerable<int>? enumerable)
    {
        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        _ = await Assert.That(actual.IsEmpty).IsTrue();
    }

    [Test]
    [Arguments(new int[0])]
    [Arguments(new[] { 1, 2, 3 })]
    [Arguments(new[] { 2 })]
    [Arguments(new[] { 3, 2, 1 })]
    public async Task GivenAnEnumerableThenASpanContainingTheElementsOfTheEnumerableIsReturned(IEnumerable<int> expected)
    {
        // Act
        ReadOnlySpan<int> actual = expected.ToSpan();

        // Assert
        for (int index = 0; index < expected.Count(); index++)
        {
            _ = await Assert.That(actual[index]).IsEqualTo(expected.ElementAt(index));
        }
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
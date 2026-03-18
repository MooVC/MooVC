namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    [Test]
    [Arguments(default)]
    [Arguments(new int[0])]
    public void GivenAnEmptyEnumerableThenAnEmptySpanIsReturned(IEnumerable<int>? enumerable)
    {
        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        actual.IsEmpty.ShouldBeTrue();
    }

    [Test]
    [Arguments(new int[0])]
    [Arguments(new[] { 1, 2, 3 })]
    [Arguments(new[] { 2 })]
    [Arguments(new[] { 3, 2, 1 })]
    public void GivenAnEnumerableThenASpanContainingTheElementsOfTheEnumerableIsReturned(IEnumerable<int> expected)
    {
        // Act
        ReadOnlySpan<int> actual = expected.ToSpan();

        // Assert
        for (int index = 0; index < expected.Count(); index++)
        {
            actual[index].ShouldBe(expected.ElementAt(index));
        }
    }

    [Test]
    public void GivenANullEnumerableThenAnEmptySpanIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumerable = default;

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        actual.IsEmpty.ShouldBeTrue();
    }

    [Test]
    public void GivenAnEnumerableThenTheSpanLengthShouldMatchEnumerableCount()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3, 4];

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        actual.Length.ShouldBe(enumerable.Count());
    }
}
namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToSpanIsCalled
{
    [Theory]
    [InlineData(default)]
    [InlineData(new int[0])]
    public void GivenAnEmptyEnumerableThenAnEmptySpanIsReturned(IEnumerable<int>? enumerable)
    {
        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        actual.IsEmpty.ShouldBeTrue();
    }

    [Theory]
    [InlineData(new int[0])]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new[] { 2 })]
    [InlineData(new[] { 3, 2, 1 })]
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

    [Fact]
    public void GivenANullEnumerableThenAnEmptySpanIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumerable = null;

        // Act
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        // Assert
        actual.IsEmpty.ShouldBeTrue();
    }

    [Fact]
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
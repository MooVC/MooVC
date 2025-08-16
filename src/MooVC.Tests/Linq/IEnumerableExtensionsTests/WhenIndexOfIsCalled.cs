namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIndexOfIsCalled
{
    [Fact]
    public void GivenAListWhenAPredicateThatYeildsNoMatchingEntryThenNegativeOneIsReturned()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];

        // Act
        int actualIndex = enumeration.IndexOf(item => item == 4);

        // Assert
        actualIndex.ShouldBe(-1);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2, 1)]
    [InlineData(new[] { -1, -2, -3 }, -3, 2)]
    [InlineData(new[] { 1, 2, 3 }, 1, 0)]
    public void GivenAListWhenAPredicateThatYieldsOneMatchingEntryThenTheIndexOfTheMatchingEntryIsReturned(int[] enumeration, int target, int expectedIndex)
    {
        // Act
        int actualIndex = enumeration.IndexOf(item => item == target);

        // Assert
        actualIndex.ShouldBe(expectedIndex);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 2 }, 2, 1)]
    [InlineData(new[] { -1, -2, -1 }, -1, 0)]
    [InlineData(new[] { 1, 1, 1 }, 1, 0)]
    public void GivenAListWhenAPredicateThatYieldsTwoMatchingEntriesThenTheIndexOfTheFirstMatchingEntryIsReturned(
        int[] enumeration,
        int target,
        int expectedIndex)
    {
        // Act
        int actualIndex = enumeration.IndexOf(item => item == target);

        // Assert
        actualIndex.ShouldBe(expectedIndex);
    }

    [Fact]
    public void GivenAListWhenNoPredicateIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Func<int, bool>? predicate = default;

        // Act
        Action act = () => enumeration.IndexOf(predicate!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(predicate));
    }

    [Fact]
    public void GivenANullListWhenAPredicateIsProvidedThenNegativeOneIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        int actualIndex = enumeration.IndexOf(item => item == 4);

        // Assert
        actualIndex.ShouldBe(-1);
    }

    [Fact]
    public void GivenANullListWhenNoPredicateIsProvidedThenNegativeOneIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        int actualIndex = enumeration.IndexOf(default!);

        // Assert
        actualIndex.ShouldBe(-1);
    }

    [Fact]
    public void GivenAListContainingNullsWhenAPredicateForNullIsProvidedThenTheIndexOfTheFirstNullIsReturned()
    {
        // Arrange
        int?[] enumeration = [1, null, 3];

        // Act
        int actualIndex = enumeration.IndexOf(item => item == null);

        // Assert
        actualIndex.ShouldBe(1);
    }
}
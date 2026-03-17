namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIndexOfIsCalled
{
    [Test]
    public void GivenAListWhenAPredicateThatYeildsNoMatchingEntryThenNegativeOneIsReturned()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];

        // Act
        int actualIndex = enumeration.IndexOf(item => item == 4);

        // Assert
        actualIndex.ShouldBe(-1);
    }

    [Test]
    [Arguments(new[] { 1, 2, 3 }, 2, 1)]
    [Arguments(new[] { -1, -2, -3 }, -3, 2)]
    [Arguments(new[] { 1, 2, 3 }, 1, 0)]
    public void GivenAListWhenAPredicateThatYieldsOneMatchingEntryThenTheIndexOfTheMatchingEntryIsReturned(int[] enumeration, int target, int expectedIndex)
    {
        // Act
        int actualIndex = enumeration.IndexOf(item => item == target);

        // Assert
        actualIndex.ShouldBe(expectedIndex);
    }

    [Test]
    [Arguments(new[] { 1, 2, 2 }, 2, 1)]
    [Arguments(new[] { -1, -2, -1 }, -1, 0)]
    [Arguments(new[] { 1, 1, 1 }, 1, 0)]
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

    [Test]
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

    [Test]
    public void GivenANullListWhenAPredicateIsProvidedThenNegativeOneIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        int actualIndex = enumeration.IndexOf(item => item == 4);

        // Assert
        actualIndex.ShouldBe(-1);
    }

    [Test]
    public void GivenANullListWhenNoPredicateIsProvidedThenNegativeOneIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        int actualIndex = enumeration.IndexOf(default!);

        // Assert
        actualIndex.ShouldBe(-1);
    }

    [Test]
    public void GivenAListContainingNullsWhenAPredicateForNullIsProvidedThenTheIndexOfTheFirstNullIsReturned()
    {
        // Arrange
        int?[] enumeration = [1, null, 3];

        // Act
        int actualIndex = enumeration.IndexOf(item => item == default);

        // Assert
        actualIndex.ShouldBe(1);
    }
}
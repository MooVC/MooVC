namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIndexOfIsCalled
{
    [Test]
    public async Task GivenAListContainingNullsWhenAPredicateForNullIsProvidedThenTheIndexOfTheFirstNullIsReturned()
    {
        // Arrange
        int?[] enumeration = [1, null, 3];

        // Act
        int actualIndex = enumeration.IndexOf(item => item == default);

        // Assert
        _ = await Assert.That(actualIndex).IsEqualTo(1);
    }

    [Test]
    public async Task GivenAListWhenAPredicateThatYeildsNoMatchingEntryThenNegativeOneIsReturned()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];

        // Act
        int actualIndex = enumeration.IndexOf(item => item == 4);

        // Assert
        _ = await Assert.That(actualIndex).IsEqualTo(-1);
    }

    [Test]
    [Arguments(new[] { 1, 2, 3 }, 2, 1)]
    [Arguments(new[] { -1, -2, -3 }, -3, 2)]
    [Arguments(new[] { 1, 2, 3 }, 1, 0)]
    public async Task GivenAListWhenAPredicateThatYieldsOneMatchingEntryThenTheIndexOfTheMatchingEntryIsReturned(int[] enumeration, int target, int expectedIndex)
    {
        // Act
        int actualIndex = enumeration.IndexOf(item => item == target);

        // Assert
        _ = await Assert.That(actualIndex).IsEqualTo(expectedIndex);
    }

    [Test]
    [Arguments(new[] { 1, 2, 2 }, 2, 1)]
    [Arguments(new[] { -1, -2, -1 }, -1, 0)]
    [Arguments(new[] { 1, 1, 1 }, 1, 0)]
    public async Task GivenAListWhenAPredicateThatYieldsTwoMatchingEntriesThenTheIndexOfTheFirstMatchingEntryIsReturned(
        int[] enumeration,
        int target,
        int expectedIndex)
    {
        // Act
        int actualIndex = enumeration.IndexOf(item => item == target);

        // Assert
        _ = await Assert.That(actualIndex).IsEqualTo(expectedIndex);
    }

    [Test]
    public async Task GivenAListWhenNoPredicateIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Func<int, bool>? predicate = default;

        // Act
        Action act = () => enumeration.IndexOf(predicate!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(predicate));
    }

    [Test]
    public async Task GivenANullListWhenAPredicateIsProvidedThenNegativeOneIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        int actualIndex = enumeration.IndexOf(item => item == 4);

        // Assert
        _ = await Assert.That(actualIndex).IsEqualTo(-1);
    }

    [Test]
    public async Task GivenANullListWhenNoPredicateIsProvidedThenNegativeOneIsReturned()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        int actualIndex = enumeration.IndexOf(default!);

        // Assert
        _ = await Assert.That(actualIndex).IsEqualTo(-1);
    }
}
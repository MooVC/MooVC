namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenHasAnyIsCalled
{
    [Test]
    public async Task GivenAnEmptySourceThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool hasAny = source.HasAny();

        // Assert
        await Assert.That(hasAny).IsFalse();
    }

    [Test]
    public async Task GivenAnEmptySourceAndAPredicateThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool hasAny = source.HasAny(predicate => true);

        // Assert
        await Assert.That(hasAny).IsFalse();
    }

    [Test]
    public async Task GivenAnPopulatedSourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool hasAny = source.HasAny();

        // Assert
        await Assert.That(hasAny).IsTrue();
    }

    [Test]
    public async Task GivenAnPopulatedSourceWithMultipleElementsThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool hasAny = source.HasAny();

        // Assert
        await Assert.That(hasAny).IsTrue();
    }

    [Test]
    public async Task GivenAnPopulatedSourceAndAFailingPredicateThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool hasAny = source.HasAny(predicate => false);

        // Assert
        await Assert.That(hasAny).IsFalse();
    }

    [Test]
    public async Task GivenAnPopulatedSourceAndAPassingPredicateThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool hasAny = source.HasAny(predicate => true);

        // Assert
        await Assert.That(hasAny).IsTrue();
    }

    [Test]
    public async Task GivenANullSourceThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool hasAny = source.HasAny();

        // Assert
        await Assert.That(hasAny).IsFalse();
    }

    [Test]
    public async Task GivenANullSourceAndAPredicateThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool hasAny = source.HasAny(predicate => true);

        // Assert
        await Assert.That(hasAny).IsFalse();
    }
}
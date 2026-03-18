namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenHasAnyIsCalled
{
    [Test]
    public void GivenAnEmptySourceThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool hasAny = source.HasAny();

        // Assert
        hasAny.ShouldBeFalse();
    }

    [Test]
    public void GivenAnEmptySourceAndAPredicateThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool hasAny = source.HasAny(predicate => true);

        // Assert
        hasAny.ShouldBeFalse();
    }

    [Test]
    public void GivenAnPopulatedSourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool hasAny = source.HasAny();

        // Assert
        hasAny.ShouldBeTrue();
    }

    [Test]
    public void GivenAnPopulatedSourceWithMultipleElementsThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool hasAny = source.HasAny();

        // Assert
        hasAny.ShouldBeTrue();
    }

    [Test]
    public void GivenAnPopulatedSourceAndAFailingPredicateThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool hasAny = source.HasAny(predicate => false);

        // Assert
        hasAny.ShouldBeFalse();
    }

    [Test]
    public void GivenAnPopulatedSourceAndAPassingPredicateThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool hasAny = source.HasAny(predicate => true);

        // Assert
        hasAny.ShouldBeTrue();
    }

    [Test]
    public void GivenANullSourceThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool hasAny = source.HasAny();

        // Assert
        hasAny.ShouldBeFalse();
    }

    [Test]
    public void GivenANullSourceAndAPredicateThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool hasAny = source.HasAny(predicate => true);

        // Assert
        hasAny.ShouldBeFalse();
    }
}
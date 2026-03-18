namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIsNullOrEmptyIsCalled
{
    [Test]
    public void GivenAnEmptySourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeTrue();
    }

    [Test]
    public void GivenAPopulatedSourceWithSingleElementThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
    }

    [Test]
    public void GivenAPopulatedSourceWithMultipleElementsThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
    }

    [Test]
    public void GivenANullSourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeTrue();
    }
}
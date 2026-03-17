namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIsEmptyIsCalled
{
    [Test]
    public void GivenAnEmptySourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool isEmpty = source.IsEmpty();

        // Assert
        isEmpty.ShouldBeTrue();
    }

    [Test]
    public void GivenAPopulatedSourceWithSingleElementThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool isEmpty = source.IsEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
    }

    [Test]
    public void GivenAPopulatedSourceWithMultipleElementsThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool isEmpty = source.IsEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
    }
}
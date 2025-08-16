namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIsNullOrEmptyIsCalled
{
    [Fact]
    public void GivenAnEmptySourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeTrue();
    }

    [Fact]
    public void GivenAPopulatedSourceWithSingleElementThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
    }

    [Fact]
    public void GivenAPopulatedSourceWithMultipleElementsThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
    }

    [Fact]
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
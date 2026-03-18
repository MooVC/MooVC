namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenIsNullOrEmptyIsCalled
{
    [Test]
    public async Task GivenAnEmptySourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = await Assert.That(isEmpty).IsTrue();
    }

    [Test]
    public async Task GivenAPopulatedSourceWithSingleElementThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = await Assert.That(isEmpty).IsFalse();
    }

    [Test]
    public async Task GivenAPopulatedSourceWithMultipleElementsThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = await Assert.That(isEmpty).IsFalse();
    }

    [Test]
    public async Task GivenANullSourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = await Assert.That(isEmpty).IsTrue();
    }
}
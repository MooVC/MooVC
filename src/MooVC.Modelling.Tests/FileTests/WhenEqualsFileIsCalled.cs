namespace MooVC.Modelling.FileTests;

public sealed class WhenEqualsFileIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create(content: FileTestsData.OtherContent);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenRightNullThenReturnsFalse()
    {
        // Arrange
        File left = FileTestsData.Create();
        File? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = left;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
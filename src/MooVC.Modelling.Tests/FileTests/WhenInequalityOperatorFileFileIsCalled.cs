namespace MooVC.Modelling.FileTests;

public sealed class WhenInequalityOperatorFileFileIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        File? left = default;
        File? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create(content: FileTestsData.OtherContent);

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        File? left = default;
        File right = FileTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
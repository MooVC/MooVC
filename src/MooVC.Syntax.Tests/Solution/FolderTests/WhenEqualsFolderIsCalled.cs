namespace MooVC.Syntax.Solution.FolderTests;

public sealed class WhenEqualsFolderIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();
        Folder other = FolderTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();
        Folder other = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
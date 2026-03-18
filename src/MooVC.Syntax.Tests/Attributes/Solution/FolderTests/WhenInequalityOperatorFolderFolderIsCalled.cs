namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenInequalityOperatorFolderFolderIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Folder? left = default;
        Folder? right = default;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsTrue();
    }
}
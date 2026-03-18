namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}
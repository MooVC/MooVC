namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}
namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenEqualityOperatorFolderFolderIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Folder? left = default;
        Folder? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
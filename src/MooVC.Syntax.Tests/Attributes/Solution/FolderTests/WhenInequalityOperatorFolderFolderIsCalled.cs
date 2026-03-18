namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenInequalityOperatorFolderFolderIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Folder? left = default;
        Folder? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
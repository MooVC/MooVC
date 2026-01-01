namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorFolderFolderIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Folder left = FolderTestsData.Create();
        Folder right = FolderTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
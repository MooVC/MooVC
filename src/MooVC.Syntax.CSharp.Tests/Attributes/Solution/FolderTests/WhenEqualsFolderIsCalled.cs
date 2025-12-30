namespace MooVC.Syntax.CSharp.Attributes.Solution.FolderTests;

using MooVC.Syntax.CSharp;

public sealed class WhenEqualsFolderIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();

        // Act
        bool result = subject.Equals(default(Folder));

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();
        Folder other = FolderTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();
        Folder other = FolderTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}
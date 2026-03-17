namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenEqualsFolderIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Folder subject = FolderTestsData.Create();
        Folder other = FolderTestsData.Create(name: new Folder.Path("/Other/"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}
namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsImportIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        Import? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        Import other = ImportTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        Import other = ImportTestsData.Create(project: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}
namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using MooVC.Syntax.CSharp.Attributes.Project;

public sealed class WhenEqualsProjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project other = ProjectTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project other = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}
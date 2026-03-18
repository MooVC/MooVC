namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsProjectIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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
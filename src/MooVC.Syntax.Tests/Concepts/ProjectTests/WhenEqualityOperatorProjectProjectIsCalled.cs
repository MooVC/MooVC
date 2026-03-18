namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorProjectProjectIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Project? left = default;
        Project? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
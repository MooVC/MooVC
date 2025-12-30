namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorProjectProjectIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
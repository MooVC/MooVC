namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using MooVC.Syntax.CSharp.Attributes.Project;

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
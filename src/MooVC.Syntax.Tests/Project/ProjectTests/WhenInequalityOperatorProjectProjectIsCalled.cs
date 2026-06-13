namespace MooVC.Syntax.Project.ProjectTests;

public sealed class WhenInequalityOperatorProjectProjectIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using MooVC.Syntax.CSharp.Attributes.Project;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}
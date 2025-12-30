namespace MooVC.Syntax.CSharp.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Attributes.Solution;
using ProjectReference = MooVC.Syntax.CSharp.Attributes.Solution.Project;

public sealed class WhenWithProjectsIsCalled
{
    [Fact]
    public void GivenProjectsThenReturnsUpdatedInstance()
    {
        // Arrange
        ProjectReference existing = SolutionTestsData.CreateProject();
        var additional = new ProjectReference
        {
            Id = Snippet.From("OtherId"),
            Name = Snippet.From("OtherName"),
            Path = Snippet.From("src/Other.csproj"),
            Type = Snippet.From("OtherType"),
        };
        Solution original = SolutionTestsData.Create(project: existing);

        // Act
        Solution result = original.WithProjects(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Projects.ShouldBe(original.Projects.Concat([additional]));
        result.Configurations.ShouldBe(original.Configurations);
    }
}
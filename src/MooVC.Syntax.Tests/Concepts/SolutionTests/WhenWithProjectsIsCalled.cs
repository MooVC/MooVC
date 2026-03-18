namespace MooVC.Syntax.Concepts.SolutionTests;

using System;
using System.Linq;
using MooVC.Syntax.Elements;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

public sealed class WhenWithProjectsIsCalled
{
    [Test]
    public async Task GivenProjectsThenReturnsUpdatedInstance()
    {
        // Arrange
        ProjectReference existing = SolutionTestsData.CreateProject();

        var additional = new ProjectReference
        {
            Id = Guid.Parse("9D9B238E-46E7-4B65-944F-3FC5A25E85B1"),
            DisplayName = new ProjectReference.Name("OtherName"),
            Path = new ProjectReference.RelativePath("src/Other.csproj"),
            Type = Snippet.From("OtherType"),
        };

        Solution original = SolutionTestsData.Create(project: existing);

        // Act
        Solution result = original.WithProjects(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Projects).IsEqualTo(original.Projects.Concat([additional]));
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}
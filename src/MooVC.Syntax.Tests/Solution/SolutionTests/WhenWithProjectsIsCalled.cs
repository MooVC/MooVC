namespace MooVC.Syntax.Solution.SolutionTests;

using System;

public sealed class WhenWithProjectsIsCalled
{
    [Test]
    public async Task GivenProjectsThenReturnsUpdatedInstance()
    {
        // Arrange
        Project existing = SolutionTestsData.CreateProject();

        var additional = new Project
        {
            Id = Guid.Parse("9D9B238E-46E7-4B65-944F-3FC5A25E85B1"),
            DisplayName = new("OtherName"),
            Path = new("src/Other.csproj"),
            Type = Snippet.From("OtherType"),
        };

        Solution original = SolutionTestsData.Create(project: existing);

        // Act
        Solution result = original.WithProjects(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Projects).IsEquivalentTo([.. original.Projects, additional]);
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}
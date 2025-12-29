namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using System.Linq;
using MooVC.Syntax.CSharp.Attributes.Project;

public sealed class WhenWithImportsIsCalled
{
    [Fact]
    public void GivenImportsThenReturnsUpdatedInstance()
    {
        // Arrange
        Import existing = ProjectTestsData.CreateImport();
        Import additional = new Import { Project = Snippet.From("Other"), Sdk = Snippet.Empty };
        Project original = ProjectTestsData.Create(import: existing);

        // Act
        Project result = original.WithImports(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Imports.ShouldBe(original.Imports.Concat(new[] { additional }));
        result.ItemGroups.ShouldBe(original.ItemGroups);
    }
}
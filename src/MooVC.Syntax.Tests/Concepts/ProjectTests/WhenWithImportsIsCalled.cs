namespace MooVC.Syntax.Concepts.ProjectTests;

using System.Linq;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

public sealed class WhenWithImportsIsCalled
{
    [Fact]
    public void GivenImportsThenReturnsUpdatedInstance()
    {
        // Arrange
        Import existing = ProjectTestsData.CreateImport();
        var additional = new Import { Project = Snippet.From("Other"), Sdk = Snippet.Empty };
        Project original = ProjectTestsData.Create(import: existing);

        // Act
        Project result = original.WithImports(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Imports.ShouldBe(original.Imports.Concat([additional]));
        result.ItemGroups.ShouldBe(original.ItemGroups);
    }
}
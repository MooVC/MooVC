namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

public sealed class WhenWithImportsIsCalled
{
    [Test]
    public async Task GivenImportsThenReturnsUpdatedInstance()
    {
        // Arrange
        Import existing = ProjectTestsData.CreateImport();
        var additional = new Import { Project = Snippet.From("Other"), Sdk = Snippet.Empty };
        Project original = ProjectTestsData.Create(import: existing);

        // Act
        Project result = original.WithImports(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Imports).IsEquivalentTo([.. original.Imports, additional]);
        _ = await Assert.That(result.ItemGroups).IsEqualTo(original.ItemGroups);
    }
}
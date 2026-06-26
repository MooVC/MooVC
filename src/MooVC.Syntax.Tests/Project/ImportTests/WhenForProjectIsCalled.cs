namespace MooVC.Syntax.Project.ImportTests;

public sealed class WhenForProjectIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = Snippet.From("Updated");

        // Act
        Import result = original.ForProject(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Project).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Label).IsEqualTo(original.Label);
        _ = await Assert.That(result.Sdk).IsEqualTo(original.Sdk);
    }
}
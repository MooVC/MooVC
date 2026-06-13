namespace MooVC.Syntax.Project.ImportTests;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = Snippet.From(UpdatedCondition);

        // Act
        Import result = original.OnCondition(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Condition).IsEqualTo(updated);
        _ = await Assert.That(result.Project).IsEqualTo(original.Project);
        _ = await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}
namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Condition).IsEqualTo(updated);
        await Assert.That(result.Project).IsEqualTo(original.Project);
        await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}
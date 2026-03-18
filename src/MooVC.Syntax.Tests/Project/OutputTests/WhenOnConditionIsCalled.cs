namespace MooVC.Syntax.Project.OutputTests;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = Snippet.From(UpdatedCondition);

        // Act
        Output result = original.OnCondition(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Condition).IsEqualTo(updated);
        _ = await Assert.That(result.ItemName).IsEqualTo(original.ItemName);
        _ = await Assert.That(result.PropertyName).IsEqualTo(original.PropertyName);
    }
}
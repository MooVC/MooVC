namespace MooVC.Syntax.Project.TargetTaskTests;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask original = TargetTaskTestsData.Create(output: TargetTaskTestsData.CreateOutput());
        var updated = Snippet.From(UpdatedCondition);

        // Act
        TargetTask result = original.OnCondition(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Condition).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.ContinueOnError).IsEqualTo(original.ContinueOnError);
    }
}
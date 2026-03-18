namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

public sealed class WhenWithContinueOnErrorIsCalled
{
    [Test]
    public async Task GivenContinueOnErrorThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask original = TargetTaskTestsData.Create(parameter: TargetTaskTestsData.CreateParameter());
        TargetTask.Options updated = TargetTask.Options.WarnAndContinue;

        // Act
        TargetTask result = original.WithContinueOnError(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.ContinueOnError).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}
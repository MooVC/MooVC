namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenWithDependsOnTargetsIsCalled
{
    private const string UpdatedDependsOnTargets = "UpdatedDependsOnTargets";

    [Test]
    public async Task GivenDependsOnTargetsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedDependsOnTargets);

        // Act
        Target result = original.WithDependsOnTargets(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.DependsOnTargets).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenWithBeforeTargetsIsCalled
{
    private const string UpdatedBeforeTargets = "UpdatedBeforeTargets";

    [Test]
    public async Task GivenBeforeTargetsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedBeforeTargets);

        // Act
        Target result = original.WithBeforeTargets(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.BeforeTargets).IsEqualTo(updated);
        _ = await Assert.That(result.AfterTargets).IsEqualTo(original.AfterTargets);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
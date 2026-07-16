namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenWithAfterTargetsIsCalled
{
    private const string UpdatedAfterTargets = "UpdatedAfterTargets";

    [Test]
    public async Task GivenAfterTargetsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedAfterTargets);

        // Act
        Target result = original.WithAfterTargets(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.AfterTargets).IsEqualTo(updated);
        _ = await Assert.That(result.BeforeTargets).IsEqualTo(original.BeforeTargets);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
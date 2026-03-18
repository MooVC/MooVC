namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.BeforeTargets).IsEqualTo(updated);
        await Assert.That(result.AfterTargets).IsEqualTo(original.AfterTargets);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
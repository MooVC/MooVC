namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.DependsOnTargets).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
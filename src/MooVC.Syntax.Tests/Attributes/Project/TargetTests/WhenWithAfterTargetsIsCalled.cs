namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.AfterTargets).IsEqualTo(updated);
        await Assert.That(result.BeforeTargets).IsEqualTo(original.BeforeTargets);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBeforeTargetsIsCalled
{
    private const string UpdatedBeforeTargets = "UpdatedBeforeTargets";

    [Fact]
    public void GivenBeforeTargetsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = UpdatedBeforeTargets;

        // Act
        Target result = original.WithBeforeTargets(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.BeforeTargets.ShouldBe(updated);
        result.AfterTargets.ShouldBe(original.AfterTargets);
        result.Name.ShouldBe(original.Name);
    }
}
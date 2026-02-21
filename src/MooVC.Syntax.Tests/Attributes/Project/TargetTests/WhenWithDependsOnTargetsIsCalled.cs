namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithDependsOnTargetsIsCalled
{
    private const string UpdatedDependsOnTargets = "UpdatedDependsOnTargets";

    [Fact]
    public void GivenDependsOnTargetsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = UpdatedDependsOnTargets;

        // Act
        Target result = original.WithDependsOnTargets(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.DependsOnTargets.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Name.ShouldBe(original.Name);
    }
}
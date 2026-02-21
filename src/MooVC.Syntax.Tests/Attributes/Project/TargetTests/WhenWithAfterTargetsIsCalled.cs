namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithAfterTargetsIsCalled
{
    private const string UpdatedAfterTargets = "UpdatedAfterTargets";

    [Fact]
    public void GivenAfterTargetsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = UpdatedAfterTargets;

        // Act
        Target result = original.WithAfterTargets(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.AfterTargets.ShouldBe(updated);
        result.BeforeTargets.ShouldBe(original.BeforeTargets);
        result.Name.ShouldBe(original.Name);
    }
}
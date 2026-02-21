namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedCondition);

        // Act
        Target result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Label.ShouldBe(original.Label);
    }
}
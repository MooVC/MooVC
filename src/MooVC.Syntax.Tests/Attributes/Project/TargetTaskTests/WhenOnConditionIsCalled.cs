namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask original = TargetTaskTestsData.Create(output: TargetTaskTestsData.CreateOutput());
        var updated = UpdatedCondition;

        // Act
        TargetTask result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.ContinueOnError.ShouldBe(original.ContinueOnError);
    }
}
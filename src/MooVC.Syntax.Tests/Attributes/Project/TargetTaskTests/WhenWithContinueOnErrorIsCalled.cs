namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

public sealed class WhenWithContinueOnErrorIsCalled
{
    [Fact]
    public void GivenContinueOnErrorThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask original = TargetTaskTestsData.Create(parameter: TargetTaskTestsData.CreateParameter());
        TargetTask.Options updated = TargetTask.Options.WarnAndContinue;

        // Act
        TargetTask result = original.WithContinueOnError(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ContinueOnError.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Condition.ShouldBe(original.Condition);
    }
}
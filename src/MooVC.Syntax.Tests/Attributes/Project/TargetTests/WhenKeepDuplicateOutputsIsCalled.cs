namespace MooVC.Syntax.Attributes.Project.TargetTests;

public sealed class WhenKeepDuplicateOutputsIsCalled
{
    [Fact]
    public void GivenKeepDuplicateOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        const bool updated = true;

        // Act
        Target result = original.KeepDuplicateOutputs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.KeepDuplicateOutputs.ShouldBe(updated);
        result.Outputs.ShouldBe(original.Outputs);
        result.Name.ShouldBe(original.Name);
    }
}
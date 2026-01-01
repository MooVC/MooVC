namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithInputsIsCalled
{
    private const string UpdatedInputs = "UpdatedInputs";

    [Fact]
    public void GivenInputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedInputs);

        // Act
        Target result = original.WithInputs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Inputs.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Name.ShouldBe(original.Name);
    }
}
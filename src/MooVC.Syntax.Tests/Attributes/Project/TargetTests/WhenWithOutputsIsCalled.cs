namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithOutputsIsCalled
{
    private const string UpdatedOutputs = "UpdatedOutputs";

    [Fact]
    public void GivenOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedOutputs);

        // Act
        Target result = original.WithOutputs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Outputs.ShouldBe(updated);
        result.Returns.ShouldBe(original.Returns);
        result.Name.ShouldBe(original.Name);
    }
}
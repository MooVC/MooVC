namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithReturnsIsCalled
{
    private const string UpdatedReturns = "UpdatedReturns";

    [Fact]
    public void GivenReturnsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = UpdatedReturns;

        // Act
        Target result = original.WithReturns(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Returns.ShouldBe(updated);
        result.Outputs.ShouldBe(original.Outputs);
        result.Name.ShouldBe(original.Name);
    }
}
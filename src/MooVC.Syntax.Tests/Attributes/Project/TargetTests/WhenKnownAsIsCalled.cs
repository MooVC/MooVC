namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Fact]
    public void GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = UpdatedLabel;

        // Act
        Target result = original.KnownAs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Label.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Name.ShouldBe(original.Name);
    }
}
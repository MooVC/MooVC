namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = UpdatedCondition;

        // Act
        Import result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Project.ShouldBe(original.Project);
        result.Label.ShouldBe(original.Label);
    }
}
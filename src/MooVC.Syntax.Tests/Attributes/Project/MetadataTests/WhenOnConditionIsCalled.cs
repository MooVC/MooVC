namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = UpdatedCondition;

        // Act
        Metadata result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Value.ShouldBe(original.Value);
    }
}
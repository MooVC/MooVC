namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        ItemGroup original = ItemGroupTestsData.Create(item: ItemGroupTestsData.CreateItem());
        var updated = UpdatedCondition;

        // Act
        ItemGroup result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Items.ShouldBe(original.Items);
        result.Label.ShouldBe(original.Label);
    }
}
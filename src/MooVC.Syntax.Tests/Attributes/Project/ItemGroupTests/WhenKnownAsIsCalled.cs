namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Fact]
    public void GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        ItemGroup original = ItemGroupTestsData.Create(item: ItemGroupTestsData.CreateItem());
        var updated = Snippet.From(UpdatedLabel);

        // Act
        ItemGroup result = original.KnownAs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Label.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Items.ShouldBe(original.Items);
    }
}
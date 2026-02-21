namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Fact]
    public void GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemGroupTestsData.CreateItem();
        var additional = new Item { Include = "Extra" };
        ItemGroup original = ItemGroupTestsData.Create(item: existing);

        // Act
        ItemGroup result = original.WithItems(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Items.ShouldBe(original.Items.Concat([additional]));
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
    }
}
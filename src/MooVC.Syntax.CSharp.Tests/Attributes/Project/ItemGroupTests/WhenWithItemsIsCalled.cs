namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

using System.Linq;

public sealed class WhenWithItemsIsCalled
{
    [Fact]
    public void GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemGroupTestsData.CreateItem();
        Item additional = new Item { Include = Snippet.From("Extra") };
        ItemGroup original = ItemGroupTestsData.Create(item: existing);

        // Act
        ItemGroup result = original.WithItems(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Items.ShouldBe(original.Items.Concat(new[] { additional }));
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
    }
}
namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Test]
    public async Task GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemGroupTestsData.CreateItem();
        var additional = new Item { Include = Snippet.From("Extra") };
        ItemGroup original = ItemGroupTestsData.Create(item: existing);

        // Act
        ItemGroup result = original.WithItems(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items.Concat([additional]));
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}
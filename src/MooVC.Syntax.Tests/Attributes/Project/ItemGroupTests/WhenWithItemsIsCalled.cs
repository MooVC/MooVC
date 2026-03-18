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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Items).IsEqualTo(original.Items.Concat([additional]));
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}
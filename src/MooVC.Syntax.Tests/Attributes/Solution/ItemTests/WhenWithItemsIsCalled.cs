namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Test]
    public async Task GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemTestsData.CreateChild();
        Item additional = ItemTestsData.CreateChild().WithId(Snippet.From("Other"));
        Item original = ItemTestsData.Create(item: existing);

        // Act
        Item result = original.WithItems(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Items).IsEqualTo(original.Items.Concat([additional]));
        await Assert.That(result.Id).IsEqualTo(original.Id);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Path).IsEqualTo(original.Path);
        await Assert.That(result.Type).IsEqualTo(original.Type);
    }
}
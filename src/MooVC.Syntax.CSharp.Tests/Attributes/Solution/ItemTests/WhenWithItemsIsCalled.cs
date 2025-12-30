namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using System.Linq;
using MooVC.Syntax.CSharp;

public sealed class WhenWithItemsIsCalled
{
    [Fact]
    public void GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemTestsData.CreateChild();
        Item additional = ItemTestsData.CreateChild().WithId(Snippet.From("Other"));
        Item original = ItemTestsData.Create(item: existing);

        // Act
        Item result = original.WithItems(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Items.ShouldBe(original.Items.Concat([additional]));
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
    }
}
namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Test]
    public async Task GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = SolutionTestsData.CreateItem();

        var additional = new Item
        {
            Id = Snippet.From("OtherId"),
            Name = Snippet.From("OtherName"),
            Path = Snippet.From("assets/other.txt"),
            Type = Snippet.From("OtherType"),
        };

        Solution original = SolutionTestsData.Create(item: existing);

        // Act
        Solution result = original.WithItems(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Items).IsEqualTo(original.Items.Concat([additional]));
        await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}
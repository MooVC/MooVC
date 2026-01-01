namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Fact]
    public void GivenItemsThenReturnsUpdatedInstance()
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
        result.ShouldNotBeSameAs(original);
        result.Items.ShouldBe(original.Items.Concat([additional]));
        result.Configurations.ShouldBe(original.Configurations);
    }
}
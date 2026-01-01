namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("OtherType");

        // Act
        Item result = original.WithType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
        result.Path.ShouldBe(original.Path);
        result.Items.ShouldBe(original.Items);
    }
}
namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("OtherName");

        // Act
        Item result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
        result.Items.ShouldBe(original.Items);
    }
}
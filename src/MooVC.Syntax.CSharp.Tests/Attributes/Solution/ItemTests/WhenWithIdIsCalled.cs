namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        Snippet updated = Snippet.From("OtherId");

        // Act
        Item result = original.WithId(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Id.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
        result.Items.ShouldBe(original.Items);
    }
}
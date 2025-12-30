namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithPathIsCalled
{
    [Fact]
    public void GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        Snippet updated = Snippet.From("assets/other.txt");

        // Act
        Item result = original.WithPath(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Path.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
        result.Items.ShouldBe(original.Items);
    }
}
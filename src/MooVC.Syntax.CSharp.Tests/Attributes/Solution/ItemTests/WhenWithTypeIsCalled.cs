namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        Snippet updated = Snippet.From("OtherType");

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
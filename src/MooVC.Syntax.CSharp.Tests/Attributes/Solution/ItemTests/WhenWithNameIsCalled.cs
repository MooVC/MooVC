namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        Snippet updated = Snippet.From("OtherName");

        // Act
        Item result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
        result.Items.ShouldBe(original.Items);
    }
}
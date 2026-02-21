namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = "OtherId";

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
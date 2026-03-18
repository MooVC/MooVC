namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("OtherType");

        // Act
        Item result = original.OfType(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Type).IsEqualTo(updated);
        _ = await Assert.That(result.Id).IsEqualTo(original.Id);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Path).IsEqualTo(original.Path);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}
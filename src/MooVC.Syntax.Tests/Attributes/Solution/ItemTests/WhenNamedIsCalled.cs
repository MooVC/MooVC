namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("OtherName");

        // Act
        Item result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Id).IsEqualTo(original.Id);
        _ = await Assert.That(result.Path).IsEqualTo(original.Path);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}
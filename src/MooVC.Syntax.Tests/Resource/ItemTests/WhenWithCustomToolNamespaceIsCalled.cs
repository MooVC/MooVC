namespace MooVC.Syntax.Resource.ItemTests;

public sealed class WhenWithCustomToolNamespaceIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("Other.Namespace");

        // Act
        Item result = original.WithCustomToolNamespace(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(updated);
        _ = await Assert.That(result.Designer).IsEqualTo(original.Designer);
        _ = await Assert.That(result.Location).IsEqualTo(original.Location);
        _ = await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}
namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithCustomToolNamespaceIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();
        var updated = Snippet.From("Other.Namespace");

        // Act
        Resource result = original.WithCustomToolNamespace(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(updated);
        _ = await Assert.That(result.Designer).IsEqualTo(original.Designer);
        _ = await Assert.That(result.Location).IsEqualTo(original.Location);
        _ = await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.CustomToolNamespace).IsEqualTo(updated);
        await Assert.That(result.Designer).IsEqualTo(original.Designer);
        await Assert.That(result.Location).IsEqualTo(original.Location);
        await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}
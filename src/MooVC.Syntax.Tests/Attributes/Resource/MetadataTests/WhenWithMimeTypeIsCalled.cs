namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMimeTypeIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Metadata result = original.WithMimeType(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.MimeType).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}
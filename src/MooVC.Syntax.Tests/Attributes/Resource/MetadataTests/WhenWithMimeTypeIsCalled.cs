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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.MimeType).IsEqualTo(updated);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}
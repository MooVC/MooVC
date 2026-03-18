namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Metadata result = original.Named(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(updated);
        await Assert.That(result.MimeType).IsEqualTo(original.MimeType);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}
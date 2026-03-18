namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Metadata result = original.WithValue(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Value).IsEqualTo(updated);
        await Assert.That(result.MimeType).IsEqualTo(original.MimeType);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Type).IsEqualTo(original.Type);
    }
}
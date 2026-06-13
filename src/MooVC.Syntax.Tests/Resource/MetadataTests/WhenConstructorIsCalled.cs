namespace MooVC.Syntax.Resource.MetadataTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMetadataIsUndefined()
    {
        // Act
        var subject = new Metadata();

        // Assert
        _ = await Assert.That(subject.MimeType).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Type).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var mimeType = Snippet.From(MetadataTestsData.DefaultMimeType);
        var name = Snippet.From(MetadataTestsData.DefaultName);
        var type = Snippet.From(MetadataTestsData.DefaultType);
        var value = Snippet.From(MetadataTestsData.DefaultValue);

        // Act
        var subject = new Metadata
        {
            MimeType = mimeType,
            Name = name,
            Type = type,
            Value = value,
        };

        // Assert
        _ = await Assert.That(subject.MimeType).IsEqualTo(mimeType);
        _ = await Assert.That(subject.Name).IsEqualTo(name);
        _ = await Assert.That(subject.Type).IsEqualTo(type);
        _ = await Assert.That(subject.Value).IsEqualTo(value);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}
namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenDataIsUndefined()
    {
        // Act
        var subject = new Data();

        // Assert
        _ = await Assert.That(subject.Comment).IsEqualTo(Snippet.Empty);
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
        var comment = Snippet.From(DataTestsData.DefaultComment);
        var mimeType = Snippet.From(DataTestsData.DefaultMimeType);
        var name = Snippet.From(DataTestsData.DefaultName);
        var type = Snippet.From(DataTestsData.DefaultType);
        var value = Snippet.From(DataTestsData.DefaultValue);

        // Act
        var subject = new Data
        {
            Comment = comment,
            MimeType = mimeType,
            Name = name,
            Type = type,
            Value = value,
        };

        // Assert
        _ = await Assert.That(subject.Comment).IsEqualTo(comment);
        _ = await Assert.That(subject.MimeType).IsEqualTo(mimeType);
        _ = await Assert.That(subject.Name).IsEqualTo(name);
        _ = await Assert.That(subject.Type).IsEqualTo(type);
        _ = await Assert.That(subject.Value).IsEqualTo(value);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}
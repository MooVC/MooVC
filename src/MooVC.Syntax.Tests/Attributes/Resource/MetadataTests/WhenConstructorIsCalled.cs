namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenMetadataIsUndefined()
    {
        // Act
        var subject = new Metadata();

        // Assert
        subject.MimeType.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Type.ShouldBe(Snippet.Empty);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var mimeType = MetadataTestsData.DefaultMimeType;
        var name = MetadataTestsData.DefaultName;
        var type = MetadataTestsData.DefaultType;
        var value = MetadataTestsData.DefaultValue;

        // Act
        var subject = new Metadata
        {
            MimeType = mimeType,
            Name = name,
            Type = type,
            Value = value,
        };

        // Assert
        subject.MimeType.ShouldBe(mimeType);
        subject.Name.ShouldBe(name);
        subject.Type.ShouldBe(type);
        subject.Value.ShouldBe(value);
        subject.IsUndefined.ShouldBeFalse();
    }
}
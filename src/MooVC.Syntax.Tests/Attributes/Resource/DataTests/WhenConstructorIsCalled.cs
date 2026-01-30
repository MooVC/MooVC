namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenDataIsUndefined()
    {
        // Act
        var subject = new Data();

        // Assert
        subject.Comment.ShouldBe(Snippet.Empty);
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
        subject.Comment.ShouldBe(comment);
        subject.MimeType.ShouldBe(mimeType);
        subject.Name.ShouldBe(name);
        subject.Type.ShouldBe(type);
        subject.Value.ShouldBe(value);
        subject.IsUndefined.ShouldBeFalse();
    }
}
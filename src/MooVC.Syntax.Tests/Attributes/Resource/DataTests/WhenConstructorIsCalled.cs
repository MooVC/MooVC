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
        var comment = DataTestsData.DefaultComment;
        var mimeType = DataTestsData.DefaultMimeType;
        var name = DataTestsData.DefaultName;
        var type = DataTestsData.DefaultType;
        var value = DataTestsData.DefaultValue;

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
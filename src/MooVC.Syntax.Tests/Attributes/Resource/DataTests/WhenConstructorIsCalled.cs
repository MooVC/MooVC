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
        subject.XmlSpace.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Snippet comment = Snippet.From(DataTestsData.DefaultComment);
        Snippet mimeType = Snippet.From(DataTestsData.DefaultMimeType);
        Snippet name = Snippet.From(DataTestsData.DefaultName);
        Snippet type = Snippet.From(DataTestsData.DefaultType);
        Snippet value = Snippet.From(DataTestsData.DefaultValue);
        Snippet xmlSpace = Snippet.From(DataTestsData.DefaultXmlSpace);

        // Act
        var subject = new Data
        {
            Comment = comment,
            MimeType = mimeType,
            Name = name,
            Type = type,
            Value = value,
            XmlSpace = xmlSpace,
        };

        // Assert
        subject.Comment.ShouldBe(comment);
        subject.MimeType.ShouldBe(mimeType);
        subject.Name.ShouldBe(name);
        subject.Type.ShouldBe(type);
        subject.Value.ShouldBe(value);
        subject.XmlSpace.ShouldBe(xmlSpace);
        subject.IsUndefined.ShouldBeFalse();
    }
}
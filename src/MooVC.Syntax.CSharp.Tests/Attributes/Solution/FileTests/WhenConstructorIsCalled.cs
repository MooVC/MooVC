namespace MooVC.Syntax.CSharp.Attributes.Solution.FileTests;

using MooVC.Syntax.CSharp;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenFileIsUndefined()
    {
        // Act
        var subject = new File();

        // Assert
        subject.Id.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Path.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new File
        {
            Id = Snippet.From(FileTestsData.DefaultId),
            Name = Snippet.From(FileTestsData.DefaultName),
            Path = Snippet.From(FileTestsData.DefaultPath),
        };

        // Assert
        subject.Id.ShouldBe(Snippet.From(FileTestsData.DefaultId));
        subject.Name.ShouldBe(Snippet.From(FileTestsData.DefaultName));
        subject.Path.ShouldBe(Snippet.From(FileTestsData.DefaultPath));
        subject.IsUndefined.ShouldBeFalse();
    }
}
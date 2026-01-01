namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenFolderIsUndefined()
    {
        // Act
        var subject = new Folder();

        // Assert
        subject.Files.ShouldBeEmpty();
        subject.Folders.ShouldBeEmpty();
        subject.Id.ShouldBe(Snippet.Empty);
        subject.Items.ShouldBeEmpty();
        subject.Name.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        File file = FolderTestsData.CreateFile();
        Folder folder = FolderTestsData.CreateChildFolder();
        Item item = FolderTestsData.CreateItem();

        // Act
        var subject = new Folder
        {
            Files = [file],
            Folders = [folder],
            Id = Snippet.From(FolderTestsData.DefaultId),
            Items = [item],
            Name = Snippet.From(FolderTestsData.DefaultName),
        };

        // Assert
        subject.Files.ShouldBe(new[] { file });
        subject.Folders.ShouldBe(new[] { folder });
        subject.Id.ShouldBe(Snippet.From(FolderTestsData.DefaultId));
        subject.Items.ShouldBe(new[] { item });
        subject.Name.ShouldBe(Snippet.From(FolderTestsData.DefaultName));
        subject.IsUndefined.ShouldBeFalse();
    }
}
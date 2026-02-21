namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenFolderIsUndefined()
    {
        // Act
        var subject = new Folder();

        // Assert
        subject.Files.ShouldBeEmpty();
        subject.Items.ShouldBeEmpty();
        subject.Projects.ShouldBeEmpty();
        subject.Name.ShouldBe(Folder.Path.Root);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        File file = FolderTestsData.CreateFile();
        Item item = FolderTestsData.CreateItem();
        Project project = FolderTestsData.CreateProject();

        // Act
        var subject = new Folder
        {
            Files = [file],
            Items = [item],
            Name = new Folder.Path(FolderTestsData.DefaultName),
            Projects = [project],
        };

        // Assert
        subject.Files.ShouldBe(new[] { file });
        subject.Items.ShouldBe(new[] { item });
        subject.Name.ShouldBe(new Folder.Path(FolderTestsData.DefaultName));
        subject.Projects.ShouldBe(new[] { project });
        subject.IsUndefined.ShouldBeFalse();
    }
}
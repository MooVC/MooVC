namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenFolderIsUndefined()
    {
        // Act
        var subject = new Folder();

        // Assert
        await Assert.That(subject.Files).IsEmpty();
        await Assert.That(subject.Items).IsEmpty();
        await Assert.That(subject.Projects).IsEmpty();
        await Assert.That(subject.Name).IsEqualTo(Folder.Path.Root);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
        await Assert.That(subject.Files).IsEqualTo(new[] { file });
        await Assert.That(subject.Items).IsEqualTo(new[] { item });
        await Assert.That(subject.Name).IsEqualTo(new Folder.Path(FolderTestsData.DefaultName));
        await Assert.That(subject.Projects).IsEqualTo(new[] { project });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}
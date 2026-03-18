namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenFolderIsUndefined()
    {
        // Act
        var subject = new Folder();

        // Assert
        _ = await Assert.That(subject.Files).IsEmpty();
        _ = await Assert.That(subject.Items).IsEmpty();
        _ = await Assert.That(subject.Projects).IsEmpty();
        _ = await Assert.That(subject.Name).IsEqualTo(Folder.Path.Root);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Files).IsEqualTo(new[] { file });
        _ = await Assert.That(subject.Items).IsEqualTo(new[] { item });
        _ = await Assert.That(subject.Name).IsEqualTo(new Folder.Path(FolderTestsData.DefaultName));
        _ = await Assert.That(subject.Projects).IsEqualTo(new[] { project });
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}
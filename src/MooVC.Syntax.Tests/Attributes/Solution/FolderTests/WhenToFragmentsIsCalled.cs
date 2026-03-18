namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Folder subject = Folder.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        File file = FolderTestsData.CreateFile();
        Item item = FolderTestsData.CreateItem();
        Project project = FolderTestsData.CreateProject();
        Folder subject = FolderTestsData.Create(file: file, item: item, project: project);

        var fileElement = new XElement(
            nameof(File),
            new XAttribute("Path", "src/file.cs"));

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Id), "ItemId"),
            new XAttribute(nameof(Item.Name), "ItemName"),
            new XAttribute(nameof(Item.Path), "assets/item.txt"),
            new XAttribute(nameof(Item.Type), "ItemType"));

        var projectElement = new XElement(
            nameof(Project),
            new XAttribute(nameof(Project.DisplayName), "ProjectName"),
            new XAttribute(nameof(Project.Id), project.Id),
            new XAttribute(nameof(Project.Path), "src/Project.csproj"),
            new XAttribute(nameof(Project.Type), "CSharp"));

        var expected = new XElement(
            nameof(Folder),
            new XAttribute(nameof(Folder.Name), FolderTestsData.DefaultName),
            fileElement,
            itemElement,
            projectElement);

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
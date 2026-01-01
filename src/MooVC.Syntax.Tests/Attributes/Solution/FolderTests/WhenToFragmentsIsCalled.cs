namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Folder subject = Folder.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        File file = FolderTestsData.CreateFile();
        Folder childFolder = FolderTestsData.CreateChildFolder();
        Item item = FolderTestsData.CreateItem();
        Folder subject = FolderTestsData.Create(file: file, folder: childFolder, item: item);

        var fileElement = new XElement(
            nameof(File),
            new XAttribute(nameof(File.Id), "FileId"),
            new XAttribute(nameof(File.Name), "FileName"),
            new XAttribute(nameof(File.Path), "src/file.cs"));

        var folderElement = new XElement(
            nameof(Folder),
            new XAttribute(nameof(Folder.Id), "ChildFolderId"),
            new XAttribute(nameof(Folder.Name), "ChildFolderName"));

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Id), "ItemId"),
            new XAttribute(nameof(Item.Name), "ItemName"),
            new XAttribute(nameof(Item.Path), "assets/item.txt"),
            new XAttribute(nameof(Item.Type), "ItemType"));

        var expected = new XElement(
            nameof(Folder),
            new XAttribute(nameof(Folder.Id), FolderTestsData.DefaultId),
            new XAttribute(nameof(Folder.Name), FolderTestsData.DefaultName),
            fileElement,
            folderElement,
            itemElement);

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
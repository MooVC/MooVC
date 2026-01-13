namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Folder subject = Folder.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
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

        var element = new XElement(
            nameof(Folder),
            new XAttribute(nameof(Folder.Name), FolderTestsData.DefaultName),
            fileElement,
            itemElement,
            projectElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}
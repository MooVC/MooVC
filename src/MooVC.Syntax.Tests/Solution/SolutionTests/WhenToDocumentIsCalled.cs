namespace MooVC.Syntax.Solution.SolutionTests;

using System.Xml.Linq;

public sealed class WhenToDocumentIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyDocument()
    {
        // Arrange
        Solution subject = Solution.Undefined;

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        _ = await Assert.That(result.Root).IsNull();
        _ = await Assert.That(result.Declaration).IsNull();
    }

    [Test]
    public async Task GivenValuesThenReturnsDocument()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();

        var fileElement = new XElement(
            nameof(File),
            new XAttribute("Path", SolutionTestsData.DefaultFilePath));

        var folderElement = new XElement(
            nameof(Folder),
            new XAttribute(nameof(Folder.Name), SolutionTestsData.DefaultFolderName));

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Id), SolutionTestsData.DefaultItemId),
            new XAttribute(nameof(Item.Name), SolutionTestsData.DefaultItemName),
            new XAttribute(nameof(Item.Path), SolutionTestsData.DefaultItemPath),
            new XAttribute(nameof(Item.Type), SolutionTestsData.DefaultItemType));

        var itemsElement = new XElement("Items", fileElement, folderElement, itemElement);

        var projectElement = new XElement(
            nameof(Project),
            new XAttribute(nameof(Project.DisplayName), SolutionTestsData.DefaultProjectName),
            new XAttribute(nameof(Project.Id), SolutionTestsData.DefaultProjectId),
            new XAttribute(nameof(Project.Path), SolutionTestsData.DefaultProjectPath),
            new XAttribute(nameof(Project.Type), SolutionTestsData.DefaultProjectType));

        var projectsElement = new XElement("Projects", projectElement);

        var propertyElement = new XElement(
            nameof(Property),
            new XAttribute(nameof(Property.Name), SolutionTestsData.DefaultPropertyName),
            new XAttribute(nameof(Property.Value), SolutionTestsData.DefaultPropertyValue));

        var propertiesElement = new XElement("Properties", propertyElement);

        var expected = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(
                nameof(Solution),
                itemsElement,
                projectsElement,
                propertiesElement));

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        XDeclaration declaration = await Assert.That(result.Declaration).IsNotNull();
        _ = await Assert.That(declaration.Version).IsEqualTo("1.0");
        _ = await Assert.That(declaration.Encoding).IsEqualTo("utf-8");
        _ = await Assert.That(declaration.Standalone).IsEqualTo("yes");
        _ = await Assert.That(XNode.DeepEquals(expected, result)).IsTrue();
    }
}
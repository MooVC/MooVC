namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Xml.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenToDocumentIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyDocument()
    {
        // Arrange
        Solution subject = Solution.Undefined;

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        result.Root.ShouldBeNull();
        result.Declaration.ShouldBeNull();
    }

    [Fact]
    public void GivenValuesThenReturnsDocument()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();

        var configurationElement = new XElement(
            nameof(Configuration),
            new XAttribute(nameof(Configuration.Name), SolutionTestsData.DefaultConfigurationName),
            new XAttribute(nameof(Configuration.Platform), SolutionTestsData.DefaultConfigurationPlatform));

        var configurationsElement = new XElement("Configurations", configurationElement);

        var fileElement = new XElement(
            nameof(File),
            new XAttribute(nameof(File.Id), SolutionTestsData.DefaultFileId),
            new XAttribute(nameof(File.Name), SolutionTestsData.DefaultFileName),
            new XAttribute(nameof(File.Path), SolutionTestsData.DefaultFilePath));

        var folderElement = new XElement(
            nameof(Folder),
            new XAttribute(nameof(Folder.Id), SolutionTestsData.DefaultFolderId),
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
            new XAttribute(nameof(Project.Id), SolutionTestsData.DefaultProjectId),
            new XAttribute(nameof(Project.Name), SolutionTestsData.DefaultProjectName),
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
                configurationsElement,
                itemsElement,
                projectsElement,
                propertiesElement));

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        XDeclaration declaration = result.Declaration.ShouldNotBeNull();
        declaration.Version.ShouldBe("1.0");
        declaration.Encoding.ShouldBe("utf-8");
        declaration.Standalone.ShouldBe("yes");
        XNode.DeepEquals(expected, result).ShouldBeTrue();
    }
}
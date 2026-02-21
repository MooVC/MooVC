namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Xml.Linq;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenToDocumentIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyDocument()
    {
        // Arrange
        Resource subject = Resource.Undefined;

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
        Resource subject = ResourceTestsData.Create();

        var headerElement = new XElement(
            "resheader",
            new XAttribute("name", ResourceTestsData.DefaultHeaderName),
            new XElement("value", ResourceTestsData.DefaultHeaderValue));

        var assemblyElement = new XElement(
            "assembly",
            new XAttribute("alias", ResourceTestsData.DefaultAssemblyAlias),
            new XAttribute("name", ResourceTestsData.DefaultAssemblyName));

        var dataElement = new XElement(
            "data",
            new XAttribute("name", ResourceTestsData.DefaultDataName),
            new XAttribute("type", ResourceTestsData.DefaultDataType),
            new XAttribute("mimetype", ResourceTestsData.DefaultDataMimeType),
            new XElement("value", ResourceTestsData.DefaultDataValue),
            new XElement("comment", ResourceTestsData.DefaultDataComment));

        var metadataElement = new XElement(
            "metadata",
            new XAttribute("name", ResourceTestsData.DefaultMetadataName),
            new XAttribute("type", ResourceTestsData.DefaultMetadataType),
            new XAttribute("mimetype", ResourceTestsData.DefaultMetadataMimeType),
            new XElement("value", ResourceTestsData.DefaultMetadataValue));

        var expected = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("root", headerElement, assemblyElement, dataElement, metadataElement));

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
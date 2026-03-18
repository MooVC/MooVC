namespace MooVC.Syntax.Resource.ResourceTests;

using System.Xml.Linq;
using Resource = Resource;

public sealed class WhenToDocumentIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyDocument()
    {
        // Arrange
        Resource subject = Resource.Undefined;

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
        XDeclaration declaration = await Assert.That(result.Declaration).IsNotNull();
        _ = await Assert.That(declaration.Version).IsEqualTo("1.0");
        _ = await Assert.That(declaration.Encoding).IsEqualTo("utf-8");
        _ = await Assert.That(declaration.Standalone).IsEqualTo("yes");
        _ = await Assert.That(XNode.DeepEquals(expected, result)).IsTrue();
    }
}
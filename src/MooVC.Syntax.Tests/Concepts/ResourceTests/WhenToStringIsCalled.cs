namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Resource subject = Resource.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
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
            new XAttribute(XNamespace.Xml + "space", ResourceTestsData.DefaultDataXmlSpace),
            new XElement("value", ResourceTestsData.DefaultDataValue),
            new XElement("comment", ResourceTestsData.DefaultDataComment));

        var metadataElement = new XElement(
            "metadata",
            new XAttribute("name", ResourceTestsData.DefaultMetadataName),
            new XAttribute("type", ResourceTestsData.DefaultMetadataType),
            new XAttribute("mimetype", ResourceTestsData.DefaultMetadataMimeType),
            new XAttribute(XNamespace.Xml + "space", ResourceTestsData.DefaultMetadataXmlSpace),
            new XElement("value", ResourceTestsData.DefaultMetadataValue));

        var expected = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("root", headerElement, assemblyElement, dataElement, metadataElement));

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected.ToString());
    }
}
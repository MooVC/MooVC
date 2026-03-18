namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Metadata subject = Metadata.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();

        var element = new XElement(
            "metadata",
            new XAttribute("name", MetadataTestsData.DefaultName),
            new XAttribute("type", MetadataTestsData.DefaultType),
            new XAttribute("mimetype", MetadataTestsData.DefaultMimeType),
            new XElement("value", MetadataTestsData.DefaultValue));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}
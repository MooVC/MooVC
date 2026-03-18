namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Metadata subject = Metadata.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();

        var expected = new XElement(
            "metadata",
            new XAttribute("name", MetadataTestsData.DefaultName),
            new XAttribute("type", MetadataTestsData.DefaultType),
            new XAttribute("mimetype", MetadataTestsData.DefaultMimeType),
            new XElement("value", MetadataTestsData.DefaultValue));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
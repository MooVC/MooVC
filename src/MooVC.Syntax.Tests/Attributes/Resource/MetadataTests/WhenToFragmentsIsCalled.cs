namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Metadata subject = Metadata.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
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
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
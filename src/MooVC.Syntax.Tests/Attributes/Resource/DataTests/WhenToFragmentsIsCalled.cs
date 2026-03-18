namespace MooVC.Syntax.Attributes.Resource.DataTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Data subject = Data.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        Data subject = DataTestsData.Create();

        var expected = new XElement(
            "data",
            new XAttribute("name", DataTestsData.DefaultName),
            new XAttribute("type", DataTestsData.DefaultType),
            new XAttribute("mimetype", DataTestsData.DefaultMimeType),
            new XElement("value", DataTestsData.DefaultValue),
            new XElement("comment", DataTestsData.DefaultComment));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
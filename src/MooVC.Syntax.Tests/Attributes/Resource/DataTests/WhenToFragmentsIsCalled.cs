namespace MooVC.Syntax.Attributes.Resource.DataTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Data subject = Data.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
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
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
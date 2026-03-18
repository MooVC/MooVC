namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Header subject = Header.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();

        var expected = new XElement(
            "resheader",
            new XAttribute("name", HeaderTestsData.DefaultName),
            new XElement("value", HeaderTestsData.DefaultValue));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        _ = await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
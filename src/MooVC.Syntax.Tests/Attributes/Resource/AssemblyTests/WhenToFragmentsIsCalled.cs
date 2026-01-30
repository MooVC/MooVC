namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Assembly subject = Assembly.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();

        var expected = new XElement(
            "assembly",
            new XAttribute("alias", AssemblyTestsData.DefaultAlias),
            new XAttribute("name", AssemblyTestsData.DefaultName));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
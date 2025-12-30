namespace MooVC.Syntax.Attributes.Solution.ConfigurationTests;

using System.Collections.Immutable;
using System.Xml.Linq;
using MooVC.Syntax;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Configuration subject = Configuration.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Configuration subject = ConfigurationTestsData.Create();

        var expected = new XElement(
            nameof(Configuration),
            new XAttribute(nameof(Configuration.Name), ConfigurationTestsData.DefaultName),
            new XAttribute(nameof(Configuration.Platform), ConfigurationTestsData.DefaultPlatform));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
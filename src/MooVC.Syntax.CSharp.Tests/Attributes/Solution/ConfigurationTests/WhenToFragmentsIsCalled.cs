namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using System.Xml.Linq;
using MooVC.Syntax.CSharp;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Configuration subject = Configuration.Undefined;

        // Act
        var result = subject.ToFragments();

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
        var result = subject.ToFragments();

        // Assert
        var fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
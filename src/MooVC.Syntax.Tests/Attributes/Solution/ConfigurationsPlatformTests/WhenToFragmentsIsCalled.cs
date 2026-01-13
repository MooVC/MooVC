namespace MooVC.Syntax.Attributes.Solution.ConfigurationsPlatformTests;

using System.Collections.Immutable;
using System.Xml.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUnspecifiedThenReturnsEmpty()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.Unspecified;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValueThenReturnsFragment()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.AnyCPU;

        var expected = new XElement(nameof(Configurations.Platform), new XAttribute("Name", "Any CPU"));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
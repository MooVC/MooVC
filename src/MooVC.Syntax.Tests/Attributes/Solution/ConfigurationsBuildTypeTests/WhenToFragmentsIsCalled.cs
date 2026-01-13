namespace MooVC.Syntax.Attributes.Solution.ConfigurationsBuildTypeTests;

using System.Collections.Immutable;
using System.Xml.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUnnamedThenReturnsEmpty()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Unnamed;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValueThenReturnsFragment()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Debug;

        var expected = new XElement(nameof(Configurations.BuildType), new XAttribute("Name", "Debug"));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
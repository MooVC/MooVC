namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using System.Collections.Immutable;
using System.Xml.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUnnamedThenReturnsEmpty()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Unnamed;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValueThenReturnsFragment()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Debug;

        var expected = new XElement(nameof(Configurations.BuildType), new XAttribute("Name", "Debug"));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        _ = await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
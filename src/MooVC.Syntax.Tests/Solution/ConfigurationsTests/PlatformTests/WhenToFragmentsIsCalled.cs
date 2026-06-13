namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUnspecifiedThenReturnsEmpty()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.Unspecified;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValueThenReturnsFragment()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.AnyCPU;

        var expected = new XElement(nameof(Configurations.Platform), new XAttribute("Name", "Any CPU"));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        _ = await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
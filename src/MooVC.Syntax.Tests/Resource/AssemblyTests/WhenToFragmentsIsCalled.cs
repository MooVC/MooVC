namespace MooVC.Syntax.Resource.AssemblyTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Assembly subject = Assembly.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
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
        XElement fragment = result.Single();
        _ = await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
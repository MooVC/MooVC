namespace MooVC.Syntax.Attributes.Solution.FileTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        File subject = File.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        var expected = new XElement(
            nameof(File),
            new XAttribute("Path", FileTestsData.DefaultPath));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.Single();
        await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
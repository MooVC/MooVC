namespace MooVC.Syntax.Attributes.Solution.FileTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        File subject = File.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        var expected = new XElement(
            nameof(File),
            new XAttribute("Path", FileTestsData.DefaultPath));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
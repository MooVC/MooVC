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
        File subject = FileTestsData.Create();

        var expected = new XElement(
            nameof(File),
            new XAttribute(nameof(File.Id), FileTestsData.DefaultId),
            new XAttribute(nameof(File.Name), FileTestsData.DefaultName),
            new XAttribute(nameof(File.Path), FileTestsData.DefaultPath));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
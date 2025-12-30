namespace MooVC.Syntax.CSharp.Attributes.Solution.FileTests;

using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        File subject = File.Undefined;

        // Act
        var result = subject.ToFragments();

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
        var result = subject.ToFragments();

        // Assert
        var fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
namespace MooVC.Syntax.CSharp.Attributes.Solution.ProjectTests;

using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        var result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        var expected = new XElement(
            nameof(Project),
            new XAttribute(nameof(Project.Id), ProjectTestsData.DefaultId),
            new XAttribute(nameof(Project.Name), ProjectTestsData.DefaultName),
            new XAttribute(nameof(Project.Path), ProjectTestsData.DefaultPath),
            new XAttribute(nameof(Project.Type), ProjectTestsData.DefaultType));

        // Act
        var result = subject.ToFragments();

        // Assert
        var fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(
            build: Configurations.BuildType.Debug,
            platform: Configurations.Platform.AnyCPU);

        var buildElement = new XElement(
            nameof(Configurations.BuildType),
            new XAttribute("Name", "Debug"));

        var platformElement = new XElement(
            nameof(Configurations.Platform),
            new XAttribute("Name", "Any CPU"));

        var expected = new XElement(
            nameof(Project),
            buildElement,
            new XAttribute(nameof(Project.DisplayName), ProjectTestsData.DefaultName),
            new XAttribute(nameof(Project.Id), ProjectTestsData.DefaultId),
            new XAttribute(nameof(Project.Path), ProjectTestsData.DefaultPath),
            platformElement,
            new XAttribute(nameof(Project.Type), ProjectTestsData.DefaultType));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}
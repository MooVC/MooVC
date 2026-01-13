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
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project subject = ProjectTestsData.Create(build: build, platform: platform);
        var buildElement = new XElement(nameof(Build), new XAttribute(nameof(Build.Project), nameof(Configurations.BuildType.Debug)));
        var platformElement = new XElement(nameof(Platform), new XAttribute(nameof(Platform.Solution), nameof(Configurations.Platform.AnyCPU)));

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
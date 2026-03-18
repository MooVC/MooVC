namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
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
        XElement fragment = result.Single();
        await Assert.That(XNode.DeepEquals(expected, fragment)).IsTrue();
    }
}
namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project subject = ProjectTestsData.Create(build: build, platform: platform);

        var element = new XElement(
            nameof(Project),
            new XElement(nameof(Build), new XAttribute(nameof(Build.Project), nameof(Configurations.BuildType.Debug))),
            new XAttribute(nameof(Project.DisplayName), ProjectTestsData.DefaultName),
            new XAttribute(nameof(Project.Id), ProjectTestsData.DefaultId),
            new XAttribute(nameof(Project.Path), ProjectTestsData.DefaultPath),
            new XElement(nameof(Platform), new XAttribute(nameof(Platform.Solution), nameof(Configurations.Platform.AnyCPU))),
            new XAttribute(nameof(Project.Type), ProjectTestsData.DefaultType));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}
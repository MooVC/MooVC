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
        Project subject = ProjectTestsData.Create(
            build: Configurations.BuildType.Debug,
            platform: Configurations.Platform.AnyCPU);

        var element = new XElement(
            nameof(Project),
            new XElement(nameof(Configurations.BuildType), new XAttribute("Name", "Debug")),
            new XAttribute(nameof(Project.DisplayName), ProjectTestsData.DefaultName),
            new XAttribute(nameof(Project.Id), ProjectTestsData.DefaultId),
            new XAttribute(nameof(Project.Path), ProjectTestsData.DefaultPath),
            new XElement(nameof(Configurations.Platform), new XAttribute("Name", "Any CPU")),
            new XAttribute(nameof(Project.Type), ProjectTestsData.DefaultType));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}
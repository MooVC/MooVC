namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenProjectIsUndefined()
    {
        // Act
        var subject = new Project();

        // Assert
        subject.Id.ShouldBe(Guid.Empty);
        subject.DisplayName.ShouldBe(Project.Name.Unnamed);
        subject.Path.ShouldBe(Project.RelativePath.Unspecified);
        subject.Type.ShouldBe(Snippet.Empty);
        subject.Builds.ShouldBeEmpty();
        subject.Platforms.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };

        var subject = new Project
        {
            Id = ProjectTestsData.DefaultId,
            DisplayName = new Project.Name(ProjectTestsData.DefaultName),
            Path = new Project.RelativePath(ProjectTestsData.DefaultPath),
            Type = Snippet.From(ProjectTestsData.DefaultType),
            Builds = [build],
            Platforms = [platform],
        };

        // Assert
        subject.Id.ShouldBe(ProjectTestsData.DefaultId);
        subject.DisplayName.ShouldBe(new Project.Name(ProjectTestsData.DefaultName));
        subject.Path.ShouldBe(new Project.RelativePath(ProjectTestsData.DefaultPath));
        subject.Type.ShouldBe(Snippet.From(ProjectTestsData.DefaultType));
        subject.Builds.ShouldBe([build]);
        subject.Platforms.ShouldBe([platform]);
        subject.IsUndefined.ShouldBeFalse();
    }
}
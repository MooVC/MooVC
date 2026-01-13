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
        var subject = new Project
        {
            Id = ProjectTestsData.DefaultId,
            DisplayName = new Project.Name(ProjectTestsData.DefaultName),
            Path = new Project.RelativePath(ProjectTestsData.DefaultPath),
            Type = Snippet.From(ProjectTestsData.DefaultType),
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        // Assert
        subject.Id.ShouldBe(ProjectTestsData.DefaultId);
        subject.DisplayName.ShouldBe(new Project.Name(ProjectTestsData.DefaultName));
        subject.Path.ShouldBe(new Project.RelativePath(ProjectTestsData.DefaultPath));
        subject.Type.ShouldBe(Snippet.From(ProjectTestsData.DefaultType));
        subject.Builds.ShouldBe([Configurations.BuildType.Debug]);
        subject.Platforms.ShouldBe([Configurations.Platform.AnyCPU]);
        subject.IsUndefined.ShouldBeFalse();
    }
}
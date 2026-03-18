namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenProjectIsUndefined()
    {
        // Act
        var subject = new Project();

        // Assert
        await Assert.That(subject.Id).IsEqualTo(Guid.Empty);
        await Assert.That(subject.DisplayName).IsEqualTo(Project.Name.Unnamed);
        await Assert.That(subject.Path).IsEqualTo(Project.RelativePath.Unspecified);
        await Assert.That(subject.Type).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Builds).IsEmpty();
        await Assert.That(subject.Platforms).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
        await Assert.That(subject.Id).IsEqualTo(ProjectTestsData.DefaultId);
        await Assert.That(subject.DisplayName).IsEqualTo(new Project.Name(ProjectTestsData.DefaultName));
        await Assert.That(subject.Path).IsEqualTo(new Project.RelativePath(ProjectTestsData.DefaultPath));
        await Assert.That(subject.Type).IsEqualTo(Snippet.From(ProjectTestsData.DefaultType));
        await Assert.That(subject.Builds).IsEqualTo([build]);
        await Assert.That(subject.Platforms).IsEqualTo([platform]);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}
namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = Guid.Parse("D93599B1-587C-450E-9B38-8F04695DB2E1");

        // Act
        Project result = original.WithId(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Id.ShouldBe(updated);
        result.DisplayName.ShouldBe(original.DisplayName);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
        result.Builds.ShouldBe(original.Builds);
        result.Platforms.ShouldBe(original.Platforms);
    }
}
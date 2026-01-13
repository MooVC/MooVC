namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = new Project.Name("OtherName");

        // Act
        Project result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.DisplayName.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
        result.Builds.ShouldBe(original.Builds);
        result.Platforms.ShouldBe(original.Platforms);
    }
}
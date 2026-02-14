namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenAtIsCalled
{
    [Fact]
    public void GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = new Project.RelativePath("src/Other.csproj");

        // Act
        Project result = original.At(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Path.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.DisplayName.ShouldBe(original.DisplayName);
        result.Type.ShouldBe(original.Type);
        result.Builds.ShouldBe(original.Builds);
        result.Platforms.ShouldBe(original.Platforms);
    }
}
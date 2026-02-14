namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax.Elements;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = Snippet.From("Other");

        // Act
        Project result = original.OfType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.DisplayName.ShouldBe(original.DisplayName);
        result.Path.ShouldBe(original.Path);
        result.Builds.ShouldBe(original.Builds);
        result.Platforms.ShouldBe(original.Platforms);
    }
}
namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax.Elements;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create(
            build: Configurations.BuildType.Debug,
            platform: Configurations.Platform.AnyCPU);
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
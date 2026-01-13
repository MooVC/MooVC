namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenAtIsCalled
{
    [Fact]
    public void GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create(
            build: Configurations.BuildType.Debug,
            platform: Configurations.Platform.AnyCPU);
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
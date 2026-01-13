namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create(
            build: Configurations.BuildType.Debug,
            platform: Configurations.Platform.AnyCPU);
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
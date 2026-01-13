namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create(
            build: Configurations.BuildType.Debug,
            platform: Configurations.Platform.AnyCPU);
        Guid updated = Guid.Parse("D93599B1-587C-450E-9B38-8F04695DB2E1");

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
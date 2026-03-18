namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenAtIsCalled
{
    [Test]
    public async Task GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = new Project.RelativePath("src/Other.csproj");

        // Act
        Project result = original.At(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Path).IsEqualTo(updated);
        await Assert.That(result.Id).IsEqualTo(original.Id);
        await Assert.That(result.DisplayName).IsEqualTo(original.DisplayName);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Builds).IsEqualTo(original.Builds);
        await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
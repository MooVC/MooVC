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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Path).IsEqualTo(updated);
        _ = await Assert.That(result.Id).IsEqualTo(original.Id);
        _ = await Assert.That(result.DisplayName).IsEqualTo(original.DisplayName);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(result.Builds).IsEqualTo(original.Builds);
        _ = await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
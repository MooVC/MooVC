namespace MooVC.Syntax.Solution.ProjectTests;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = Snippet.From("Other");

        // Act
        Project result = original.OfType(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Type).IsEqualTo(updated);
        _ = await Assert.That(result.Id).IsEqualTo(original.Id);
        _ = await Assert.That(result.DisplayName).IsEqualTo(original.DisplayName);
        _ = await Assert.That(result.Path).IsEqualTo(original.Path);
        _ = await Assert.That(result.Builds).IsEqualTo(original.Builds);
        _ = await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
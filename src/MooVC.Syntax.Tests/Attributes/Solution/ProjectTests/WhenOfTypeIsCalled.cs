namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Type).IsEqualTo(updated);
        await Assert.That(result.Id).IsEqualTo(original.Id);
        await Assert.That(result.DisplayName).IsEqualTo(original.DisplayName);
        await Assert.That(result.Path).IsEqualTo(original.Path);
        await Assert.That(result.Builds).IsEqualTo(original.Builds);
        await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
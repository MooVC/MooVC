namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = new Project.Name("OtherName");

        // Act
        Project result = original.Named(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.DisplayName).IsEqualTo(updated);
        await Assert.That(result.Id).IsEqualTo(original.Id);
        await Assert.That(result.Path).IsEqualTo(original.Path);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Builds).IsEqualTo(original.Builds);
        await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
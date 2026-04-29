namespace MooVC.Syntax.Solution.ProjectTests;

using System;

public sealed class WhenWithIdIsCalled
{
    [Test]
    public async Task GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        var build = new Build { Project = nameof(Configurations.BuildType.Debug) };
        var platform = new Platform { Solution = nameof(Configurations.Platform.AnyCPU) };
        Project original = ProjectTestsData.Create(build: build, platform: platform);
        var updated = Guid.Parse("D93599B1-587C-450E-9B38-8F04695DB2E1");

        // Act
        Project result = original.WithId(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Id).IsEqualTo(updated);
        _ = await Assert.That(result.DisplayName).IsEqualTo(original.DisplayName);
        _ = await Assert.That(result.Path).IsEqualTo(original.Path);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(result.Builds).IsEqualTo(original.Builds);
        _ = await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
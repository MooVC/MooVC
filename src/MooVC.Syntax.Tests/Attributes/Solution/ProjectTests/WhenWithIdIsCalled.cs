namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Id).IsEqualTo(updated);
        await Assert.That(result.DisplayName).IsEqualTo(original.DisplayName);
        await Assert.That(result.Path).IsEqualTo(original.Path);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Builds).IsEqualTo(original.Builds);
        await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
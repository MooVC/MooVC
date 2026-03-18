namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenWithConfigurationsIsCalled
{
    [Test]
    public async Task GivenConfigurationsThenReturnsUpdatedInstance()
    {
        // Arrange
        Configurations existing = Configurations.Default;

        var updated = new Configurations
        {
            Builds = ["Release"],
            Platforms = ["x64"],
        };

        Solution original = SolutionTestsData.Create(configurations: existing);

        // Act
        Solution result = original.WithConfigurations(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Configurations).IsEqualTo(updated);
        await Assert.That(result.Files).IsEqualTo(original.Files);
    }
}
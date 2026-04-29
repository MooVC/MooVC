namespace MooVC.Syntax.Solution.SolutionTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Configurations).IsEqualTo(updated);
        _ = await Assert.That(result.Files).IsEqualTo(original.Files);
    }
}
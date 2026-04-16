namespace MooVC.Syntax.Solution.ConfigurationsTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenBuildsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Configurations();
        Configurations.BuildType updated = "Custom";

        // Act
        Configurations result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Builds).IsEquivalentTo([.. original.Builds, updated]);
        _ = await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}
namespace MooVC.Syntax.Solution.ConfigurationsTests;

public sealed class WhenForIsCalled
{
    [Test]
    public async Task GivenPlatformsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Configurations();
        Configurations.Platform updated = "x64";

        // Act
        Configurations result = original.For(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Platforms).IsEquivalentTo([.. original.Platforms, updated]);
        _ = await Assert.That(result.Builds).IsEqualTo(original.Builds);
    }
}
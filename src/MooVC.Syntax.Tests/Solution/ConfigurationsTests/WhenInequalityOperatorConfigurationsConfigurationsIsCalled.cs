namespace MooVC.Syntax.Solution.ConfigurationsTests;

public sealed class WhenInequalityOperatorConfigurationsConfigurationsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        var right = new Configurations
        {
            Builds = [Configurations.BuildType.Release],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        var right = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
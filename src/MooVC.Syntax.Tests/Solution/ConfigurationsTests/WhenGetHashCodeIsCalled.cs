namespace MooVC.Syntax.Solution.ConfigurationsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashCodes()
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
        int leftHashCode = left.GetHashCode();
        int rightHashCode = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHashCode).IsNotEqualTo(rightHashCode);
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
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
        int leftHashCode = left.GetHashCode();
        int rightHashCode = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHashCode).IsEqualTo(rightHashCode);
    }
}
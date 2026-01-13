namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorConfigurationsConfigurationsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
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
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
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
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
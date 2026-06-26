namespace MooVC.Syntax.Solution.ConfigurationsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        object other = new Configurations
        {
            Builds = [Configurations.BuildType.Release],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        object other = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonConfigurationsObjectThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations();
        object other = "not-a-configuration";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
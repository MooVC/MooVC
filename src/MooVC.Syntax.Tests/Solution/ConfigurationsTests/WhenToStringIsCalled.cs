namespace MooVC.Syntax.Solution.ConfigurationsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenDefaultThenReturnsEmptyString()
    {
        // Arrange
        var subject = new Configurations();

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenNonDefaultThenReturnsConfigurationElement()
    {
        // Arrange
        var subject = new Configurations
        {
            Builds = [Configurations.BuildType.Debug],
            Platforms = [Configurations.Platform.AnyCPU],
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).Contains("<Configurations>");
        _ = await Assert.That(result).Contains("BuildType");
        _ = await Assert.That(result).Contains("Platform");
    }
}
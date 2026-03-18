namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

public sealed class WhenEqualsPlatformIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        Configurations.Platform? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        var other = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        var other = new Configurations.Platform("OtherPlatform");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

public sealed class WhenEqualityOperatorPlatformPlatformIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Configurations.Platform? left = default;
        Configurations.Platform? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations.Platform("CustomPlatform");
        var right = new Configurations.Platform("OtherPlatform");

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations.Platform("CustomPlatform");
        var right = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

public sealed class WhenInequalityOperatorPlatformStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Configurations.Platform left = Configurations.Platform.ARM64;
        const string right = "x86";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenMatchingValueThenReturnsFalse()
    {
        // Arrange
        Configurations.Platform left = Configurations.Platform.ARM64;
        const string right = "ARM64";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

public sealed class WhenEqualityOperatorPlatformStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Configurations.Platform left = Configurations.Platform.AnyCPU;
        const string right = "x64";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        Configurations.Platform left = Configurations.Platform.AnyCPU;
        const string right = "Any CPU";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
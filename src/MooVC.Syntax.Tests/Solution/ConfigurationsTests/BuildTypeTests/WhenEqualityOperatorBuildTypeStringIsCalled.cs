namespace MooVC.Syntax.Solution.ConfigurationsTests.BuildTypeTests;

public sealed class WhenEqualityOperatorBuildTypeStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Configurations.BuildType left = Configurations.BuildType.Debug;
        const string right = "Release";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        Configurations.BuildType left = Configurations.BuildType.Debug;
        const string right = "Debug";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
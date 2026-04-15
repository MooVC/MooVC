namespace MooVC.Syntax.Solution.ConfigurationsTests.BuildTypeTests;

public sealed class WhenInequalityOperatorBuildTypeStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Configurations.BuildType left = Configurations.BuildType.Release;
        const string right = "Debug";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenMatchingValueThenReturnsFalse()
    {
        // Arrange
        Configurations.BuildType left = Configurations.BuildType.Release;
        const string right = "Release";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
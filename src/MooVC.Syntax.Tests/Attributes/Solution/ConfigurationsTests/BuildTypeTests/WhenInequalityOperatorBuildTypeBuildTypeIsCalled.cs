namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenInequalityOperatorBuildTypeBuildTypeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Configurations.BuildType? left = default;
        Configurations.BuildType? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations.BuildType("Custom");
        var right = new Configurations.BuildType("Custom");

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations.BuildType("Custom");
        var right = new Configurations.BuildType("Other");

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
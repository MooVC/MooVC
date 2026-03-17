namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorBuildTypeBuildTypeIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Configurations.BuildType? left = default;
        Configurations.BuildType? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations.BuildType("Custom");
        var right = new Configurations.BuildType("Custom");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations.BuildType("Custom");
        var right = new Configurations.BuildType("Other");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
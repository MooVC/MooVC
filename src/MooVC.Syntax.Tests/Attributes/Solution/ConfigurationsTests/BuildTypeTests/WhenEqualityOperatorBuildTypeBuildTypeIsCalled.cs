namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorBuildTypeBuildTypeIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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
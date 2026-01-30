namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenInequalityOperatorBuildTypeBuildTypeIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Configurations.BuildType? left = default;
        Configurations.BuildType? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations.BuildType("Custom");
        var right = new Configurations.BuildType("Custom");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations.BuildType("Custom");
        var right = new Configurations.BuildType("Other");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
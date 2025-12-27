namespace MooVC.Syntax.CSharp.Members.ExtensibilityTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Fact]
    public void GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Extensibility? left = default;
        Extensibility right = Extensibility.Static;

        // Act
        bool result = left < right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenHigherRankThenGreaterThanIsTrue()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Abstract;

        // Act
        bool result = left > right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLowerRankThenLessThanIsTrue()
    {
        // Arrange
        Extensibility left = Extensibility.Override;
        Extensibility right = Extensibility.Sealed;

        // Act
        bool result = left < right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenLessThanOrEqualIsTrue()
    {
        // Arrange
        Extensibility left = Extensibility.Virtual;
        Extensibility right = Extensibility.Virtual;

        // Act
        bool result = left <= right;

        // Assert
        result.ShouldBeTrue();
    }
}

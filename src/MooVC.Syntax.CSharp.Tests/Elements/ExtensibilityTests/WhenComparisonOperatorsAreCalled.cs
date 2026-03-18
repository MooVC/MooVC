namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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
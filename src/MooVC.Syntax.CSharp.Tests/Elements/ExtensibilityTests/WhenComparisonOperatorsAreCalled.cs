namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Extensibility? left = default;
        Extensibility right = Extensibility.Static;

        // Act
        bool result = left < right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenHigherRankThenGreaterThanIsTrue()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Abstract;

        // Act
        bool result = left > right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLowerRankThenLessThanIsTrue()
    {
        // Arrange
        Extensibility left = Extensibility.Override;
        Extensibility right = Extensibility.Sealed;

        // Act
        bool result = left < right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenLessThanOrEqualIsTrue()
    {
        // Arrange
        Extensibility left = Extensibility.Virtual;
        Extensibility right = Extensibility.Virtual;

        // Act
        bool result = left <= right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
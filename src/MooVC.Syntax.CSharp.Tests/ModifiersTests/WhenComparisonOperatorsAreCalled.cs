namespace MooVC.Syntax.CSharp.ModifiersTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenEqualValuesThenLessThanOrEqualIsTrue()
    {
        // Arrange
        Modifiers left = Modifiers.Virtual;
        Modifiers right = Modifiers.Virtual;

        // Act
        bool result = left <= right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenHigherRankThenGreaterThanIsTrue()
    {
        // Arrange
        Modifiers left = Modifiers.Static;
        Modifiers right = Modifiers.Abstract;

        // Act
        bool result = left > right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLowerRankThenLessThanIsTrue()
    {
        // Arrange
        Modifiers left = Modifiers.Override;
        Modifiers right = Modifiers.Sealed;

        // Act
        bool result = left < right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Modifiers? left = default;
        Modifiers right = Modifiers.Static;

        // Act
        bool result = left < right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
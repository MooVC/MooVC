namespace MooVC.Syntax.CSharp.ModifiersTests;

public sealed class WhenEqualityOperatorModifiersStringIsCalled
{
    private const string StaticValue = "static";
    private const string OtherValue = "sealed";

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Modifiers subject = Modifiers.Static;

        // Act
        bool result = subject == OtherValue;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        Modifiers subject = Modifiers.Static;

        // Act
        bool result = subject == StaticValue;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullModifiersThenReturnsFalse()
    {
        // Arrange
        Modifiers? subject = default;

        // Act
        bool result = subject == StaticValue;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
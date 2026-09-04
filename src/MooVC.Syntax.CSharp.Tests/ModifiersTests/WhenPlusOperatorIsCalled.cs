namespace MooVC.Syntax.CSharp.ModifiersTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public async Task GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Modifiers left = Modifiers.Static;
        Modifiers right = Modifiers.Override;

        // Act
        Func<Modifiers> result = () => left + right;

        // Assert
        _ = await Assert.That(result).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task GivenNullLeftThenThrows()
    {
        // Arrange
        Modifiers? left = default;
        Modifiers right = Modifiers.Abstract;

        // Act
        Func<Modifiers> result = () => left! + right;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullRightThenThrows()
    {
        // Arrange
        Modifiers left = Modifiers.Static;
        Modifiers? right = default;

        // Act
        Func<Modifiers> result = () => left + right!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSealedOverrideThenCombinedModifiersReturned()
    {
        // Arrange
        Modifiers left = Modifiers.Sealed;
        Modifiers right = Modifiers.Override;

        // Act
        Modifiers result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("sealed override");
    }

    [Test]
    public async Task GivenStaticAbstractThenCombinedModifiersReturned()
    {
        // Arrange
        Modifiers left = Modifiers.Static;
        Modifiers right = Modifiers.Abstract;

        // Act
        Modifiers result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("static abstract");
    }
}
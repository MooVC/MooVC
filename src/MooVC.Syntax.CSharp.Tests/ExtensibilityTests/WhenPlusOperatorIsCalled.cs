namespace MooVC.Syntax.CSharp.ExtensibilityTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public async Task GivenStaticAbstractThenCombinedExtensibilityReturned()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Abstract;

        // Act
        Extensibility result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("static abstract");
    }

    [Test]
    public async Task GivenSealedOverrideThenCombinedExtensibilityReturned()
    {
        // Arrange
        Extensibility left = Extensibility.Sealed;
        Extensibility right = Extensibility.Override;

        // Act
        Extensibility result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("sealed override");
    }

    [Test]
    public async Task GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Override;

        // Act
        Func<Extensibility> result = () => left + right;

        // Assert
        _ = await Assert.That(result).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task GivenNullLeftThenThrows()
    {
        // Arrange
        Extensibility? left = default;
        Extensibility right = Extensibility.Abstract;

        // Act
        Func<Extensibility> result = () => left! + right;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullRightThenThrows()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility? right = default;

        // Act
        Func<Extensibility> result = () => left + right!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}
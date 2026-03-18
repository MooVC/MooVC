namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenEqualityOperatorExtensibilityStringIsCalled
{
    private const string StaticValue = "static";
    private const string OtherValue = "sealed";

    [Test]
    public async Task GivenNullExtensibilityThenReturnsFalse()
    {
        // Arrange
        Extensibility? subject = default;

        // Act
        bool result = subject == StaticValue;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        bool result = subject == StaticValue;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        bool result = subject == OtherValue;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenEqualityOperatorExtensibilityStringIsCalled
{
    private const string StaticValue = "static";
    private const string OtherValue = "sealed";

    [Fact]
    public void GivenNullExtensibilityThenReturnsFalse()
    {
        // Arrange
        Extensibility? subject = default;

        // Act
        bool result = subject == StaticValue;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        bool result = subject == StaticValue;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Extensibility subject = Extensibility.Static;

        // Act
        bool result = subject == OtherValue;

        // Assert
        result.ShouldBeFalse();
    }
}
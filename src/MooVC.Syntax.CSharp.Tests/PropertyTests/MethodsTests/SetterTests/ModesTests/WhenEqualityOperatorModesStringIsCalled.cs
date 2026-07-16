namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests.ModesTests;

public sealed class WhenEqualityOperatorModesStringIsCalled
{
    private const string Same = "Init";
    private const string Different = "Set";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.Init;
        const string right = Different;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.Init;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes? left = default;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.ReadOnly;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
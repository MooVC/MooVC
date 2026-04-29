namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests.ModesTests;

public sealed class WhenInequalityOperatorModesStringIsCalled
{
    private const string Same = "ReadOnly";
    private const string Different = "Set";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.ReadOnly;
        const string right = Different;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.ReadOnly;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes? left = default;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.Init;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
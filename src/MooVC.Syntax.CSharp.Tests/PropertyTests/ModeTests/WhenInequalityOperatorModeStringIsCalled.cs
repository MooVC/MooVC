namespace MooVC.Syntax.CSharp.PropertyTests.ModeTests;

public sealed class WhenInequalityOperatorModeStringIsCalled
{
    private const string Same = "ReadOnly";
    private const string Different = "Set";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Mode? left = default;
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
        Property.Mode left = Property.Mode.ReadOnly;
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
        Property.Mode left = Property.Mode.ReadOnly;
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
        Property.Mode? left = default;
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
        Property.Mode left = Property.Mode.Init;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
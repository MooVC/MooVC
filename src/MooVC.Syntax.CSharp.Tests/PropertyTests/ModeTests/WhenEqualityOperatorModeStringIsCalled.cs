namespace MooVC.Syntax.CSharp.PropertyTests.ModeTests;

public sealed class WhenEqualityOperatorModeStringIsCalled
{
    private const string Same = "Init";
    private const string Different = "Set";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property.Mode? left = default;
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
        Property.Mode left = Property.Mode.Init;
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
        Property.Mode left = Property.Mode.Init;
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
        Property.Mode? left = default;
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
        Property.Mode left = Property.Mode.ReadOnly;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
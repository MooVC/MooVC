namespace MooVC.Syntax.CSharp.PropertyTests.ModeTests;

public sealed class WhenInequalityOperatorModeIntIsCalled
{
    private const int Same = 1;
    private const int Different = 2;

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Mode? left = default;
        int? right = default;

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
        const int right = Same;

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
        int? right = default;

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
        const int right = Same;

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
        const int right = Different;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
namespace MooVC.Syntax.CSharp.ParameterTests.ModeTests;

public sealed class WhenEqualityOperatorModeStringIsCalled
{
    private const string Same = "in";
    private const string Different = "ref";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode? left = default;
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
        Parameter.Mode left = Parameter.Mode.In;
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
        Parameter.Mode left = Parameter.Mode.In;
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
        Parameter.Mode? left = default;
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
        Parameter.Mode left = Parameter.Mode.In;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
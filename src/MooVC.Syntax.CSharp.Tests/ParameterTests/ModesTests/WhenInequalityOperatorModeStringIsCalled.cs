namespace MooVC.Syntax.CSharp.ParameterTests.ModesTests;

public sealed class WhenInequalityOperatorModeStringIsCalled
{
    private const string Same = "out";
    private const string Different = "ref";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Parameter.Modes? left = default;
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
        Parameter.Modes left = Parameter.Modes.In;
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
        Parameter.Modes left = Parameter.Modes.Out;
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
        Parameter.Modes? left = default;
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
        Parameter.Modes left = Parameter.Modes.Out;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
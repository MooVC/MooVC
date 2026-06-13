namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenEqualityOperatorModeStringIsCalled
{
    private const string Same = "in";
    private const string Different = "out";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Argument.Modes? left = default;
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
        Argument.Modes left = Argument.Modes.In;
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
        Argument.Modes left = Argument.Modes.In;
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
        Argument.Modes? left = default;
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
        Argument.Modes left = Argument.Modes.In;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenInequalityOperatorModeStringIsCalled
{
    private const string Same = "in";
    private const string Different = "out";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Argument.Modes? left = default;
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
        Argument.Modes left = Argument.Modes.In;
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
        Argument.Modes left = Argument.Modes.In;
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
        Argument.Modes? left = default;
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
        Argument.Modes left = Argument.Modes.In;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
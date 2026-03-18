namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenInequalityOperatorModeStringIsCalled
{
    private const string Same = "out";
    private const string Different = "ref";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode? left = default;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.Out;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.Out;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.In;
        const string right = Different;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsTrue();
    }
}
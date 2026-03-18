namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenEqualityOperatorModeStringIsCalled
{
    private const string Same = "in";
    private const string Different = "out";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Argument.Mode? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Argument.Mode? left = default;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.In;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.In;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.In;
        const string right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
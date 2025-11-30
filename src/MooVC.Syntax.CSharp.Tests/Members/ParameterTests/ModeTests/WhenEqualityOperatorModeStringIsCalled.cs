namespace MooVC.Syntax.CSharp.Members.ParameterTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorModeStringIsCalled
{
    private const string Same = "in";
    private const string Different = "ref";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode? left = default;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.In;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.In;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.In;
        const string right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

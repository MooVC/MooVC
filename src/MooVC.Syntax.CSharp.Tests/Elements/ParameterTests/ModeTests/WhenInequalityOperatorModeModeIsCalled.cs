namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenInequalityOperatorModeModeIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode? left = default;
        Parameter.Mode? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode? left = default;
        Parameter.Mode right = Parameter.Mode.Ref;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.Ref;
        Parameter.Mode? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.Out;
        Parameter.Mode right = Parameter.Mode.Out;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.RefReadonly;
        Parameter.Mode right = Parameter.Mode.None;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
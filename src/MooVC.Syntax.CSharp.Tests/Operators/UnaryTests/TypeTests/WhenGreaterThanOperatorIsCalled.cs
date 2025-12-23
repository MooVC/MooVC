namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenGreaterThanOperatorIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Unary.Type? leftType = default;
        Unary.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Unary.Type? leftType = default;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        bool result = leftType > rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSmallerLeftThenReturnsFalse()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Not;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        bool result = leftType > rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLargerLeftThenReturnsTrue()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type rightType = Unary.Type.Not;

        // Act
        bool result = leftType > rightType;

        // Assert
        result.ShouldBeTrue();
    }
}

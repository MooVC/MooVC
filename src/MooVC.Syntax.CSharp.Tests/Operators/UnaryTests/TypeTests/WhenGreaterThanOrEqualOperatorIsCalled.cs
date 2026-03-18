namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenGreaterThanOrEqualOperatorIsCalled
{
    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Unary.Type? leftType = default;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type? rightType = default;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeTrue();
    }
}
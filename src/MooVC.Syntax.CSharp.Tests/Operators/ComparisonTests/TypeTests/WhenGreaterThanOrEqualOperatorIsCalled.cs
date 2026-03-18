namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenGreaterThanOrEqualOperatorIsCalled
{
    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeTrue();
    }
}
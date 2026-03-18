namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenLessThanOrEqualOperatorIsCalled
{
    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType <= rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType <= rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType <= rightType;

        // Assert
        result.ShouldBeTrue();
    }
}
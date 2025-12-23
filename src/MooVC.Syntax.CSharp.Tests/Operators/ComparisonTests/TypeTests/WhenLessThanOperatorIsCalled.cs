namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenLessThanOperatorIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSmallerLeftThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Inequality;
        Comparison.Type rightType = Comparison.Type.LessThan;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLargerLeftThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.LessThan;
        Comparison.Type rightType = Comparison.Type.Inequality;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeFalse();
    }
}

namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenGreaterThanOrEqualOperatorIsCalled
{
    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Binary.Type? leftType = default;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type? rightType = default;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType >= rightType;

        // Assert
        result.ShouldBeTrue();
    }
}

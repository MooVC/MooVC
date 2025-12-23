namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenLessThanOperatorIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Binary.Type? leftType = default;
        Binary.Type? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Binary.Type? leftType = default;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSmallerLeftThenReturnsTrue()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Subtract;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLargerLeftThenReturnsFalse()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Subtract;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType < rightType;

        // Assert
        result.ShouldBeFalse();
    }
}

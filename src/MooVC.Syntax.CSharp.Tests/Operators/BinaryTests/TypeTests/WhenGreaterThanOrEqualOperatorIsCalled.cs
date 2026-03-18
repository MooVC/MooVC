namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenGreaterThanOrEqualOperatorIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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
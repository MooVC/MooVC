namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenLessThanOrEqualOperatorIsCalled
{
    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Binary.Type? leftType = default;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type? rightType = default;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
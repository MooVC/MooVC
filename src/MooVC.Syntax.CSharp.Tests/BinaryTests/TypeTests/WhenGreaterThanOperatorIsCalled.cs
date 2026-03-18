namespace MooVC.Syntax.CSharp.BinaryTests.TypeTests;

public sealed class WhenGreaterThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Binary.Type? leftType = default;
        Binary.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Binary.Type? leftType = default;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsFalse()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Subtract;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsTrue()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Subtract;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
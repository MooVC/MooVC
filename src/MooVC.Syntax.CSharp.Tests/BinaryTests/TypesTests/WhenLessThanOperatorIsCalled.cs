namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenLessThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Binary.Types? leftType = default;
        Binary.Types? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsFalse()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Subtract;
        Binary.Types rightType = Binary.Types.Add;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Binary.Types? leftType = default;
        Binary.Types rightType = Binary.Types.Add;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Add;
        Binary.Types? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsTrue()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Add;
        Binary.Types rightType = Binary.Types.Subtract;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
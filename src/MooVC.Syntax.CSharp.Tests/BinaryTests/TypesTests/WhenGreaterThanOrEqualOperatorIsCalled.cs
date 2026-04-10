namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenGreaterThanOrEqualOperatorIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Add;
        Binary.Types rightType = Binary.Types.Add;

        // Act
        bool result = leftType >= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Binary.Types? leftType = default;
        Binary.Types rightType = Binary.Types.Add;

        // Act
        bool result = leftType >= rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Add;
        Binary.Types? rightType = default;

        // Act
        bool result = leftType >= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
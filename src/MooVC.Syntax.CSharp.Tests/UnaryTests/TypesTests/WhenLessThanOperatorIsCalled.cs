namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenLessThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Unary.Types? leftType = default;
        Unary.Types? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsFalse()
    {
        // Arrange
        Unary.Types leftType = Unary.Types.Plus;
        Unary.Types rightType = Unary.Types.Not;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Unary.Types? leftType = default;
        Unary.Types rightType = Unary.Types.Plus;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Unary.Types leftType = Unary.Types.Plus;
        Unary.Types? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsTrue()
    {
        // Arrange
        Unary.Types leftType = Unary.Types.Not;
        Unary.Types rightType = Unary.Types.Plus;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
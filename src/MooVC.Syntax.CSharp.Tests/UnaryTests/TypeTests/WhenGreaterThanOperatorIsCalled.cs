namespace MooVC.Syntax.CSharp.UnaryTests.TypeTests;

public sealed class WhenGreaterThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Unary.Type? leftType = default;
        Unary.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsTrue()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type rightType = Unary.Type.Not;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Unary.Type? leftType = default;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsFalse()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Not;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
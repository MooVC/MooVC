namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenLessThanOrEqualOperatorIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Unary.Types leftType = Unary.Types.Plus;
        Unary.Types rightType = Unary.Types.Plus;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Unary.Types? leftType = default;
        Unary.Types rightType = Unary.Types.Plus;

        // Act
        bool result = leftType <= rightType;

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
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenGreaterThanOrEqualOperatorIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Equality;
        Comparison.Types rightType = Comparison.Types.Equality;

        // Act
        bool result = leftType >= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Types? leftType = default;
        Comparison.Types rightType = Comparison.Types.Equality;

        // Act
        bool result = leftType >= rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Equality;
        Comparison.Types? rightType = default;

        // Act
        bool result = leftType >= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
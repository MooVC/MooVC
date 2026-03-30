namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenLessThanOrEqualOperatorIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType <= rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenLessThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType < rightType;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Inequality;
        Comparison.Type rightType = Comparison.Type.LessThan;

        // Act
        bool result = leftType < rightType;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.LessThan;
        Comparison.Type rightType = Comparison.Type.Inequality;

        // Act
        bool result = leftType < rightType;

        // Assert
        await Assert.That(result).IsFalse();
    }
}
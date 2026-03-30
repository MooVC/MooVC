namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenGreaterThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.LessThan;
        Comparison.Type rightType = Comparison.Type.Inequality;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? leftType = default;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsFalse()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Inequality;
        Comparison.Type rightType = Comparison.Type.LessThan;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
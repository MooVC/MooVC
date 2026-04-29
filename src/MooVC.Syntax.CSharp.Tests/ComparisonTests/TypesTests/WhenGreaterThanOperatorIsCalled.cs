namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenGreaterThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Types? leftType = default;
        Comparison.Types? rightType = default;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsTrue()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.LessThan;
        Comparison.Types rightType = Comparison.Types.Inequality;

        // Act
        bool result = leftType > rightType;

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
        bool result = leftType > rightType;

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
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsFalse()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Inequality;
        Comparison.Types rightType = Comparison.Types.LessThan;

        // Act
        bool result = leftType > rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
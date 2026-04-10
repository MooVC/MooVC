namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenLessThanOperatorIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Types? leftType = default;
        Comparison.Types? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLargerLeftThenReturnsFalse()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.LessThan;
        Comparison.Types rightType = Comparison.Types.Inequality;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Types? leftType = default;
        Comparison.Types rightType = Comparison.Types.Equality;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Equality;
        Comparison.Types? rightType = default;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSmallerLeftThenReturnsTrue()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Inequality;
        Comparison.Types rightType = Comparison.Types.LessThan;

        // Act
        bool result = leftType < rightType;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
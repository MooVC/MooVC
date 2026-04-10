namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Inequality;
        Comparison.Types rightType = Comparison.Types.LessThan;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsLessThan(0);
        _ = await Assert.That(resultRightLeft).IsGreaterThan(0);
    }

    [Test]
    public async Task GivenNullOtherThenReturnsPositiveOne()
    {
        // Arrange
        Comparison.Types subject = Comparison.Types.Equality;
        Comparison.Types? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(1);
    }

    [Test]
    public async Task GivenSameValueThenReturnsZero()
    {
        // Arrange
        Comparison.Types leftType = Comparison.Types.Equality;
        Comparison.Types rightType = Comparison.Types.Equality;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsEqualTo(0);
        _ = await Assert.That(resultRightLeft).IsEqualTo(0);
    }
}
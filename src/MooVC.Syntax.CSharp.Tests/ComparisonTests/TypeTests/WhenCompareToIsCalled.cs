namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Inequality;
        Comparison.Type rightType = Comparison.Type.LessThan;

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
        Comparison.Type subject = Comparison.Type.Equality;
        Comparison.Type? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(1);
    }

    [Test]
    public async Task GivenSameValueThenReturnsZero()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type rightType = Comparison.Type.Equality;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsEqualTo(0);
        _ = await Assert.That(resultRightLeft).IsEqualTo(0);
    }
}
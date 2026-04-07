namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Unary.Types leftType = Unary.Types.Not;
        Unary.Types rightType = Unary.Types.Plus;

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
        Unary.Types subject = Unary.Types.Plus;
        Unary.Types? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(1);
    }

    [Test]
    public async Task GivenSameValueThenReturnsZero()
    {
        // Arrange
        Unary.Types leftType = Unary.Types.Plus;
        Unary.Types rightType = Unary.Types.Plus;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsEqualTo(0);
        _ = await Assert.That(resultRightLeft).IsEqualTo(0);
    }
}
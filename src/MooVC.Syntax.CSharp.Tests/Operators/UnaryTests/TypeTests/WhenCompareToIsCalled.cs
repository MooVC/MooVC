namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenNullOtherThenReturnsPositiveOne()
    {
        // Arrange
        Unary.Type subject = Unary.Type.Plus;
        Unary.Type? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        await Assert.That(result).IsEqualTo(1);
    }

    [Test]
    public async Task GivenSameValueThenReturnsZero()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        await Assert.That(resultLeftRight).IsEqualTo(0);
        await Assert.That(resultRightLeft).IsEqualTo(0);
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Not;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        await Assert.That(resultLeftRight).IsLessThan(0);
        await Assert.That(resultRightLeft).IsGreaterThan(0);
    }
}
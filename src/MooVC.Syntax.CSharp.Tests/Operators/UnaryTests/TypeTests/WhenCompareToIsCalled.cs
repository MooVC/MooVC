namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenCompareToIsCalled
{
    [Fact]
    public void GivenNullOtherThenReturnsPositiveOne()
    {
        // Arrange
        Unary.Type subject = Unary.Type.Plus;
        Unary.Type? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        result.ShouldBe(1);
    }

    [Fact]
    public void GivenSameValueThenReturnsZero()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Plus;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        resultLeftRight.ShouldBe(0);
        resultRightLeft.ShouldBe(0);
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Unary.Type leftType = Unary.Type.Not;
        Unary.Type rightType = Unary.Type.Plus;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        resultLeftRight.ShouldBeLessThan(0);
        resultRightLeft.ShouldBeGreaterThan(0);
    }
}
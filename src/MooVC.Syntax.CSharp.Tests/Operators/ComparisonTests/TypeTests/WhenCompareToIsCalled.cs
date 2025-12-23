namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenCompareToIsCalled
{
    [Fact]
    public void GivenNullOtherThenReturnsPositiveOne()
    {
        // Arrange
        Comparison.Type subject = Comparison.Type.Equality;
        Comparison.Type? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        result.ShouldBe(1);
    }

    [Fact]
    public void GivenSameValueThenReturnsZero()
    {
        // Arrange
        Comparison.Type leftType = Comparison.Type.Equality;
        Comparison.Type rightType = Comparison.Type.Equality;

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
        Comparison.Type leftType = Comparison.Type.Inequality;
        Comparison.Type rightType = Comparison.Type.LessThan;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        resultLeftRight.ShouldBeLessThan(0);
        resultRightLeft.ShouldBeGreaterThan(0);
    }
}

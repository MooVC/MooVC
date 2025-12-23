namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenCompareToIsCalled
{
    [Fact]
    public void GivenNullOtherThenReturnsPositiveOne()
    {
        // Arrange
        Binary.Type subject = Binary.Type.Add;
        Binary.Type? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        result.ShouldBe(1);
    }

    [Fact]
    public void GivenSameValueThenReturnsZero()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Add;

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
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Subtract;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        resultLeftRight.ShouldBeLessThan(0);
        resultRightLeft.ShouldBeGreaterThan(0);
    }
}

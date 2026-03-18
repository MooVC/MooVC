namespace MooVC.Syntax.CSharp.BinaryTests.TypeTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenNullOtherThenReturnsPositiveOne()
    {
        // Arrange
        Binary.Type subject = Binary.Type.Add;
        Binary.Type? other = default;

        // Act
        int result = subject.CompareTo(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(1);
    }

    [Test]
    public async Task GivenSameValueThenReturnsZero()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Add;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsEqualTo(0);
        _ = await Assert.That(resultRightLeft).IsEqualTo(0);
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Binary.Type leftType = Binary.Type.Add;
        Binary.Type rightType = Binary.Type.Subtract;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsLessThan(0);
        _ = await Assert.That(resultRightLeft).IsGreaterThan(0);
    }
}
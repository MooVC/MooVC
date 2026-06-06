namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsExpectedOrder()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Add;
        Binary.Types rightType = Binary.Types.Subtract;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsGreaterThan(0);
        _ = await Assert.That(resultRightLeft).IsLessThan(0);
    }

    [Test]
    public async Task GivenSameValueThenReturnsZero()
    {
        // Arrange
        Binary.Types leftType = Binary.Types.Add;
        Binary.Types rightType = Binary.Types.Add;

        // Act
        int resultLeftRight = leftType.CompareTo(rightType);
        int resultRightLeft = rightType.CompareTo(leftType);

        // Assert
        _ = await Assert.That(resultLeftRight).IsEqualTo(0);
        _ = await Assert.That(resultRightLeft).IsEqualTo(0);
    }
}
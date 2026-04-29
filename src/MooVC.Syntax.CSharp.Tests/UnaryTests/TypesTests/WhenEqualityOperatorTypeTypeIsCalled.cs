namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenEqualityOperatorTypeTypeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Unary.Types? left = default;
        Unary.Types? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Unary.Types left = Unary.Types.Not;
        Unary.Types right = Unary.Types.Increment;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenSameValuesThenReturnsTrue()
    {
        // Arrange
        Unary.Types left = Unary.Types.Not;
        Unary.Types right = Unary.Types.Not;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}
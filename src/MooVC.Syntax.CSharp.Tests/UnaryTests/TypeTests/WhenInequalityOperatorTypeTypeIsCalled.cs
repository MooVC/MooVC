namespace MooVC.Syntax.CSharp.UnaryTests.TypeTests;

public sealed class WhenInequalityOperatorTypeTypeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Unary.Type? left = default;
        Unary.Type? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameValuesThenReturnsFalse()
    {
        // Arrange
        Unary.Type left = Unary.Type.Not;
        Unary.Type right = Unary.Type.Not;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Unary.Type left = Unary.Type.Not;
        Unary.Type right = Unary.Type.Increment;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}
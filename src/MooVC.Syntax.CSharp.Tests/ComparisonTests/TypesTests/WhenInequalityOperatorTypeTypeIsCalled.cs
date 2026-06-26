namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenInequalityOperatorTypeTypeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Types? left = default;
        Comparison.Types? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Types left = Comparison.Types.Equality;
        Comparison.Types right = Comparison.Types.Inequality;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenSameValuesThenReturnsFalse()
    {
        // Arrange
        Comparison.Types left = Comparison.Types.Equality;
        Comparison.Types right = Comparison.Types.Equality;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}
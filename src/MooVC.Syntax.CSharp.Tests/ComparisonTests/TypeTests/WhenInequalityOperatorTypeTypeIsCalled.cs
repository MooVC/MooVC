namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenInequalityOperatorTypeTypeIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? left = default;
        Comparison.Type? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameValuesThenReturnsFalse()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.Equality;
        Comparison.Type right = Comparison.Type.Equality;

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
        Comparison.Type left = Comparison.Type.Equality;
        Comparison.Type right = Comparison.Type.Inequality;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}
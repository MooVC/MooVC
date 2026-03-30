namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenEqualityOperatorTypeTypeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.GreaterThan;
        Comparison.Type right = Comparison.Type.LessThan;

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
        Comparison.Type left = Comparison.Type.GreaterThan;
        Comparison.Type right = Comparison.Type.GreaterThan;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}
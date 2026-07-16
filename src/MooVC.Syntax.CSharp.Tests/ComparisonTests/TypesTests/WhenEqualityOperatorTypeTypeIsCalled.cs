namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenEqualityOperatorTypeTypeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Comparison.Types left = Comparison.Types.GreaterThan;
        Comparison.Types right = Comparison.Types.LessThan;

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
        Comparison.Types left = Comparison.Types.GreaterThan;
        Comparison.Types right = Comparison.Types.GreaterThan;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}
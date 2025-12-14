namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualityOperatorTypeTypeIsCalled
{
    [Fact]
    public void GivenSameValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.GreaterThan;
        Comparison.Type right = Comparison.Type.GreaterThan;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.GreaterThan;
        Comparison.Type right = Comparison.Type.LessThan;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
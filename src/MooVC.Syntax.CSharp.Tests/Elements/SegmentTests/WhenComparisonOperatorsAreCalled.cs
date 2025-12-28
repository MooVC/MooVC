namespace MooVC.Syntax.CSharp.Elements.SegmentTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Fact]
    public void GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Segment? left = default;
        Segment right = "Alpha";

        // Act
        bool lessThan = left < right;
        bool greaterThan = left > right;
        bool lessThanOrEqual = left <= right;
        bool greaterThanOrEqual = left >= right;

        // Assert
        lessThan.ShouldBeTrue();
        greaterThan.ShouldBeFalse();
        lessThanOrEqual.ShouldBeTrue();
        greaterThanOrEqual.ShouldBeFalse();
    }

    [Fact]
    public void GivenAlphabeticalValuesThenOrderingMatchesOrdinalComparison()
    {
        // Arrange
        Segment left = "Alpha";
        Segment right = "Beta";

        // Act
        bool lessThan = left < right;
        bool greaterThan = left > right;
        bool lessThanOrEqual = left <= right;
        bool greaterThanOrEqual = left >= right;

        // Assert
        lessThan.ShouldBeTrue();
        greaterThan.ShouldBeFalse();
        lessThanOrEqual.ShouldBeTrue();
        greaterThanOrEqual.ShouldBeFalse();
    }
}
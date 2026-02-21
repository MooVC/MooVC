namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Fact]
    public void GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Name? left = default;
        Name right = "Alpha";

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
        Name left = "Alpha";
        Name right = "Beta";

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
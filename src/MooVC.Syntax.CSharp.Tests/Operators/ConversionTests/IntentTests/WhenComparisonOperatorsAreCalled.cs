namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Fact]
    public void GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Conversion.Intent? left = default;
        Conversion.Intent right = Conversion.Intent.From;

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
    public void GivenFromAndToThenOrderingReflectsValues()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.To;

        // Act
        bool greaterThan = left > right;
        bool lessThan = left < right;
        bool greaterThanOrEqual = left >= right;
        bool lessThanOrEqual = left <= right;

        // Assert
        greaterThan.ShouldBeTrue();
        lessThan.ShouldBeFalse();
        greaterThanOrEqual.ShouldBeTrue();
        lessThanOrEqual.ShouldBeFalse();
    }
}
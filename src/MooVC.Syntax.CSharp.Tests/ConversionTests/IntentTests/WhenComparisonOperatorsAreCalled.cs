namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenFromAndToThenOrderingReflectsValues()
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
        _ = await Assert.That(greaterThan).IsFalse();
        _ = await Assert.That(lessThan).IsTrue();
        _ = await Assert.That(greaterThanOrEqual).IsFalse();
        _ = await Assert.That(lessThanOrEqual).IsTrue();
    }

    [Test]
    public async Task GivenNullLeftThenLessThanIsTrue()
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
        _ = await Assert.That(lessThan).IsTrue();
        _ = await Assert.That(greaterThan).IsFalse();
        _ = await Assert.That(lessThanOrEqual).IsTrue();
        _ = await Assert.That(greaterThanOrEqual).IsFalse();
    }
}
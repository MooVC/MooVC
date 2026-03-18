namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenComparisonOperatorsAreCalled
{
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
        await Assert.That(lessThan).IsTrue();
        await Assert.That(greaterThan).IsFalse();
        await Assert.That(lessThanOrEqual).IsTrue();
        await Assert.That(greaterThanOrEqual).IsFalse();
    }

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
        await Assert.That(greaterThan).IsTrue();
        await Assert.That(lessThan).IsFalse();
        await Assert.That(greaterThanOrEqual).IsTrue();
        await Assert.That(lessThanOrEqual).IsFalse();
    }
}
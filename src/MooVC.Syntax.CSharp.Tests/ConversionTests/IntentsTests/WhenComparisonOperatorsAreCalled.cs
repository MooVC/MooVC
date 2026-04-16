namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenFromAndToThenOrderingReflectsValues()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        Conversion.Intents right = Conversion.Intents.To;

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
        Conversion.Intents? left = default;
        Conversion.Intents right = Conversion.Intents.From;

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
namespace MooVC.Syntax.NameTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenAlphabeticalValuesThenOrderingMatchesOrdinalComparison()
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
        _ = await Assert.That(lessThan).IsTrue();
        _ = await Assert.That(greaterThan).IsFalse();
        _ = await Assert.That(lessThanOrEqual).IsTrue();
        _ = await Assert.That(greaterThanOrEqual).IsFalse();
    }

    [Test]
    public async Task GivenNullLeftThenLessThanIsTrue()
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
        _ = await Assert.That(lessThan).IsTrue();
        _ = await Assert.That(greaterThan).IsFalse();
        _ = await Assert.That(lessThanOrEqual).IsTrue();
        _ = await Assert.That(greaterThanOrEqual).IsFalse();
    }
}
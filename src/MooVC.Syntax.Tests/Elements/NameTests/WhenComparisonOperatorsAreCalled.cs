namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenComparisonOperatorsAreCalled
{
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
        await Assert.That(lessThan).IsTrue();
        await Assert.That(greaterThan).IsFalse();
        await Assert.That(lessThanOrEqual).IsTrue();
        await Assert.That(greaterThanOrEqual).IsFalse();
    }

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
        await Assert.That(lessThan).IsTrue();
        await Assert.That(greaterThan).IsFalse();
        await Assert.That(lessThanOrEqual).IsTrue();
        await Assert.That(greaterThanOrEqual).IsFalse();
    }
}
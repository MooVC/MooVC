namespace MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Symbol? left = default;
        Symbol right = SymbolTestsData.Create(name: "Beta");

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
    public async Task GivenDifferentNamesThenOrderingFollowsName()
    {
        // Arrange
        Symbol left = SymbolTestsData.Create(name: "Alpha");
        Symbol right = SymbolTestsData.Create(name: "Beta");

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
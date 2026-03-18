namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Test]
    public async Task GivenNullLeftThenLessThanIsTrue()
    {
        // Arrange
        Scope? left = default;
        Scope right = Scope.Public;

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
    public async Task GivenPrivateAndPublicThenOrderingReflectsAccessibility()
    {
        // Arrange
        Scope left = Scope.Private;
        Scope right = Scope.Public;

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
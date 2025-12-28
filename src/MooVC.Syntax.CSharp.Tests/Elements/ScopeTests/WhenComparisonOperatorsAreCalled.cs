namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Fact]
    public void GivenNullLeftThenLessThanIsTrue()
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
        lessThan.ShouldBeTrue();
        greaterThan.ShouldBeFalse();
        lessThanOrEqual.ShouldBeTrue();
        greaterThanOrEqual.ShouldBeFalse();
    }

    [Fact]
    public void GivenPrivateAndPublicThenOrderingReflectsAccessibility()
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
        lessThan.ShouldBeTrue();
        greaterThan.ShouldBeFalse();
        lessThanOrEqual.ShouldBeTrue();
        greaterThanOrEqual.ShouldBeFalse();
    }
}
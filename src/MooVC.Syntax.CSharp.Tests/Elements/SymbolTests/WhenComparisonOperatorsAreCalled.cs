namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenComparisonOperatorsAreCalled
{
    [Fact]
    public void GivenNullLeftThenLessThanIsTrue()
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
        lessThan.ShouldBeTrue();
        greaterThan.ShouldBeFalse();
        lessThanOrEqual.ShouldBeTrue();
        greaterThanOrEqual.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentNamesThenOrderingFollowsName()
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
        lessThan.ShouldBeTrue();
        greaterThan.ShouldBeFalse();
        lessThanOrEqual.ShouldBeTrue();
        greaterThanOrEqual.ShouldBeFalse();
    }
}
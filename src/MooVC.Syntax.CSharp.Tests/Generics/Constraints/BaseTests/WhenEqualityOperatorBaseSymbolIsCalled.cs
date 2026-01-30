namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorBaseSymbolIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothSidesAreNullThenReturnsTrue()
    {
        // Arrange
        Base? left = default;
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherSideIsNullThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = new Variable(Same) };
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = new Variable(Same) };
        var right = new Symbol { Name = new Variable(Same) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = new Variable(Same) };
        var right = new Symbol { Name = new Variable(Different) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
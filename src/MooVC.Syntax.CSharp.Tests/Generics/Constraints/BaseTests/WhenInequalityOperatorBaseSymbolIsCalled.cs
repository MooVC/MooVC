namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorBaseSymbolIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothSidesAreNullThenReturnsFalse()
    {
        // Arrange
        Base? left = default;
        Symbol? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEitherSideIsNullThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = new Identifier(Same) };
        Symbol? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = new Identifier(Same) };
        var right = new Symbol { Name = new Identifier(Same) };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = new Identifier(Same) };
        var right = new Symbol { Name = new Identifier(Different) };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
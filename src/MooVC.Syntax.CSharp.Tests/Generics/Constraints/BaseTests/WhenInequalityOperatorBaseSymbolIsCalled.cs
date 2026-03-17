namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenInequalityOperatorBaseSymbolIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
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

    [Test]
    public void GivenEitherSideIsNullThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Symbol? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        var right = new Symbol { Name = Same };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        var right = new Symbol { Name = Different };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenEqualityOperatorConstraintConstraintIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Constraint? left = default;
        Constraint? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Constraint? left = default;
        var right = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
        Constraint? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
        Constraint second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
        var right = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames(SymbolTestsData.DefaultName)) };
        var right = new Constraint { Nature = Nature.Class };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
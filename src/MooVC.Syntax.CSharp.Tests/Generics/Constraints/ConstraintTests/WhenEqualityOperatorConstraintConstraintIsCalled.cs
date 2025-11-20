namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

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
        Constraint right = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Constraint left = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
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
        Constraint first = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
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
        Constraint left = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
        Constraint right = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Constraint left = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames(SymbolTestsData.DefaultName)) };
        Constraint right = new Constraint { Nature = Nature.Class };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

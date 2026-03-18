namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenEqualityOperatorConstraintConstraintIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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
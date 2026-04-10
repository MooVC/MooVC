namespace MooVC.Syntax.CSharp.ConstraintTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenEqualityOperatorConstraintConstraintIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Constraint? left = default;
        Constraint? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Constraint { Base = SymbolTestsData.CreateWithArgumentNames(SymbolTestsData.DefaultName) };
        var right = new Constraint { Nature = Nature.Class };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Constraint { Base = SymbolTestsData.CreateWithArgumentNames() };
        var right = new Constraint { Base = SymbolTestsData.CreateWithArgumentNames() };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Constraint? left = default;
        var right = new Constraint { Base = SymbolTestsData.CreateWithArgumentNames() };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Constraint { Base = SymbolTestsData.CreateWithArgumentNames() };
        Constraint? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Constraint { Base = SymbolTestsData.CreateWithArgumentNames() };
        Constraint second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
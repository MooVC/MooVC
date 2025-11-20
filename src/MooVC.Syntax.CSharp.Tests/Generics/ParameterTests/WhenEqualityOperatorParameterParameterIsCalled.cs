namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Generics.Constraints;

public sealed class WhenEqualityOperatorParameterParameterIsCalled
{
    private const string AlternativeName = "TOther";
    private const string DefaultName = "TValue";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Parameter? left = default;
        Parameter? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Parameter? left = default;
        Parameter right = Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Parameter left = Create();
        Parameter? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Parameter first = Create();
        Parameter second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter left = Create();
        Parameter right = Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Parameter left = Create();
        Parameter right = Create(AlternativeName);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentConstraintsThenReturnsFalse()
    {
        // Arrange
        Parameter left = Create();
        Parameter right = Create(constraint: Constraint.Unspecified);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    private static Parameter Create(string name = DefaultName, Constraint? constraint = null)
    {
        return new Parameter
        {
            Name = new Identifier(name),
            Constraints = constraint is null
                ? [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }]
                : [constraint],
        };
    }
}

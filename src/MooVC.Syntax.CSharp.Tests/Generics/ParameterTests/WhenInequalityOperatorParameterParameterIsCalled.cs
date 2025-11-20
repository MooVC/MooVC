namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Generics.Constraints;

public sealed class WhenInequalityOperatorParameterParameterIsCalled
{
    private const string DefaultName = "TValue";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Parameter? left = default;
        Parameter? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Parameter? left = default;
        Parameter right = Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Parameter left = Create();
        Parameter? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Parameter left = Create();
        Parameter right = Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Parameter left = Create();
        Parameter right = Create(name: DefaultName + "Alt");

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    private static Parameter Create(string name = DefaultName)
    {
        return new Parameter
        {
            Name = new Identifier(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}

namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenEqualityOperatorSymbolSymbolIsCalled
{
    private const string AlternativeName = "Alternate";
    private static readonly string[] arguments = ["Inner", "Outer"];

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Symbol? left = default;
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Symbol? left = default;
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Symbol first = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol right = SymbolTestsData.CreateWithArgumentNames(AlternativeName, arguments);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments[0]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorFromSymbolIsCalled
{
    private const string Name = "Alpha";

    [Fact]
    public void GivenSymbolThenReturnsBase()
    {
        // Arrange
        var symbol = new Symbol { Name = new Variable(Name) };

        // Act
        Base @base = symbol;
        bool areEqual = @base == symbol;

        // Assert
        _ = @base.ShouldNotBeNull();
        areEqual.ShouldBeTrue();
    }
}
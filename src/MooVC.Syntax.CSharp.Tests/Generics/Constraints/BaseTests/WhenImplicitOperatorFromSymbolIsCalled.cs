namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorFromSymbolIsCalled
{
    private const string Name = "Alpha";

    [Fact]
    public void GivenSymbolThenReturnsBase()
    {
        // Arrange
        var symbol = new Symbol { Name = new Identifier(Name) };

        // Act
        Base @base = symbol;

        // Assert
        @base.ShouldBe(symbol);
    }
}

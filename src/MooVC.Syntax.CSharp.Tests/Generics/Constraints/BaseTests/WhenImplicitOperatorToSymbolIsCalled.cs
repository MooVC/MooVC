namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToSymbolIsCalled
{
    private const string Name = "Alpha";

    [Fact]
    public void GivenBaseThenReturnsSymbol()
    {
        // Arrange
        var name = new Identifier(Name);
        Base subject = new Symbol { Name = name };

        // Act
        Symbol value = subject;

        // Assert
        value.Name.ShouldBe(name);
    }
}
namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToSymbolIsCalled
{
    private const string Name = "Alpha";

    [Fact]
    public void GivenBaseThenReturnsSymbol()
    {
        // Arrange
        Base subject = new Symbol { Name = new Identifier(Name) };

        // Act
        Symbol value = subject;

        // Assert
        value.Name.ToString().ShouldBe(Name);
    }
}

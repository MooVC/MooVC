namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToSymbolIsCalled
{
    private const string Name = "Alpha";

    [Test]
    public async Task GivenBaseThenReturnsSymbol()
    {
        // Arrange
        var name = new Symbol.Moniker(Name);
        Base subject = new Symbol { Name = name };

        // Act
        Symbol value = subject;

        // Assert
        await Assert.That(value.Name).IsEqualTo(name);
    }
}
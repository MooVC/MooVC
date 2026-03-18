namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorFromSymbolIsCalled
{
    private const string Name = "Alpha";

    [Test]
    public async Task GivenSymbolThenReturnsBase()
    {
        // Arrange
        var symbol = new Symbol { Name = Name };

        // Act
        Base @base = symbol;
        bool areEqual = @base == symbol;

        // Assert
        _ = await Assert.That(@base).IsNotNull();
        await Assert.That(areEqual).IsTrue();
    }
}
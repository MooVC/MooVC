namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorFromSymbolIsCalled
{
    private const string Name = "Alpha";

    [Test]
    public void GivenSymbolThenReturnsBase()
    {
        // Arrange
        var symbol = new Symbol { Name = Name };

        // Act
        Base @base = symbol;
        bool areEqual = @base == symbol;

        // Assert
        _ = @base.ShouldNotBeNull();
        areEqual.ShouldBeTrue();
    }
}
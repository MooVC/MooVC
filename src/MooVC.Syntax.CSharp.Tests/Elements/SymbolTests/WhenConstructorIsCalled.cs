namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string ArgumentName = "Inner";

    [Fact]
    public void GivenDefaultsThenSymbolIsUnspecified()
    {
        // Act
        var subject = new Symbol();

        // Assert
        subject.Name.ShouldBe(Symbol.Moniker.Unnamed);
        subject.Arguments.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var argument = new Symbol { Name = ArgumentName };

        // Act
        var subject = new Symbol
        {
            Name = SymbolTestsData.DefaultName,
            Arguments = [argument],
        };

        // Assert
        subject.Name.ShouldBe(new Symbol.Moniker(SymbolTestsData.DefaultName));
        subject.Arguments.ShouldBe(new[] { argument });
        subject.IsUndefined.ShouldBeFalse();
    }
}
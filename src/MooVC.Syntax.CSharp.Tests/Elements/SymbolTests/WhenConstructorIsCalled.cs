namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenConstructorIsCalled
{
    private const string ArgumentName = "Inner";

    [Test]
    public async Task GivenDefaultsThenSymbolIsUnspecified()
    {
        // Act
        var subject = new Symbol();

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(Symbol.Moniker.Unnamed);
        _ = await Assert.That(subject.Arguments).IsEmpty();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
        _ = await Assert.That(subject.Name).IsEqualTo(new Symbol.Moniker(SymbolTestsData.DefaultName));
        _ = await Assert.That(subject.Arguments).IsEquivalentTo([argument]);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}
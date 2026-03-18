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
        await Assert.That(subject.Name).IsEqualTo(Symbol.Moniker.Unnamed);
        await Assert.That(subject.Arguments).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
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
        await Assert.That(subject.Name).IsEqualTo(new Symbol.Moniker(SymbolTestsData.DefaultName));
        await Assert.That(subject.Arguments).IsEqualTo(new[] { argument });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}
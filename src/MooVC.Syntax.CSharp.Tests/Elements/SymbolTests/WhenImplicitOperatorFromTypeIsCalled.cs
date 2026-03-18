namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Text;
using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorFromTypeIsCalled
{
    [Test]
    public async Task GivenNullThenThrows()
    {
        // Arrange
        Type? value = default;

        // Act
        Func<Symbol> result = () => value!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenTypeThenSymbolUsesNameAndQualifier()
    {
        // Arrange
        Type value = typeof(StringBuilder);

        // Act
        Symbol subject = value;

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(new Symbol.Moniker(nameof(StringBuilder)));
        _ = await Assert.That(subject.Qualifier).IsEqualTo(new Qualifier(["System", "Text"]));
    }
}
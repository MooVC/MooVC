namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Text;
using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorFromTypeIsCalled
{
    [Test]
    public void GivenNullThenThrows()
    {
        // Arrange
        Type? value = default;

        // Act
        Func<Symbol> result = () => value!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenTypeThenSymbolUsesNameAndQualifier()
    {
        // Arrange
        Type value = typeof(StringBuilder);

        // Act
        Symbol subject = value;

        // Assert
        subject.Name.ShouldBe(new Symbol.Moniker(nameof(StringBuilder)));
        subject.Qualifier.ShouldBe(new Qualifier(["System", "Text"]));
    }
}
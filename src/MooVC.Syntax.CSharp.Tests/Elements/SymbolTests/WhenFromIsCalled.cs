namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using MooVC.Syntax.Elements;

public sealed class WhenFromIsCalled
{
    [Test]
    public async Task GivenQualifierThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Value", qualifier: new Qualifier(["System"]));
        var qualifier = new Qualifier(["MooVC", "Syntax"]);

        // Act
        Symbol result = original.From(qualifier);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Qualifier).IsEqualTo(qualifier);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
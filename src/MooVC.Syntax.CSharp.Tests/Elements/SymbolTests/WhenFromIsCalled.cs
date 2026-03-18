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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Qualifier).IsEqualTo(qualifier);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        _ = await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
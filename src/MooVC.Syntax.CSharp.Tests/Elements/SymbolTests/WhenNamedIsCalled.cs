namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Original");
        var name = new Symbol.Moniker("Updated");

        // Act
        Symbol result = original.Named(name);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(name);
        _ = await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        _ = await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(name);
        await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
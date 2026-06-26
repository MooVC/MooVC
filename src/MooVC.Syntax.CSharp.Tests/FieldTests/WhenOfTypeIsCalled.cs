namespace MooVC.Syntax.CSharp.FieldTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenTypeThenReturnsNewInstanceWithUpdatedType()
    {
        // Arrange
        Field original = FieldTestsData.Create();
        Symbol type = SymbolTestsData.Create("Other");

        // Act
        Field result = original.OfType(type);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(type);

        _ = await Assert.That(original.Type).IsEqualTo(FieldTestsData.DefaultType);
    }
}
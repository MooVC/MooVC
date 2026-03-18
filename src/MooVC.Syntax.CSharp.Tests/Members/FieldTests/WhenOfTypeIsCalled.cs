namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.SymbolTests;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(type);

        await Assert.That(original.Type).IsEqualTo(FieldTestsData.DefaultType);
    }
}
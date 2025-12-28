namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsNewInstanceWithUpdatedType()
    {
        // Arrange
        Field original = FieldTestsData.Create();
        Symbol type = SymbolTestsData.Create("Other");

        // Act
        Field result = original.WithType(type);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(original.Default);
        result.IsReadOnly.ShouldBe(original.IsReadOnly);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(type);

        original.Type.ShouldBe(FieldTestsData.DefaultType);
    }
}
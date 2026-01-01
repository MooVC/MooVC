namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithQualifierIsCalled
{
    [Fact]
    public void GivenQualifierThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Value", qualifier: new Qualifier(["System"]));
        var qualifier = new Qualifier(["MooVC", "Syntax"]);

        // Act
        Symbol result = original.WithQualifier(qualifier);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Qualifier.ShouldBe(qualifier);
        result.Name.ShouldBe(original.Name);
        result.Arguments.ShouldBe(original.Arguments);
        result.IsNullable.ShouldBe(original.IsNullable);
    }
}
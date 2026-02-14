namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Original");
        var name = new Variable("Updated");

        // Act
        Symbol result = original.Named(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        result.Qualifier.ShouldBe(original.Qualifier);
        result.Arguments.ShouldBe(original.Arguments);
        result.IsNullable.ShouldBe(original.IsNullable);
    }
}
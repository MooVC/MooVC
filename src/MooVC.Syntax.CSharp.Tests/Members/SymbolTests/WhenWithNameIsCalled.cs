namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Original");
        var name = new Identifier("Updated");

        // Act
        Symbol result = original.WithName(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        result.Qualifier.ShouldBe(original.Qualifier);
        result.Arguments.ShouldBe(original.Arguments);
        result.IsNullable.ShouldBe(original.IsNullable);
    }
}
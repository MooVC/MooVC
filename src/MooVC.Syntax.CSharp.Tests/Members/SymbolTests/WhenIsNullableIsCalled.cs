namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenIsNullableIsCalled
{
    [Fact]
    public void GivenNullableThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Value");

        // Act
        Symbol result = original.IsNullable(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsNullable.ShouldBeTrue();
        result.Name.ShouldBe(original.Name);
        result.Qualifier.ShouldBe(original.Qualifier);
        result.Arguments.ShouldBe(original.Arguments);
        original.IsNullable.ShouldBeFalse();
    }
}
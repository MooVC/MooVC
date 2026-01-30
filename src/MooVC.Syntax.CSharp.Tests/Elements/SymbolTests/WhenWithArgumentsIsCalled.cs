namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Linq;

public sealed class WhenWithArgumentsIsCalled
{
    [Fact]
    public void GivenArgumentsThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Container", arguments: new Symbol { Name = new Variable("First") });
        Symbol[] additional = [new Symbol { Name = new Variable("Second") }];

        // Act
        Symbol result = original.WithArguments(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Arguments.ShouldBe(original.Arguments.Concat(additional));
        result.Name.ShouldBe(original.Name);
        result.Qualifier.ShouldBe(original.Qualifier);
        result.IsNullable.ShouldBe(original.IsNullable);
    }
}
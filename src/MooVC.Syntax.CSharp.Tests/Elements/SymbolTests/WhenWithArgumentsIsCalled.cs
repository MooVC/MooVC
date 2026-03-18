namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Linq;

public sealed class WhenWithArgumentsIsCalled
{
    [Test]
    public async Task GivenArgumentsThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Container", arguments: new Symbol { Name = "First" });
        Symbol[] additional = [new Symbol { Name = "Second" }];

        // Act
        Symbol result = original.WithArguments(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments.Concat(additional));
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        _ = await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
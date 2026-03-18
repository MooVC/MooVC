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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments.Concat(additional));
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
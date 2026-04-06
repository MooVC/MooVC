namespace MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenWithArgumentsIsCalled
{
    [Test]
    public async Task GivenArgumentsThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Container", arguments: new Symbol { Name = "First" });
        Symbol[] additional = [new() { Name = "Second" }];

        // Act
        Symbol result = original.WithArguments(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Arguments).IsEquivalentTo([.. original.Arguments, .. additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        _ = await Assert.That(result.IsNullable).IsEqualTo(original.IsNullable);
    }
}
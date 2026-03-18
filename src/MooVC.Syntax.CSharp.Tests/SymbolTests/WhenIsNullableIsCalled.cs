namespace MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenIsNullableIsCalled
{
    [Test]
    public async Task GivenNullableThenReturnsUpdatedInstance()
    {
        // Arrange
        Symbol original = SymbolTestsData.Create(name: "Value");

        // Act
        Symbol result = original.IsNullable(true);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.IsNullable).IsTrue();
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        _ = await Assert.That(original.IsNullable).IsFalse();
    }
}
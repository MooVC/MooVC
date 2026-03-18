namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.IsNullable).IsTrue();
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        await Assert.That(original.IsNullable).IsFalse();
    }
}
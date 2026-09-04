namespace MooVC.Syntax.CSharp.FieldTests;

public sealed class WhenWithDefaultIsCalled
{
    [Test]
    public async Task GivenDefaultThenReturnsNewInstanceWithUpdatedDefault()
    {
        // Arrange
        Field original = FieldTestsData.Create();
        var @default = Snippet.From("default");

        // Act
        Field result = original.WithDefault(@default);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Default).IsEqualTo(@default);
        _ = await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.Default).IsEqualTo(Snippet.Empty);
    }
}
namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(@default);
        await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.Default).IsEqualTo(Snippet.Empty);
    }
}
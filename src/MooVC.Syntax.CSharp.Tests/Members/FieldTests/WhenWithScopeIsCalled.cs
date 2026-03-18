namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Field original = FieldTestsData.Create();

        // Act
        Field result = original.WithScope(Scope.Internal);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.IsReadOnly).IsEqualTo(original.IsReadOnly);
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(Scope.Internal);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.Scope).IsEqualTo(Scope.Public);
    }
}
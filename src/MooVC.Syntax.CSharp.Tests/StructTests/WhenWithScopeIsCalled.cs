namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(scope: Scopes.Private);

        // Act
        Struct result = original.WithScope(Scopes.Internal);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scopes.Internal);
        _ = await Assert.That(original.Scope).IsEqualTo(Scopes.Private);
    }
}
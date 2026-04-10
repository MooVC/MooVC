namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(scope: Scopes.Private);

        // Act
        Interface result = original.WithScope(Scopes.Internal);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scopes.Internal);
        _ = await Assert.That(original.Scope).IsEqualTo(Scopes.Private);
    }
}
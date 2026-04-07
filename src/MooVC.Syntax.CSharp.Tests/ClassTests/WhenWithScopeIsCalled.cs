namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(scope: Scopes.Public);

        // Act
        Class result = original.WithScope(Scopes.Private);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scopes.Private);
        _ = await Assert.That(original.Scope).IsEqualTo(Scopes.Public);
    }
}
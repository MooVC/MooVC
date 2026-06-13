namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create(scope: Scopes.Internal);

        // Act
        Property result = original.WithScope(Scopes.Private);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(Scopes.Private);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);

        _ = await Assert.That(original.Scope).IsEqualTo(Scopes.Internal);
    }
}
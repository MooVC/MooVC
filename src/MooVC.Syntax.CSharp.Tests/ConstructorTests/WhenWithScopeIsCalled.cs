namespace MooVC.Syntax.CSharp.ConstructorTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        // Act
        Constructor result = original.WithScope(Scope.Private);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Extensibility).IsEqualTo(original.Extensibility);
        _ = await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Private);

        _ = await Assert.That(original.Scope).IsEqualTo(Scope.Public);
    }
}
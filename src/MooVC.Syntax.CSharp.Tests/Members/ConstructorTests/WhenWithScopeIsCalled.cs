namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Extensibility).IsEqualTo(original.Extensibility);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(result.Scope).IsEqualTo(Scope.Private);

        await Assert.That(original.Scope).IsEqualTo(Scope.Public);
    }
}
namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Event original = EventTestsData.Create(scope: Scope.Internal);

        // Act
        Event result = original.WithScope(Scope.Private);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Scope).IsEqualTo(Scope.Private);
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Handler).IsEqualTo(original.Handler);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
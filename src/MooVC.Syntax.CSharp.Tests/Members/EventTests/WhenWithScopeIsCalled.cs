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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Private);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Handler).IsEqualTo(original.Handler);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}
namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Method original = MethodTestsData.Create();

        // Act
        Method result = original.WithScope(Scope.Internal);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(Scope.Internal);
    }
}
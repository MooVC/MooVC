namespace MooVC.Syntax.CSharp.MethodTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        _ = await Assert.That(result.Result).IsEqualTo(original.Result);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Internal);
    }
}
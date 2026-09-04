namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(scope: Scopes.Internal);

        // Act
        Record result = original.WithScope(Scopes.Protected);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scopes.Protected);
        _ = await Assert.That(original.Scope).IsEqualTo(Scopes.Internal);
    }
}
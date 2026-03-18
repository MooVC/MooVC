namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(scope: Scope.Internal);

        // Act
        Record result = original.WithScope(Scope.Protected);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Protected);
        _ = await Assert.That(original.Scope).IsEqualTo(Scope.Internal);
    }
}
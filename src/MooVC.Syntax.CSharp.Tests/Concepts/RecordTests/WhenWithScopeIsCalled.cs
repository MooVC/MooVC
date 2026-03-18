namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Scope).IsEqualTo(Scope.Protected);
        await Assert.That(original.Scope).IsEqualTo(Scope.Internal);
    }
}
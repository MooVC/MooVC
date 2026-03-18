namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(scope: Scope.Private);

        // Act
        Struct result = original.WithScope(Scope.Internal);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Scope).IsEqualTo(Scope.Internal);
        await Assert.That(original.Scope).IsEqualTo(Scope.Private);
    }
}
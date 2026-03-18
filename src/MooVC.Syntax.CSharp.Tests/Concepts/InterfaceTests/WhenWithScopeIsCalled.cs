namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(scope: Scope.Private);

        // Act
        Interface result = original.WithScope(Scope.Internal);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Internal);
        _ = await Assert.That(original.Scope).IsEqualTo(Scope.Private);
    }
}
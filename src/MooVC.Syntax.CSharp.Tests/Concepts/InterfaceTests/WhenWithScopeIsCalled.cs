namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public void GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(scope: Scope.Private);

        // Act
        Interface result = original.WithScope(Scope.Internal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Scope.ShouldBe(Scope.Internal);
        original.Scope.ShouldBe(Scope.Private);
    }
}
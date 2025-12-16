namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
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

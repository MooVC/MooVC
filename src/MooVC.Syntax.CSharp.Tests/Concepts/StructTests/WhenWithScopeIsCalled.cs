namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(scope: Scope.Private);

        // Act
        Struct result = original.WithScope(Scope.Internal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Scope.ShouldBe(Scope.Internal);
        original.Scope.ShouldBe(Scope.Private);
    }
}
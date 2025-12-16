namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(scope: Scope.Public);

        // Act
        Class result = original.WithScope(Scope.Private);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Scope.ShouldBe(Scope.Private);
        original.Scope.ShouldBe(Scope.Public);
    }
}

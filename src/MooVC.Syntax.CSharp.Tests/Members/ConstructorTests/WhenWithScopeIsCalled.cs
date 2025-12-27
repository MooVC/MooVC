namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        // Act
        Constructor result = original.WithScope(Scope.Private);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Extensibility.ShouldBe(original.Extensibility);
        result.Parameters.ShouldBe(original.Parameters);
        result.Scope.ShouldBe(Scope.Private);

        original.Scope.ShouldBe(Scope.Public);
    }
}

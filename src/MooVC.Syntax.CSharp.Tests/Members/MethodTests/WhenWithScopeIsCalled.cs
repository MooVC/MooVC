namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Method original = MethodTestsData.Create();

        // Act
        Method result = original.WithScope(Scope.Internal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Name.ShouldBe(original.Name);
        result.Parameters.ShouldBe(original.Parameters);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(Scope.Internal);
    }
}

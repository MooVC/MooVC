namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Unary original = UnaryTestsData.Create();
        Scope replacement = Scope.Private;

        // Act
        Unary result = original.WithScope(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(replacement);
    }
}
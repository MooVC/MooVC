namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        Scope replacement = Scope.Private;

        // Act
        Comparison result = original.WithScope(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(replacement);
    }
}
namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Binary original = BinaryTestsData.Create();
        Scope replacement = Scope.Internal;

        // Act
        Binary result = original.WithScope(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(replacement);
    }
}

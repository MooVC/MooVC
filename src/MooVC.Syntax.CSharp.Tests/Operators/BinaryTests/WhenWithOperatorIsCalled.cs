namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenWithOperatorIsCalled
{
    [Fact]
    public void GivenOperatorThenReturnsNewInstanceWithUpdatedOperator()
    {
        // Arrange
        Binary original = BinaryTestsData.Create();
        Binary.Type replacement = Binary.Type.Subtract;

        // Act
        Binary result = original.WithOperator(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Operator.ShouldBe(replacement);
        result.Scope.ShouldBe(original.Scope);
    }
}

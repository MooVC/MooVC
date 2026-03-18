namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenWithOperatorIsCalled
{
    [Test]
    public async Task GivenOperatorThenReturnsNewInstanceWithUpdatedOperator()
    {
        // Arrange
        Binary original = BinaryTestsData.Create();
        Binary.Type replacement = Binary.Type.Subtract;

        // Act
        Binary result = original.WithOperator(replacement);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Operator).IsEqualTo(replacement);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}
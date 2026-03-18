namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenWithBodyIsCalled
{
    [Test]
    public async Task GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        var body = Snippet.From("return left != right;");

        // Act
        Comparison result = original.WithBody(body);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(body);
        _ = await Assert.That(result.Operator).IsEqualTo(original.Operator);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}
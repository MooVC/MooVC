namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Test]
    public async Task GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Binary original = BinaryTestsData.Create();
        var body = Snippet.From("return left * right;");

        // Act
        Binary result = original.WithBody(body);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(body);
        await Assert.That(result.Operator).IsEqualTo(original.Operator);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}
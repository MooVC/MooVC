namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Test]
    public async Task GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Unary original = UnaryTestsData.Create(body: Snippet.From("return value;"));
        var replacement = Snippet.From("return other;");

        // Act
        Unary result = original.WithBody(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(replacement);
        await Assert.That(result.Operator).IsEqualTo(original.Operator);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}
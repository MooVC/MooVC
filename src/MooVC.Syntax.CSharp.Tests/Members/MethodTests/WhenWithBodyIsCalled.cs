namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Test]
    public async Task GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Method original = MethodTestsData.Create(body: Snippet.From("return value;"));
        var replacement = Snippet.From("return other;");

        // Act
        Method result = original.WithBody(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(replacement);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters);
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}
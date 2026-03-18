namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Test]
    public async Task GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create(body: Snippet.From("return value;"));
        var replacement = Snippet.From("return other;");

        // Act
        Conversion result = original.WithBody(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(replacement);
        await Assert.That(result.Direction).IsEqualTo(original.Direction);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}
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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(replacement);
        _ = await Assert.That(result.Direction).IsEqualTo(original.Direction);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}